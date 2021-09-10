using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    /// <summary>
    /// Clase encargada del validar, notificar y cambiar el estado del proyecto a Enviado
    /// </summary>
    public class EnvioProyectoBL : BaseBL, IEnvioProyectoBL
    {

        private readonly ConcertacionContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly BaseRepository<AppVigencias> _vigenciasRepository;
        private readonly IAppRadicadoProyectosRepository<AppRadicadoProyectos> _radicadoProyectosRepository;
        private readonly IAppProyectosRepository<AppProyectos> _appProyectosRepositor;
        private readonly IAppProponentesRepository<AppProponentes> _appProponentesRepository;
        private readonly BaseRepository<EnvioCorreos> _envioCorreosRepository;
        private readonly BaseRepository<PlantillaCorreos> _plantillaCorreosRepository;
        private readonly IAppTemasProyectosRepository<AppTemasProyectos> _appTemasProRepository;
        private readonly BaseRepository<AppTemas> _temasRepository;
        private readonly ITrayectoriaProyectoRepository<TrayectoriaProyecto> _trayectoriaProyRepository;
        private readonly IAppComponentesRepository<AppComponentes> _appComponentesRepository;
        private readonly IAppCronogramaRepository<AppCronograma> _appCronogramaRepository;
        private readonly IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias> _actiObligatoriasRepository;
        private readonly IValoresIndicadorRepository<AppValoresIndicador> _valoresIndicadorRepository;
        private readonly IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> _appPresupuestoDetRepository;
        private readonly BaseRepository<AppDocumentosTipoEntidades> _appDocumentosTipEnt;
        private readonly IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> _appTipoDocValRepository;
      
        private readonly BaseRepository<AppTipoProyectoProponente> _appTipoProyProp;
        

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        /// <param name="configuration"></param>
        /// <param name="vigenciasRepository"></param>
        /// <param name="radicadoProyectosRepository"></param>
        /// <param name="appProyectosRepositor"></param>
        /// <param name="envioCorreosRepository"></param>
        /// <param name="plantillaCorreosRepository"></param>
        public EnvioProyectoBL(
            ConcertacionContext context,
            IMapper mapper,
            IConfiguration configuration,
            BaseRepository<AppVigencias> vigenciasRepository,
            IAppRadicadoProyectosRepository<AppRadicadoProyectos> radicadoProyectosRepository,
            IAppProyectosRepository<AppProyectos> appProyectosRepositor,
            IAppProponentesRepository<AppProponentes> appProponentesRepository,
            BaseRepository<EnvioCorreos> envioCorreosRepository,
            BaseRepository<PlantillaCorreos> plantillaCorreosRepository,
            IAppTemasProyectosRepository<AppTemasProyectos> appTemasProRepository,
            BaseRepository<AppTemas> temasRepository,
            ITrayectoriaProyectoRepository<TrayectoriaProyecto> trayectoriaProyRepository,
            IAppComponentesRepository<AppComponentes> appComponentesRepository,
            IAppCronogramaRepository<AppCronograma> appCronogramaRepository,
            IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias> actiObligatoriasRepository,
            IValoresIndicadorRepository<AppValoresIndicador> valoresIndicadorRepository,
            IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> appPresupuestoDetRepository,
            BaseRepository<AppDocumentosTipoEntidades> appDocumentosTipEnt,
            IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> appTipoDocValRepository,
           
            BaseRepository<AppTipoProyectoProponente> appTipoProyProp)
        {
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
            _vigenciasRepository = vigenciasRepository;
            _radicadoProyectosRepository = radicadoProyectosRepository;
            _appProyectosRepositor = appProyectosRepositor;
            _appProponentesRepository = appProponentesRepository;
            _envioCorreosRepository = envioCorreosRepository;
            _plantillaCorreosRepository = plantillaCorreosRepository;
            _appTemasProRepository = appTemasProRepository;
            _temasRepository = temasRepository;
            _trayectoriaProyRepository = trayectoriaProyRepository;
            _appComponentesRepository = appComponentesRepository;
            _appCronogramaRepository = appCronogramaRepository;
            _actiObligatoriasRepository = actiObligatoriasRepository;
            _valoresIndicadorRepository = valoresIndicadorRepository;
            _appPresupuestoDetRepository = appPresupuestoDetRepository;
            _appDocumentosTipEnt = appDocumentosTipEnt;
            _appTipoDocValRepository = appTipoDocValRepository;
            _appTipoProyProp = appTipoProyProp;
            
        }

        /// <summary>
        /// Realiza el proceso de envío del proyecto para ser evaluado por el MC
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <param name="usuario">Usuario que realiza la operación</param>
        /// <returns></returns>
        public RespuestaEnvioDto EnviarProyecto(decimal id, string usuario)
        {
            RespuestaEnvioDto respuesta = new RespuestaEnvioDto
            {
                Errores = new Collection<ErrorDto>()
            };
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //1.Validar todos los campos obligatorios del proyecto
                    AppProyectos proyecto = ValidarCamposObligatorios(id, respuesta);

                    if (respuesta.Errores.Count > 0)
                    {
                        DebugLog($"Error al realizar el envio del proyecto. Existen errores de negocio: {Environment.NewLine} {ConcatenarErrores(respuesta.Errores)}");
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Error al realizar el envio del proyecto.";
                    }
                    else
                    {
                        AppVigencias vigencia = GetVigencia();
                        if (vigencia == null)
                        {
                            DebugLog($"Error al realizar el envio del proyecto. Error: No existe una vigencia activa.");
                            respuesta.Errores.Add(new ErrorDto() { Codigo = "00", Descripcion = "Error interno al realizar el envio del proyecto, no existe vigencia activa." });
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al realizar el envio del proyecto.";
                        }
                        else
                        {
                            int consecutivo = 0;
                            string radicado = "";
                            AppProponentes proponente = _appProponentesRepository.Get(p => p.ProId == proyecto.ProIdProponente).FirstOrDefault();
                            bool esNitNacionales = _appTipoProyProp.Get(p => p.TppNit.Equals(proponente.ProNit)).FirstOrDefault() != null;
                            if (esNitNacionales)
                            {
                                InfoLog($"Generado radicado proyecto Nacionales. NIT: {proponente.ProNit}");
                                consecutivo = Convert.ToInt32(vigencia.VigConsecutivoNac + 1);
                                radicado = string.Format("CN{0}-{1}", consecutivo, vigencia.VigNombre);
                                vigencia.VigConsecutivoNac = consecutivo;
                            }
                            else
                            {
                                InfoLog($"Generado radicado proyecto Departamentales. NIT: {proponente.ProNit}");
                                consecutivo = Convert.ToInt32(vigencia.VigConsecutivo + 1);
                                radicado = string.Format("C{0}-{1}", consecutivo, vigencia.VigNombre);
                                vigencia.VigConsecutivo = consecutivo;
                            }

                            AppRadicadoProyectos appRadicado = new AppRadicadoProyectos()
                            {
                                ProId = id,
                                VigId = vigencia.VigId,
                                FechaRegistro = DateTime.Now,
                                RadicadoProyecto = radicado
                            };
                            //2. Crear el radicado
                            _radicadoProyectosRepository.Create(appRadicado);

                            //3. Actualizar el consecutivo de la vigencia
                            _vigenciasRepository.Update(vigencia);
                            proyecto.ProEstado = "E";
                            proyecto.FecModifico = DateTime.Now;
                            proyecto.UsuModifico = usuario;
                            proyecto.ProNumeroRadicacion = radicado;
                            //4. Cambiar el estado del proyecto
                            _appProyectosRepositor.Update(_mapper.Map<AppProyectos>(proyecto));

                            //5. Guardar registro enviar correo.
                            int idEnvio = (int)EnviarCorreo(proyecto, radicado);
                            if (idEnvio == 0)
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al realizar el envio del proyecto. Error: No se logró registrar el envío del coreo.";
                                respuesta.Errores.Add(new ErrorDto() { Codigo = "02", Descripcion = "Error al realizar el envio del proyecto. Error: No se logró registrar el envío del coreo." });
                                transaction.Rollback();
                            }
                            else
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Proyecto enviado correctamente!";
                                transaction.Commit();
                                InfoLog($"Proyecto enviado correctamente, radicado: {radicado}");

                                //6. Enviar a Generar reporte parte B
                                GenerarReporteParteB(id, radicado, idEnvio);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al realizar el envio del proyecto. Error: {ex.Message}");
                    respuesta.Errores.Add(new ErrorDto() { Codigo = "00", Descripcion = "Error interno al realizar el envio del proyecto, catch Error." });
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al realizar el envio del proyecto.";
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Valida que todos los campos obligatorios de la tabla APP_PROYECTOS y otras relacionadas venga correctamente
        /// diligenciadas
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <param name="respuesta">Respuesta con los errores encontrados</param>
        /// <returns>Proyecto encontrado y errores si existen</returns>
        private AppProyectos ValidarCamposObligatorios(decimal id, RespuestaEnvioDto respuesta)
        {
            AppProyectos proyecto = _appProyectosRepositor.Get(p => p.ProId == id).FirstOrDefault();
            if (proyecto == null)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "02", Descripcion = "No existe un proyecto con el ID ingresado" });
            }
            if (proyecto.AppRadicadoProyectos.Count > 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "03", Descripcion = $"El proyecto ya posee un radicado ({proyecto.AppRadicadoProyectos.ToArray()[0].RadicadoProyecto}) para la vigencia activa." });
            }
            if (proyecto.LinId == null)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "04", Descripcion = "Ingrese la línea del proyecto." });
            }
            //L1.1, L1.2, L3, L5.1, L5.2, L7 -- Líneas que deben tener temas seleccionados
            if (_temasRepository.Get(p => p.LinId == proyecto.LinId).Count > 0
                && _appTemasProRepository.Get(p => p.ProId == id).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "05", Descripcion = "Seleccione el tema asociado a la línea." });
            }
            if (string.IsNullOrEmpty(proyecto.ZonId))
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "06", Descripcion = "Seleccione el departamento y municipio del proyecto." });
            }
            //Validar la trayectoria
            if (_trayectoriaProyRepository.Get(p => p.PRO_ID == proyecto.ProId).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "07", Descripcion = "Ingrese la trayectoria del proyecto." });
            }
            //Validar table componentes
            AppComponentes componentes = _appComponentesRepository.Get(p => p.ProId == proyecto.ProId).FirstOrDefault();
            if (componentes == null)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "07", Descripcion = "Ingrese los datos de la sección Componentes del proyecto." });
            }
            else
            {
                if (string.IsNullOrEmpty(componentes.ComJustificacion)
                    || string.IsNullOrEmpty(componentes.ComMetas))
                {
                    respuesta.Errores.Add(new ErrorDto() { Codigo = "07", Descripcion = "Ingrese los datos de la sección Componentes del proyecto." });
                }
            }
            //Validar fechas del cronograma
            if (proyecto.ProFechaInicial == null || proyecto.ProFechaFinal == null)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "08", Descripcion = "Ingrese la Fecha de inicialización y finalización del proyecto." });
            }
            //Validar cronograma
            if (_appCronogramaRepository.Get(p => p.ProId == proyecto.ProId).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "09", Descripcion = "Ingrese el cronograma del proyecto." });
            }
            //Validar actividades obligatorias del proyecto
            if (_actiObligatoriasRepository.Get(p => p.ProId == proyecto.ProId).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "10", Descripcion = "Ingrese las actividades obligatorias del proyecto." });
            }
            //Validar impactos
            if (_valoresIndicadorRepository.Get(p => p.ProId == proyecto.ProId).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "11", Descripcion = "Ingrese los impactos del proyecto." });
            }
            //Validar presupuesto
            if (_appPresupuestoDetRepository.Get(p => p.ProId == proyecto.ProId).Count == 0)
            {
                respuesta.Errores.Add(new ErrorDto() { Codigo = "11", Descripcion = "Ingrese el presupuesto del proyecto." });
            }
            //Validar documentos
            AppProponentes proponente = _appProponentesRepository.Get(p => p.ProId == proyecto.ProIdProponente).FirstOrDefault();
            List<AppDocumentosTipoEntidades> listDocs = _appDocumentosTipEnt.Get(p => p.TipId == proponente.TipId && p.Obligatorio).ToList();
            int codigo = 12;
            if (listDocs.Count > 0)
            {
                List<AppTipoDocumentosValores> listDocsIng = _appTipoDocValRepository.Get(p => p.ProId == proyecto.ProId).ToList();
                foreach (var docObligatorio in listDocs)
                {
                    if (listDocsIng.Where(p => p.TdoId == docObligatorio.TdoId).ToList().Count == 0)
                    {
                        respuesta.Errores.Add(new ErrorDto() { Codigo = codigo.ToString(), Descripcion = $"El documento: { docObligatorio.Tdo.TdoNombre } es obligatorio." });
                        codigo++;
                    }
                }
            }

            return proyecto;
        }

        /// <summary>
        /// Buscar la plantilla del correo, remplazar los datos y salvarlo en la base de datos para
        /// enviarlo posteriormente en el servicio de windows.
        /// </summary>
        /// <param name="proyecto">Información del proyecto</param>
        /// <param name="radicado">Número de radicado del proyecto</param>
        /// <returns>Id del registro almacenado del correo</returns>
        private long EnviarCorreo(AppProyectos proyecto, string radicado)
        {
            string mensaje = string.Empty, body_replace = string.Empty;
            //Obtengo la plantilla del correo y remplazo las variables dinámicas (Usuario, enlace, etc).
            var plantilla = _plantillaCorreosRepository.Get(p => p.Codigoplantillacorreos.Equals("003")).FirstOrDefault();
            if (plantilla == null)
            {
                DebugLog($"Error la cargar plantilla de correo para armar el radicado del proyecto [{proyecto.ProId}].");
                return 0;
            }
            else
            {
                var body = plantilla.Cuerpo;
                var link = _configuration.GetSection("linkSite").Value + "home";
                body_replace = body.Replace("{PROYECTO}", proyecto.ProNombre.ToUpper()).Replace("{RADICADO}", radicado).Replace("{LINK}", link);
                //8. Guardo la notificación en la tabla de ENVIO_CORREOS para que el worker de envío de correo lo procese posteriormente.
                return _envioCorreosRepository.Create(new EnvioCorreos()
                {
                    Asunto = plantilla.Asunto,
                    Cuerpo = body_replace,
                    Remitentes = proyecto.ProCorreoPersonaEncargada,
                    Enviado = true,
                    Intento = 0,
                    FechaCreo = DateTime.Now
                });
            }
        }

        /// <summary>
        /// IMPORTANTE
        /// Invoca al proyecto de generación de reportes, la URL de este esta configurada en la variable: <b>linkRepParteB</b>
        /// del <b>appSettings.json</b>, esta generación del reporte se llama asincrona, cuando finaliza la generación del informe
        /// en el proyecto de reportes, genera el archivo y lo salva en el disco duro del servidor y actualiza el campo enviado en
        /// la tabla: dbo.ENVIO_CORREOS igual cero para que el servicio de windows (WorkerEnvioCorreos) envíe el reporte b adjunto
        /// al correo.
        /// Los siguientes parametros son requeridos para invocar el proyecto de generación de reportes.
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <param name="radicado">Número de radicado</param>
        /// <param name="idEnvio">Id generado de la tabla dbo.ENVIO_CORREOS</param>
        private async void GenerarReporteParteB(decimal id, string radicado, int idEnvio)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{_configuration.GetSection("linkRepParteB").Value}?Id={id}&Rad={radicado}&IdE={idEnvio}";
                await client.GetStringAsync(url);
            }
        }


        /// Obtener el IdVigencia para crear el proyecto y asociarlo
        /// </summary>
        /// <returns></returns>
        private AppVigencias GetVigencia()
        {
            var vigencia = _vigenciasRepository.Get(p => p.VigEstado.Equals("A")).FirstOrDefault();
            return vigencia;
        }

        /// <summary>
        /// Concatenear todos los errores para salvar en el log.
        /// </summary>
        /// <param name="list">lista de errores</param>
        /// <returns>Cadena con todos los errores</returns>
        private string ConcatenarErrores(Collection<ErrorDto> list)
        {
            StringBuilder errores = new StringBuilder();
            foreach (var item in list)
            {
                errores.Append(item.Descripcion + Environment.NewLine);
            }
            return errores.ToString();
        }
    }
}