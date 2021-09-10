using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinCultura.Domain.BL
{
    public class EvaluacionBL : BaseBL, IEvaluacionBL
    {
        private readonly BaseRepository<AppDocumentosTipoEntidades> _appDocumentosTipoEntidadesRepositor;
        private readonly IEvaluacionRequisitosRepository<AppEvaluacionRequisitos> _appEvaluacionRequisitosRepositor;
        private readonly IRequisitosRepository<AppRequisitos> _appRequisitosRepositor;
        private readonly IAppProyectosRepository<AppProyectos> _appProyectosRepositor;
        private readonly BaseRepository<PlantillaCorreos> _plantillaCorreosRepository;
        private readonly IConfiguration _configuration;
        private readonly BaseRepository<EnvioCorreos> _envioCorreosRepository;
        private readonly ConcertacionContext _context;
        private readonly IMapper _mapper;
        private readonly ICuentausuarioRepository<Cuentausuario> _usuarioRepository;
        private readonly IRequisitosRepository<AppRequisitos> _appRequisitosRepository;
        private readonly IAppDetallesTipoEntidadesRepository<AppDetalleTiposEntidades> _appDetalleTipoEntidadesRepository;
        private readonly IZonasGeograficasRepository<BasZonasGeograficas> _appZonasGeograficasRepository;
        private readonly ICuentausuarioRepository<Cuentausuario> _appCuentaUsuarioRepository;
        private readonly BaseRepository<AppVigencias> _appVigenciasRepository;
        private readonly IAppRadicadoProyectosRepository<AppRadicadoProyectos> _appRadicadoProyectosRepository;
        private readonly BaseRepository<AppLineas> _appLineasRepository;

        public EvaluacionBL(
            BaseRepository<AppDocumentosTipoEntidades> appDocumentosTipoEntidadesRepositor,
            IRequisitosRepository<AppRequisitos> appRequisitosRepositor,
            IEvaluacionRequisitosRepository<AppEvaluacionRequisitos> appEvaluacionRequisitosRepositor,
            IAppProyectosRepository<AppProyectos> appProyectosRepositor,
            BaseRepository<PlantillaCorreos> plantillaCorreosRepository,
            ICuentausuarioRepository<Cuentausuario> usuarioRepository,
            BaseRepository<EnvioCorreos> envioCorreosRepository,
            ConcertacionContext context,
            IConfiguration configuration,
            IRequisitosRepository<AppRequisitos> appRequisitosRepository,
             IEvaluacionRequisitosRepository<AppEvaluacionRequisitos> appEvaluacionRequisitosRepository,
            IAppDetallesTipoEntidadesRepository<AppDetalleTiposEntidades> appDetalleTipoEntidadesRepository,
            IZonasGeograficasRepository<BasZonasGeograficas> appZonasGeograficasRepository,
            ICuentausuarioRepository<Cuentausuario> appCuentaUsuariorepository,
            BaseRepository<AppVigencias> appVigenciasRepository,
            IAppRadicadoProyectosRepository<AppRadicadoProyectos> appRadicadoProyectosRepository,
            BaseRepository<AppLineas> appLineasRepository,
            IMapper mapper
            )
        {
            _appDocumentosTipoEntidadesRepositor = appDocumentosTipoEntidadesRepositor;
            _appRequisitosRepositor = appRequisitosRepositor;
            _appEvaluacionRequisitosRepositor = appEvaluacionRequisitosRepositor;
            _appProyectosRepositor = appProyectosRepositor;
            _plantillaCorreosRepository = plantillaCorreosRepository;
            _usuarioRepository = usuarioRepository;
            _envioCorreosRepository = envioCorreosRepository;
            _configuration = configuration;
            _appRequisitosRepository = appRequisitosRepository;
            _appDetalleTipoEntidadesRepository = appDetalleTipoEntidadesRepository;
            _appZonasGeograficasRepository = appZonasGeograficasRepository;
            _appCuentaUsuarioRepository = appCuentaUsuariorepository;
            _appVigenciasRepository = appVigenciasRepository;
            _appRadicadoProyectosRepository = appRadicadoProyectosRepository;
            _appLineasRepository = appLineasRepository;
            _mapper = mapper;
            _context = context;
        }

        public Collection<ProyectoDto> GetProyectoByEstado(string estado)
        {
            return _mapper.Map<Collection<ProyectoDto>>(_appProyectosRepositor.Get( p => p.ProEstado == estado));
        }


        public Collection<EvaluacionRequisitosDto> GetProyectoByEvaluacionRequisitos(decimal proId)
        {
            return _mapper.Map<Collection<EvaluacionRequisitosDto>>(_appEvaluacionRequisitosRepositor.Get(e => e.ProId == proId));
        }

        public ProyectoDto GetProyectoById(decimal proId)
        {
            return _mapper.Map<Collection<ProyectoDto>>(_appProyectosRepositor.Get(p => p.ProId == proId)).FirstOrDefault();
        }

        public bool CrearEvaluacionForma(List<EvaluacionRequisitosDto> evaluacionRequisitosDto, string user)
        {

            bool resultado = false;
            decimal proId = evaluacionRequisitosDto[0].ProId;
            List<AppEvaluacionRequisitos> listaEvaluacionRequisitos;
            listaEvaluacionRequisitos = (List<AppEvaluacionRequisitos>)_appEvaluacionRequisitosRepositor.Get(p => p.ProId == proId);

            try
            {
                if (ExisteEvaluacionRequisitos(proId))
                {
                    evaluacionRequisitosDto.ForEach(evaluacionDto =>
                    {
                        var evaluacionFoundDto = listaEvaluacionRequisitos.Find(evaluacion => evaluacion.ReqId == evaluacionDto.ReqId);

                        if (evaluacionFoundDto != null)
                        {
                            evaluacionDto.UsuModifico = user;
                            evaluacionDto.FecModifico = DateTime.Now;

                            ActualizarEvaluacionRequisitos(evaluacionDto);
                        }
                        else
                        {
                            evaluacionDto.UsuCreo = user;
                            evaluacionDto.FecCreo = DateTime.Now;

                            CrearEvaluacionRequisitos(evaluacionDto);
                        }
                    });
                }
                else
                {
                    evaluacionRequisitosDto.ForEach(evaluacionDto =>
                    {
                        evaluacionDto.UsuCreo = user;
                        evaluacionDto.FecCreo = DateTime.Now;
                        CrearEvaluacionRequisitos(evaluacionDto);
                    });
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar Evalaución de requisitos del proyecto {ex.Message}");
            }
            return resultado;
        }

        #region Crear

        private bool CrearEvaluacionRequisitos(EvaluacionRequisitosDto evaluacionRequisitosDto)
        {
            bool resultado;
            AppEvaluacionRequisitos evaluacionRequisitosModel;

            try
            {
                evaluacionRequisitosModel = _mapper.Map<AppEvaluacionRequisitos>(evaluacionRequisitosDto);
                _appEvaluacionRequisitosRepositor.Create(evaluacionRequisitosModel);
                InfoLog($"Componente del evaluación de requisitos create succeeded: {JsonSerializer.Serialize(evaluacionRequisitosModel, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al crear el componente del evaluación de requisitos {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        #endregion

        #region Actualizar
        private bool ActualizarEvaluacionRequisitos(EvaluacionRequisitosDto evaluacionRequisitosDto)
        {
            bool resultado;
            AppEvaluacionRequisitos evaluacionRequisitosModel;
            try
            {
                evaluacionRequisitosModel = _mapper.Map<AppEvaluacionRequisitos>(evaluacionRequisitosDto);
                int resUpdate = _appEvaluacionRequisitosRepositor.Update(evaluacionRequisitosModel);
                if (resUpdate > 0)
                {
                    InfoLog($"El componente evaluación de requisisto del proyecto update succeeded: {JsonSerializer.Serialize(evaluacionRequisitosModel, SerializerOptions.options)}");
                    resultado = true;
                }
                else
                {
                    InfoLog($"Error al actualizar el componente evaluación de requisisto del proyecto update: No hay temas que actualizar.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        public bool CambiarEstadoProyecto(decimal proId)
        {
            bool resultado;
            try
            {
                AppProyectos proyecto = _appProyectosRepositor.Get(p => p.ProId == proId).FirstOrDefault();
                proyecto.ProEstado = "E";

                int resUpdate = _appProyectosRepositor.Update(proyecto);
                if (resUpdate > 0)
                {
                    InfoLog($"El estado del proyecto update succeeded: {JsonSerializer.Serialize(proyecto, SerializerOptions.options)}");
                    resultado = true;
                }
                else
                {
                    InfoLog($"Error al actualizar estado del proyecto: no hay proyecto por actualizar.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el estdo del proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }
        #endregion


        #region Existe
        /// <summary>
        /// Existe evaluación de requisitos por proyecto
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        private bool ExisteEvaluacionRequisitos(decimal pro_id)
        {
            return _appEvaluacionRequisitosRepositor.Get(p => p.ProId == pro_id).FirstOrDefault() != null;
        }
        #endregion


        #region Correo
        public RespuestaDto EnviarCorreoSolicitudDocumento(ProyectoDto proyecto)
        {
            string mensaje = string.Empty, body_replace = string.Empty;
            bool Ok = false;
            RespuestaDto respuesta = new RespuestaDto();
            string documentoNoCumple = "<table style='width:100%;border-collapse:collapse;' border='1'><tr><th>Documento</th><th> Observación </th></tr>";

            Collection<RequisitosDto> Requisitos;
            Requisitos = _mapper.Map<Collection<RequisitosDto>>(_appRequisitosRepository.Get(r => r.TipId == int.Parse(proyecto.EntId.ToString()) && r.VigId == GetVigencia()));

            AppRadicadoProyectos radicadoProyecto = _appRadicadoProyectosRepository.Get(r => r.ProId == proyecto.ProId).FirstOrDefault();

            AppLineas linea = _appLineasRepository.Get( l => l.LinId == proyecto.LinId).FirstOrDefault();

            List<AppEvaluacionRequisitos> listaEvaluacionRequisitos;
            listaEvaluacionRequisitos = (List<AppEvaluacionRequisitos>)_appEvaluacionRequisitosRepositor.Get(p => p.ProId == proyecto.ProId && p.PunValor == "N");

            AppDetalleTiposEntidades detalleEntidad = _appDetalleTipoEntidadesRepository.Get(p => p.TipId == int.Parse(proyecto.TipId.ToString())).FirstOrDefault();

            var usuarioLogeado = _appCuentaUsuarioRepository.Get(p => p.Cuentausuariousuario.ToLower().Equals(proyecto.UsuCreo.ToLower())).FirstOrDefault();

            string Municipio = _appZonasGeograficasRepository.Get(z => z.ZonId == proyecto.ZonId).FirstOrDefault().ZonNombre;
            string Departamento = _appZonasGeograficasRepository.Get(z => z.ZonId == proyecto.ZonDepId).FirstOrDefault().ZonNombre;

            if (listaEvaluacionRequisitos.Count > 0)
            {
                var resultado = from ru in Requisitos
                                join ti in listaEvaluacionRequisitos on ru.ReqId equals ti.ReqId
                                select new
                                {
                                    ru.ReqNombre,
                                    ti.EvaObservacion
                                };

                foreach (var item in resultado)
                {
                    documentoNoCumple += "<tr><td>" + item.ReqNombre + "</td><td>" + item.EvaObservacion + "</td></tr>";
                }
            }
            documentoNoCumple += "</table>";

            try
            {
                var plantilla = _plantillaCorreosRepository.Get(p => p.Codigoplantillacorreos.Equals("003")).FirstOrDefault();
                if (plantilla == null)
                {
                    DebugLog("Error al obtener plantilla de envío de correos");
                    Ok = false;
                    mensaje = "Error al obtener plantilla de envío de correos";
                }
                else
                {
                    string body = plantilla.Cuerpo;
                    //var link = _configuration.GetSection("linkSite").Value + "newpasscode?guid=" + cuentausuario.Cuentausuariolink;
                    body_replace = body.Replace("%fecha%", DateTime.Now.ToShortDateString()).Replace("%nombre%", proyecto.ProPersonaEncargadaProyecto).Replace("%razonsocial%", detalleEntidad.DetNombre).Replace("%municipio%", Municipio).Replace("%departamento%", Departamento).Replace("%radicado%", radicadoProyecto.RadicadoProyecto).Replace("%requisitos%", documentoNoCumple).Replace("%correoevaluador%", usuarioLogeado.Cuentausuarioemail).Replace("%proyecto%", proyecto.ProNombre).Replace("%convocatoria%", linea.LinDescripcion);
                }

                //3. Guardo la notificación en la tabla de ENVIO_CORREOS para que el worker de envío de correo lo procese posteriormente.
                _envioCorreosRepository.Create(new EnvioCorreos()
                {
                    Asunto = plantilla.Asunto,
                    Cuerpo = body_replace,

                    Remitentes = proyecto.ProCorreoPersonaEncargada + "," + usuarioLogeado.Cuentausuarioemail, //+ "," + cuentausuario.Cuentausuarioemail,//
                    Enviado = false,
                    Intento = 0,
                    FechaCreo = DateTime.Now,
                    proId = int.Parse(proyecto.ProId.ToString())
                });

                //_appProyectosRepositor.Update()
                //SetEstadoProyecto(int.Parse(proyecto.ProId.ToString()), 15);
                //}

                // Actualizar la tabla proyecto con carta complementación
                
                AppProyectos proyectoActualizar = _appProyectosRepositor.Get(p => p.ProId == proyecto.ProId).FirstOrDefault();
                if(proyectoActualizar != null)
                {
                    DateTime fecha = DateTime.Now;
                    proyectoActualizar.ProEnvioCartaComplementacion = fecha;
                    proyectoActualizar.UsuIdCartaComplementacion = usuarioLogeado.Personaid;
                    _appProyectosRepositor.Update(proyectoActualizar);
                }

                DebugLog(proyecto.ProCorreoPersonaEncargada + "," + usuarioLogeado.Cuentausuarioemail + "," + proyecto.UsuModifico);
                Ok = true;
                mensaje = "El correo fue enviado con éxito a la persona encargada del proyecto: " + proyecto.ProPersonaEncargadaProyecto;


            }
            catch (Exception ex)
            {
                Ok = false;
                mensaje = $"Error al intentar enviar el correo a la perosona encargada del proyecto, detalle del error: {ex.Message}";
                DebugLog($"Error al intentar enviar el correo a la perosona encargada del proyecto, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = Ok;
            respuesta.Mensaje = mensaje;
            return respuesta;
        }

        #endregion

        /// <summary>
        /// Obtener el IdVigencia para crear el proyecto y asociarlo
        /// </summary>
        /// <returns></returns>
        private decimal GetVigencia()
        {
            var vigencia = _appVigenciasRepository.Get(p => p.VigEstado == "A").FirstOrDefault();
            return vigencia != null ? vigencia.VigId : 0;
        }

    }
}
