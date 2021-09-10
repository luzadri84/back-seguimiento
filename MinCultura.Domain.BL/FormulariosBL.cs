using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    public class FormulariosBL : BaseBL, IFormulariosBL
    {
        private readonly IAppProponentesRepository<AppProponentes> _appProponentesRepositor;
        private readonly IAppProyectosRepository<AppProyectos> _appProyectosRepositor;
        private readonly IAppTemasProyectosRepository<AppTemasProyectos> _appTemasProyectosRepositor;
        private readonly IAppComponentesRepository<AppComponentes> _appComponentesRepositor;
        private readonly IAppCronogramaRepository<AppCronograma> _appCronogramaRepositor;
        private readonly IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias> _appProyectoActividadesObligatoriasRepositor;
        private readonly IValoresIndicadorRepository<AppValoresIndicador> _appValoresIndicadorRepositor;
        private readonly BaseRepository<AppLineas> _lineasRepository;
        private readonly BaseRepository<AppVigencias> _vigenciasRepository;
        private readonly IValoresIndicadorLineaCategoriaMunicipioRepository<AppValoresIndicadorLineaCategoriaMunicipio> _appValoresIndicadorLineaCategoriaRepositor;
        private readonly BaseRepository<AppBeneficiarios> _appBeneficiarios;
        private readonly BaseRepository<ConSeguimientos> _conseguimientos;
        private readonly ConcertacionContext _context;
        private readonly IMapper _mapper;

        public FormulariosBL(
            IAppProponentesRepository<AppProponentes> appProponentesRepositor,
            IAppProyectosRepository<AppProyectos> appProyectosRepositor,
            IAppTemasProyectosRepository<AppTemasProyectos> appTemasProyectos,
            IAppComponentesRepository<AppComponentes> appComponentes,
            IAppCronogramaRepository<AppCronograma> appCronograma,
            IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias> appProyectoActividadesObligatorias,
            IActividadesObligatoriasRepository<AppActividadesObligatorias> appActividadesObligatorias,
            IValoresIndicadorRepository<AppValoresIndicador> appValoresIndicador,
            IValoresIndicadorLineaCategoriaMunicipioRepository<AppValoresIndicadorLineaCategoriaMunicipio> appValoresIndicadorLineaCategoriaMunicipioRepositor,
            BaseRepository<AppVigencias> vigenciasRepository,
            BaseRepository<AppLineas> lineasRepository,
            BaseRepository<AppBeneficiarios> appBeneficiarios,
            BaseRepository<ConSeguimientos> conseguimientos,

            ConcertacionContext context,
            IMapper mapper
            )
        {
            _appProponentesRepositor = appProponentesRepositor;
            _appProyectosRepositor = appProyectosRepositor;
            _appTemasProyectosRepositor = appTemasProyectos;
            _appComponentesRepositor = appComponentes;
            _appCronogramaRepositor = appCronograma;
            _appProyectoActividadesObligatoriasRepositor = appProyectoActividadesObligatorias;
            _appValoresIndicadorRepositor = appValoresIndicador;
            _vigenciasRepository = vigenciasRepository;
            _lineasRepository = lineasRepository;
            _appValoresIndicadorLineaCategoriaRepositor = appValoresIndicadorLineaCategoriaMunicipioRepositor;
            _appBeneficiarios = appBeneficiarios;
            _conseguimientos = conseguimientos;
            _mapper = mapper;
            _context = context;
        }


        #region Actualizar

        /// <summary>
        /// Recibe la información diligenciada en el formulario B y realiza la operación de actualización del proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto ActualizarFormularioB(FormularioBDto formularioB, string UserName)
        {
            RespuestaDto respuesta = new RespuestaDto();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ExisteProyecto((decimal)formularioB.Proyecto.ProId))
                    {
                        if (ActualizarProyecto(formularioB.Proyecto))
                        {
                            if (ActualizarTemas(formularioB.TemasbyProyectos, (decimal)formularioB.Proyecto.ProId))
                            {

                                if (!ExisteComponente((decimal)formularioB.Componentes.ProId))
                                {
                                    formularioB.Componentes.UsuCreo = UserName;
                                    formularioB.Componentes.FecCreo = DateTime.Now;
                                    CrearComponentes(formularioB.Componentes);

                                    respuesta.Resultado = true;
                                    respuesta.Mensaje = "Formulario B actualizado correctamente!";
                                }
                                else
                                {
                                    formularioB.Componentes.UsuModifico = UserName;
                                    formularioB.Componentes.FecModifico = DateTime.Now;

                                    ActualizarComponentes(formularioB.Componentes);

                                    respuesta.Resultado = true;
                                    respuesta.Mensaje = "Formulario B actualizado correctamente!";
                                }

                                if (formularioB.Cronograma.Count > 0)
                                {
                                    formularioB.Cronograma.ForEach(cronograma =>
                                    {
                                        cronograma.UsuCreo = UserName;
                                        cronograma.FecCreo = DateTime.Now;
                                    });

                                    ActualizarCronograma(formularioB.Cronograma, (decimal)formularioB.Proyecto.ProId);
                                }


                                if (ExisteProyectoActividadesObligatorias((decimal)formularioB.Proyecto.ProId))
                                {
                                    List<AppProyectoActividadesObligatorias> listaPAO = (List<AppProyectoActividadesObligatorias>)_appProyectoActividadesObligatoriasRepositor.Get(p => p.ProId == formularioB.Proyecto.ProId);
                                    formularioB.ProyectoActividadesObligatorias.ForEach(p =>
                                    {
                                        var pao = listaPAO.Find(item => item.PaoId == p.PaoId);

                                        if (pao != null)
                                        {
                                            p.UsuModifico = UserName;
                                            p.FecModifico = DateTime.Now;
                                            ActualizarProyectoActividadObligatoria(p);
                                        }
                                        else
                                        {
                                            p.UsuCreo = UserName;
                                            p.FecCreo = DateTime.Now;
                                            CrearProyectoActividadesObligatorias(p);
                                        }
                                    });
                                }
                                else
                                {
                                    formularioB.ProyectoActividadesObligatorias.ForEach(p =>
                                    {
                                        p.UsuCreo = UserName;
                                        p.FecCreo = DateTime.Now;
                                        CrearProyectoActividadesObligatorias(p);
                                    });
                                }


                                if (formularioB.ValoresIndicador.Count > 0)
                                {
                                    formularioB.ValoresIndicador.ForEach(vi =>
                                    {
                                        vi.UsuCreo = UserName;
                                        vi.FecCreo = DateTime.Now;
                                    });

                                    ActualizarValoresIndicador(formularioB.ValoresIndicador, (decimal)formularioB.Proyecto.ProId);
                                }

                                if (formularioB.ValoresIndicadorLineaCategoriaMunicipio.Count > 0)
                                {
                                    formularioB.ValoresIndicadorLineaCategoriaMunicipio.ForEach(vilcm =>
                                    {
                                        vilcm.UsuCreo = UserName;
                                        vilcm.FecCreo = DateTime.Now;
                                    });
                                    ActualizarValoresIndicadorLineaCategoriaMunicipio(formularioB.ValoresIndicadorLineaCategoriaMunicipio, (decimal)formularioB.Proyecto.ProId);
                                    
                                }
                                transaction.Commit();
                            }
                        }
                        else
                        {
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al actualizar el proyecto!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al guardar el formulario b. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al guardar el formulario b.";
                }
                return respuesta;
            }
        }


        /// <summary>
        /// Recibe la información diligenciada en el formulario de proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto ActualizacionProyecto(ProyectoDto proyecto)
        {
            RespuestaDto respuesta = new RespuestaDto();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    
                        if (!ExisteProyecto((decimal)proyecto.ProId))
                        {
                        proyecto.ProEstado = "D";
                            if (CrearProyecto(proyecto))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Proyecto creado correctamente!";
                                respuesta.Id = proyecto.ProId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al crear el proyecto!";
                            }
                        }
                        else
                        {
                            if (ActualizarProyecto(proyecto))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Proyecto actualizado correctamente!";
                                respuesta.Id = proyecto.ProId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al actualizar el proyecto!";
                            }
                        }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al guardar el formulario b. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al guardar el formulario b.";
                }
                return respuesta;
            }
        }

        /// <summary>
        /// Actualizar un proponente
        /// </summary>
        /// <param name="proponente">Información del proponente</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        private bool ActualizarProponente(ProponenteDto proponente)
        {
            bool resultado;
            try
            {
                var _proponente = _mapper.Map<AppProponentes>(proponente);
                _appProponentesRepositor.Update(_proponente);
                InfoLog($"Proponente update succeeded: {JsonSerializer.Serialize(proponente, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el proponente {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar un proponente
        /// </summary>
        /// <param name="proponente">Información del proponente</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        private bool ActualizarBeneficiario(AppBeneficiariosDto beneficiario)
        {
            bool resultado;
            try
            {
                var _beneficiario = _mapper.Map<AppBeneficiarios>(beneficiario);
                _appBeneficiarios.Update(_beneficiario);
                InfoLog($"Beneficiario update succeeded: {JsonSerializer.Serialize(beneficiario, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar beneficiario {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar un proyecto existente
        /// </summary>
        /// <param name="proyecto">Información del proyecto a actualizar</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        private bool ActualizarProyecto(ProyectoDto proyectoDto)
        {
            bool resultado = false;
            AppProyectos proyectoModel;
            try
            {
                proyectoModel = _mapper.Map<AppProyectos>(proyectoDto);
                proyectoModel.VigId = GetIdVigencia();
                int resUpdate = _appProyectosRepositor.Update(proyectoModel);
                if (resUpdate > 0)
                {
                    InfoLog($"Proyecto update succeeded: {JsonSerializer.Serialize(proyectoModel, SerializerOptions.options)}");
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar temas asociados al proyecto
        /// </summary>
        /// <param name="temasProyectos"></param>
        /// <returns>Estado del actualización de los temas del proyecto</returns>
        private bool ActualizarTemas(List<TemasProyectosDto> temasProyectosDto, decimal proId)
        {
            bool resultado = false;
            List<AppTemasProyectos> listaTemasProyectosModel;
            try
            {
                listaTemasProyectosModel = (List<AppTemasProyectos>)_appTemasProyectosRepositor.Get(p => p.ProId == proId);
                _appTemasProyectosRepositor.DeleteAll(listaTemasProyectosModel);
                if (temasProyectosDto.Count > 0)
                {
                    listaTemasProyectosModel.Clear();
                    listaTemasProyectosModel = _mapper.Map<List<AppTemasProyectos>>(temasProyectosDto);
                    int resCreate = _appTemasProyectosRepositor.Create(listaTemasProyectosModel);
                    if (resCreate > 0)
                    {
                        InfoLog($"Temas del proyecto update succeeded: {JsonSerializer.Serialize(listaTemasProyectosModel, SerializerOptions.options)}");
                        resultado = true;
                    }
                    else
                    {
                        InfoLog($"Temas del proyecto update failed: {JsonSerializer.Serialize(listaTemasProyectosModel, SerializerOptions.options)}");
                    }
                }
                else
                {
                    InfoLog($"Temas del proyecto update: No hay temas que actualizar.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar temas del proyecto {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar cronograma
        /// </summary>
        /// <param name="cronograma"></param>
        /// <returns>Estado del actualización del cornograma</returns>
        private bool ActualizarCronograma(List<CronogramaDto> listaCronogramaDto, decimal proId)
        {
            bool resultado = false;
            List<AppCronograma> listaCronogramaModel;
            try
            {
                listaCronogramaModel = (List<AppCronograma>)_appCronogramaRepositor.Get(p => p.ProId == proId);
                _appCronogramaRepositor.DeleteAll(listaCronogramaModel);
                if (listaCronogramaDto.Count > 0)
                {
                    listaCronogramaModel.Clear();
                    listaCronogramaModel = _mapper.Map<List<AppCronograma>>(listaCronogramaDto);
                    int resUpdate = _appCronogramaRepositor.Create(listaCronogramaModel);
                    if (resUpdate > 0)
                    {
                        InfoLog($"Cronograma del proyecto update succeeded: {JsonSerializer.Serialize(listaCronogramaModel, SerializerOptions.options)}");
                        resultado = true;
                    }
                    else
                    {
                        InfoLog($"Cronograma del proyecto update failed: {JsonSerializer.Serialize(listaCronogramaModel, SerializerOptions.options)}");
                    }
                }
                else
                {
                    InfoLog($"Cronograma update: No hay cronograma que actualizar.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar temas del proyecto {ex.Message}");
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar componentes del proyecto
        /// </summary>
        /// <param name="componentes"></param>
        /// <returns>Estado del actualización del componente del proyecto</returns>
        private bool ActualizarComponentes(ComponentesDto componenteDto)
        {
            bool resultado;
            AppComponentes componenteModel;
            try
            {
                componenteModel = _appComponentesRepositor.Get(p => p.ProId == componenteDto.ProId).FirstOrDefault();
                _appComponentesRepositor.Delete(componenteModel);
                if (componenteDto != null)
                {
                    componenteModel = null;
                    componenteModel = _mapper.Map<AppComponentes>(componenteDto);
                    int resCreate = _appComponentesRepositor.Create(componenteModel);

                    if (resCreate > 0)
                    {
                        InfoLog($"Componente del proyecto update succeeded: {JsonSerializer.Serialize(componenteModel, SerializerOptions.options)}");
                        resultado = true;
                    }
                    else
                    {
                        InfoLog($"Componente del proyecto update failed: {JsonSerializer.Serialize(componenteModel, SerializerOptions.options)}");
                    }
                }
                else
                {
                    InfoLog($"Componente del proyecto update: No hay temas que actualizar.");
                    return true;
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Actualizar actividades obligatorias del proyecto
        /// </summary>
        /// <param name="PAODto"></param>
        /// <returns></returns>
        private bool ActualizarProyectoActividadObligatoria(ProyectoActividadesObligatoriasDto PAODto)
        {
            bool resultado;
            AppProyectoActividadesObligatorias PAOModel;
            try
            {
                PAOModel = _mapper.Map<AppProyectoActividadesObligatorias>(PAODto);
                int resUpdate = _appProyectoActividadesObligatoriasRepositor.Update(PAOModel);
                if (resUpdate > 0)
                {
                    InfoLog($"Actividades obligatorias del proyecto update succeeded: {JsonSerializer.Serialize(PAOModel, SerializerOptions.options)}");
                    resultado = true;
                }
                else
                {
                    InfoLog($"Actividades obligatorias del proyecto update: No hay temas que actualizar.");
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
        
        /// <summary>
        /// Actualizar valores indicadores del proyecto
        /// </summary>
        /// <param name="valoresIndicadorDto"></param>
        /// <param name="proId"></param>
        /// <returns></returns>
        private bool ActualizarValoresIndicador(List<ValoresIndicadorDto> valoresIndicadorDto, decimal proId)
        {
            bool resultado = false;
            List<AppValoresIndicador> listaValoresIndicadorModel;
            try
            {
                listaValoresIndicadorModel = (List<AppValoresIndicador>)_appValoresIndicadorRepositor.Get(p => p.ProId == proId);
                _appValoresIndicadorRepositor.DeleteAll(listaValoresIndicadorModel);
                if ( valoresIndicadorDto.Count > 0)
                {
                    listaValoresIndicadorModel.Clear();
                    listaValoresIndicadorModel = _mapper.Map<List<AppValoresIndicador>>(valoresIndicadorDto);
                    int resUpdate = _appValoresIndicadorRepositor.Create(listaValoresIndicadorModel);
                    if (resUpdate > 0)
                    {
                        InfoLog($"Cronograma del proyecto update succeeded: {JsonSerializer.Serialize(listaValoresIndicadorModel, SerializerOptions.options)}");
                        resultado = true;
                    }
                    else
                    {
                        InfoLog($"Cronograma del proyecto update failed: {JsonSerializer.Serialize(listaValoresIndicadorModel, SerializerOptions.options)}");
                    }
                }
                else
                {
                    InfoLog($"Cronograma update: No hay cronograma que actualizar.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar temas del proyecto {ex.Message}");
            }
            return resultado;
        }
       
        public bool ActualizarValoresIndicadorLineaCategoriaMunicipio(List<ValoresIndicadorLineaCategoriaMunicipioDto> listaVILCMDto, decimal proId)
        {
            bool resultado = false;
            List<AppValoresIndicadorLineaCategoriaMunicipio> listaVILCMModel;
            try
            {
                listaVILCMModel = (List<AppValoresIndicadorLineaCategoriaMunicipio>)_appValoresIndicadorLineaCategoriaRepositor.Get(p => p.ProId == proId);
                _appValoresIndicadorLineaCategoriaRepositor.DeleteAll(listaVILCMModel);
                if (listaVILCMDto.Count > 0)
                {
                    listaVILCMModel.Clear();
                    listaVILCMModel = _mapper.Map<List<AppValoresIndicadorLineaCategoriaMunicipio>>(listaVILCMDto);
                    int resUpdate = _appValoresIndicadorLineaCategoriaRepositor.Create(listaVILCMModel);
                    if (resUpdate > 0)
                    {
                        InfoLog($"Cronograma del proyecto update succeeded: {JsonSerializer.Serialize(listaVILCMModel, SerializerOptions.options)}");
                        resultado = true;
                    }
                    else
                    {
                        InfoLog($"Cronograma del proyecto update failed: {JsonSerializer.Serialize(listaVILCMModel, SerializerOptions.options)}");
                    }
                }
                else
                {
                    InfoLog($"Cronograma update: No hay cronograma que actualizar.");
                    return true;
                }

            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar temas del proyecto {ex.Message}");
            }
            return resultado;
        }

        #endregion

        #region Crear

        /// <summary>
        /// Recibe la información diligenciada en el formulario A y realiza la operación de actualización del proponente y
        /// de creación del proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto CrearFormularioA(FormularioADto formularioA)
        {
            RespuestaDto respuesta = new RespuestaDto();
            
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (ActualizarProponente(formularioA.Proponente))
                    {
                        if (!ExisteProyectoProponente(formularioA.Proponente.ProId))
                        {
                            if (CrearProyecto(formularioA.Proyecto))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Formulario A creado correctamente!";
                                respuesta.Id = formularioA.Proyecto.ProId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al crear el proyecto!";
                            }
                        }
                        else
                        {
                            if (ActualizarProyecto(formularioA.Proyecto))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Formulario A actualizado correctamente!";
                                respuesta.Id = formularioA.Proyecto.ProId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al actualizar el proyecto!";
                            }
                        }
                    }
                    else
                    {
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Error al actualizar el proponente!";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el usuario. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el usuario.";
                }
            }
            return respuesta;
        }


        /// <summary>
        /// Recibe la información diligenciada en el formulario A y realiza la operación de actualización del proponente y
        /// de creación del proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto CrearProponente(ProponenteDto proponente)
        {
            RespuestaDto respuesta = new RespuestaDto();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    if (!ExisteProyectoProponente(proponente.ProId))
                    {
                        if (CrearProponentes(proponente))
                        {
                            respuesta.Resultado = true;
                            respuesta.Mensaje = "Proponente creado correctamente!";
                            respuesta.Id = proponente.ProId.ToString();
                            transaction.Commit();
                        }
                        else
                        {
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al crear el proyecto!";
                        }
                    }
                    else
                    {
                        if (ActualizarProponente(proponente))
                        {
                            respuesta.Resultado = true;
                            respuesta.Mensaje = "Proponente actualizado correctamente!";
                            respuesta.Id = proponente.ProId.ToString();
                            transaction.Commit();
                        }
                        else
                        {
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al actualizar el proyecto!";
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el usuario. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el usuario.";
                }
            }
            return respuesta;
        }


        /// <summary>
        /// Recibe la información diligenciada en el formulario A y realiza la operación de actualización del proponente y
        /// de creación del proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto Crearappbeneficiarios(AppBeneficiariosDto appBeneficiarios)
        {
            RespuestaDto respuesta = new RespuestaDto();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (!ExisteBeneficiario(appBeneficiarios.ProId.Value))
                    {
                        if (CrearBeneficiarios(appBeneficiarios))
                        {
                            respuesta.Resultado = true;
                            respuesta.Mensaje = "Beneficiarios creados correctamente!";
                            respuesta.Id = appBeneficiarios.BenId.ToString();
                            transaction.Commit();
                        }
                        else
                        {
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al crear los beneficiarios!";
                        }
                    }
                    else
                    {
                        if (ActualizarBeneficiario(appBeneficiarios))
                        {
                            respuesta.Resultado = true;
                            respuesta.Mensaje = "Formulario A actualizado correctamente!";
                            respuesta.Id = appBeneficiarios.BenId.ToString();
                            transaction.Commit();
                        }
                        else
                        {
                            respuesta.Resultado = false;
                            respuesta.Mensaje = "Error al actualizar el proyecto!";
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el beneficiario. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el beneficiario.";
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Crear componente del proyecto
        /// </summary>
        /// <param name="componentes">Información del componente</param>
        /// <returns>Estado de crear componente del proyecto</returns>
        private bool CrearComponentes(ComponentesDto componenteDto)
        {
            bool resultado;
            AppComponentes componenteModel;
            try
            {
                componenteModel = _mapper.Map<AppComponentes>(componenteDto);
                _appComponentesRepositor.Create(componenteModel);
                InfoLog($"Componente del proyecto create succeeded: {JsonSerializer.Serialize(componenteModel, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el componente del proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Crear un proyecto 
        /// </summary>
        /// <param name="proyecto">Información del proyecto</param>
        /// <returns>Estado de crear un proyecto</returns>
        private bool CrearProyecto(ProyectoDto proyecto)
        {
            bool resultado;
            try
            {
                var _proyecto = _mapper.Map<AppProyectos>(proyecto);
                _proyecto.VigId = GetIdVigencia();
                var id = _appProyectosRepositor.Create(_proyecto);
                proyecto.ProId = id;
                InfoLog($"Proyecto insert succeeded: {JsonSerializer.Serialize(proyecto, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al insertar el proyecto {ex.Message}");
                resultado = false;
            }

            return resultado;
        }

        /// <summary>
        /// Crear un proyecto 
        /// </summary>
        /// <param name="proyecto">Información del proyecto</param>
        /// <returns>Estado de crear un proyecto</returns>
        private bool CrearProponentes(ProponenteDto proponente)
        {
            bool resultado;
            try
            {
                var _proponente = _mapper.Map<AppProponentes>(proponente);
                int idProponent;
                idProponent = (int)_appProponentesRepositor.Create(_proponente);
                proponente.ProId = idProponent;
                InfoLog($"Proponente insert succeeded: {JsonSerializer.Serialize(proponente, SerializerOptions.options)}");
                resultado = true;

            }
            catch (Exception ex)
            {
                DebugLog($"Error al insertar el proyecto {ex.Message}");
                resultado = false;
            }

            return resultado;
        }

        /// <summary>
        /// Crear actividades oblogatorias del proyecto
        /// </summary>
        /// <param name="PAODto">Información de la actividad obligatoria</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        private bool CrearProyectoActividadesObligatorias(ProyectoActividadesObligatoriasDto PAODto)
        {
            bool resultado;
            try
            {
                AppProyectoActividadesObligatorias PAOModel = _mapper.Map<AppProyectoActividadesObligatorias>(PAODto);
                _appProyectoActividadesObligatoriasRepositor.Create(PAOModel);
                DebugLog($"Actividad obligatoria del proyecto insert succeeded: {JsonSerializer.Serialize(PAOModel, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                InfoLog($"Error al insertar la actividad obligatoria del proyecto {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        /// <summary>
        /// Crear Beneficiarios
        /// </summary>
        /// <param name="componentes">Información del componente</param>
        /// <returns>Estado de crear componente del proyecto</returns>
        private bool CrearBeneficiarios(AppBeneficiariosDto appBeneficiarios)
        {
            bool resultado;
            try
            {
                var _beneficiarios = _mapper.Map<AppBeneficiarios>(appBeneficiarios);
                
                var id = _appBeneficiarios.Create(_beneficiarios);
                appBeneficiarios.BenId =  id;
                InfoLog($"Beneficiarios insert succeeded: {JsonSerializer.Serialize(appBeneficiarios, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al insertar los beneficiarios {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        #endregion

        #region Existe

        /// <summary>
        /// Valida si el componente que ya posee un proyecto
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Retorna true si existe el componente y false en caso contrario</returns>
        private bool ExisteComponente(decimal pro_id)
        {
            return _appComponentesRepositor.Get(p => p.ProId == pro_id).FirstOrDefault() != null;
        }

        /// <summary>
        /// Valida si el proponente ya posee un proyecto
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Retorna true si existe el proyecto y false en caso contrario</returns>
        private bool ExisteProyectoProponente(decimal pro_id)
        {
            return _appProyectosRepositor.Get(p => p.ProIdProponente == pro_id).FirstOrDefault() != null;
        }

        /// <summary>
        /// Valida si los datos beneficiarios existen
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Retorna true si existe el proyecto y false en caso contrario</returns>
        private bool ExisteBeneficiario(decimal pro_id)
        {
            return _appBeneficiarios.Get(p => p.ProId == pro_id).FirstOrDefault() != null;
        }

        /// <summary>
        /// Valida si el proponente ya posee un proyecto
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Retorna true si existe el proyecto y false en caso contrario</returns>
        private bool ExisteProyecto(decimal pro_id)
        {
            return _appProyectosRepositor.Get(p => p.ProId == pro_id).FirstOrDefault() != null;
        }

        /// <summary>
        /// Existe proyecto actividades obligatorias
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        private bool ExisteProyectoActividadesObligatorias(decimal pro_id)
        {
            return _appProyectoActividadesObligatoriasRepositor.Get(p => p.ProId == pro_id).FirstOrDefault() != null;
        }

        #endregion

        #region Consultar

        /// <summary>
        /// Consultar un proponente dado el ID de la tabla
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Información del proponente</returns>
        public ProponenteDto GetProponenteById(decimal pro_id)
        {
            var proponente = _mapper.Map<ProponenteDto>(_appProponentesRepositor.Get(p => p.ProId == pro_id).FirstOrDefault());
            foreach (var item in proponente.AppProyectos)
            {
                item.ProEstadoNombre = CalcularEstado(item.ProEstado);
                item.LineaNombre = GetLinea(item.LinId);
            }
            return proponente;
        }

        /// <summary>
        /// Consultar los proyectos de un proponente
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Listado de proyectos de un proponente</returns>
        public Collection<ProyectoDto> GetProyectosByProponente(decimal pro_id)
        {
            var proyectos = _mapper.Map<Collection<ProyectoDto>>(_appProyectosRepositor.Get(p => p.ProIdProponente == pro_id));
            foreach (var item in proyectos)
            {
                item.ProEstadoNombre = CalcularEstado(item.ProEstado);
            }
            return proyectos;
        }

        /// <summary>
        /// Consultar la informacion de los beneficiados
        /// </summary>
        /// <param name="pro_id">Id del proponente</param>
        /// <returns>Listado de proyectos de un proponente</returns>
        public AppBeneficiariosDto GetBeneficiados(decimal pro_id)
        {
            AppBeneficiariosDto ben = _mapper.Map<AppBeneficiariosDto>(_appBeneficiarios.Get(p => p.ProId == pro_id).FirstOrDefault());
            if (ben == null)
                ben = new AppBeneficiariosDto();
            ben.BenCaracteristicasPoblacion = ben.BenCaracteristicasPoblacion == null ? string.Empty : ben.BenCaracteristicasPoblacion;
            ben.BenPersonasAsistentes = ben.BenPersonasAsistentes == null ? 0 : ben.BenPersonasAsistentes;
            ben.BenNumeroArtistasNacionales = ben.BenNumeroArtistasNacionales == null ? 0 : ben.BenNumeroArtistasNacionales;
            ben.BeeTotalBeneficiados = ben.BeeTotalBeneficiados == null ? 0 : ben.BeeTotalBeneficiados;
            ben.BenPersonasLogistica = ben.BenPersonasLogistica == null ? 0 : ben.BenPersonasLogistica;
            ben.BenOtrasPersonasBeneficiadasDescripcion = ben.BenOtrasPersonasBeneficiadasDescripcion == null ? string.Empty : ben.BenOtrasPersonasBeneficiadasDescripcion;
            return ben;
        }

        /// <summary>
        /// Consultar proyecto dado el Id
        /// </summary>
        /// <param name="pro_id">Id del proyecto</param>
        /// <returns>Proyecto encontrado por el Id</returns>
        public ProyectoDto GetProyectoById(decimal pro_id)
        {
            return _mapper.Map<ProyectoDto>(_appProyectosRepositor.Get(p => p.ProId == pro_id).FirstOrDefault());
        }

        /// <summary>
        /// Consultar componente por id del proyecto
        /// </summary>
        /// <param name="pro_id">Id del proyecto</param>
        /// <returns>Componente encontrado por el Id</returns>
        public ComponentesDto ComponenteByProyecto(decimal pro_id)
        {
            return _mapper.Map<ComponentesDto>(_appComponentesRepositor.Get(p => p.ProId == pro_id).FirstOrDefault());
        }

        /// <summary>
        /// Consultar temas por proyecto
        /// </summary>
        /// <param name="pro_id">Id del proyecto</param>
        /// <returns>Temas asociados al proyecto</returns>
        public Collection<TemasProyectosDto> GetTemasByProyecto(decimal pro_id)
        {
            return _mapper.Map<Collection<TemasProyectosDto>>(_appTemasProyectosRepositor.Get(p => p.ProId == pro_id));
        }

        /// <summary>
        /// Consultar cronograma del proyecto
        /// </summary>
        /// <param name="pro_id">Id del proyecto</param>
        /// <returns>Cronograma del proyecto/returns>
        public Collection<CronogramaDto> GetCronograma(decimal pro_id)
        {
            return _mapper.Map<Collection<CronogramaDto>>(_appCronogramaRepositor.Get(p => p.ProId == pro_id));
        }

        /// <summary>
        /// Consultar actividades obligatorias del proyecto
        /// </summary>
        /// <param name="pro_id">Id del proyecto</param>
        /// <returns>Lista de actividades del proyecto/returns>
        public Collection<ProyectoActividadesObligatoriasDto> GetActividadesObligatoriasByProyecto(decimal pro_id)
        {
            return _mapper.Map<Collection<ProyectoActividadesObligatoriasDto>>(_appProyectoActividadesObligatoriasRepositor.Get(p => p.ProId == pro_id));
        }
       
        /// <summary>
        /// Consultar valores indicador por proyecto
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        public Collection<ValoresIndicadorDto> GetValoresIndicadorByProyecto( decimal pro_id)
        {
            return _mapper.Map<Collection<ValoresIndicadorDto>>(_appValoresIndicadorRepositor.Get(vi => vi.ProId == pro_id));
        }

        /// <summary>
        /// Consulta valores indicador (incetivos) por categoria del municipio
        /// </summary>
        /// <param name="pro_id"></param>
        /// <returns></returns>
        public Collection<ValoresIndicadorLineaCategoriaMunicipioDto> GetValoresIndicadorLineaCategoriaMunicipio(decimal pro_id)
        {
            return _mapper.Map<Collection<ValoresIndicadorLineaCategoriaMunicipioDto>>(_appValoresIndicadorLineaCategoriaRepositor.Get(vi => vi.ProId == pro_id));
        }

        /// <summary>
        /// Obtener el IdVigencia para crear el proyecto y asociarlo
        /// </summary>
        /// <returns></returns>
        private decimal GetIdVigencia()
        {
            var vigencia = _vigenciasRepository.Get(p => p.VigEstado.Equals("A")).FirstOrDefault();
            return vigencia != null ? vigencia.VigId : 0;
        }

        #endregion
        #region Seguimiento
        /// <summary>
        /// Recibe la información diligenciada en el formulario A y realiza la operación de actualización del proponente y
        /// de creación del proyecto
        /// </summary>
        /// <param name="formularioA">Información del proponente y proyecto</param>
        /// <returns>Resultado de la operación</returns>
        public RespuestaDto CrearSeguimiento(ConSeguimientosDto seguimiento)
        {
            RespuestaDto respuesta = new RespuestaDto();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    
                        if (!ExisteSeguimiento(seguimiento.ProId.Value, seguimiento.ActId.Value))
                        {
                            if (CrearSeguimientos(seguimiento))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Formulario A creado correctamente!";
                                respuesta.Id = seguimiento.ProId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al crear el proyecto!";
                            }
                        }
                        else
                        {
                            if (ActualizarSeguimiento(seguimiento))
                            {
                                respuesta.Resultado = true;
                                respuesta.Mensaje = "Se actualizó correctamente!";
                                respuesta.Id = seguimiento.SegId.ToString();
                                transaction.Commit();
                            }
                            else
                            {
                                respuesta.Resultado = false;
                                respuesta.Mensaje = "Error al actualizar el proyecto!";
                            }
                        }
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el usuario. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el usuario.";
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Actualizar un proponente
        /// </summary>
        /// <param name="proponente">Información del proponente</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        private bool ActualizarSeguimiento(ConSeguimientosDto seguimiento)
        {
            bool resultado;
            try
            {
                var _seguimiento = _mapper.Map<ConSeguimientos>(seguimiento);
                _conseguimientos.Update(_seguimiento);
                InfoLog($"Seguimiento update succeeded: {JsonSerializer.Serialize(seguimiento, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al actualizar el seguimiento {ex.Message}");
                resultado = false;
            }
            return resultado;
        }

        private bool ExisteSeguimiento(decimal pro_id, decimal act_id)
        {
            return _conseguimientos.Get(p => p.ProId == pro_id && p.ActId == act_id).FirstOrDefault() != null;
        }

        /// <summary>
        /// Crear un proyecto 
        /// </summary>
        /// <param name="proyecto">Información del proyecto</param>
        /// <returns>Estado de crear un proyecto</returns>
        private bool CrearSeguimientos(ConSeguimientosDto seguimiento)
        {
            bool resultado;
            try
            {
                //seguimiento.SegId = 0;
                var _seguimiento = _mapper.Map<ConSeguimientos>(seguimiento);
                var id = _conseguimientos.Create(_seguimiento);
                seguimiento.ProId = id;
                InfoLog($"Seguimiento insert succeeded: {JsonSerializer.Serialize(seguimiento, SerializerOptions.options)}");
                resultado = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al insertar el seguimiento {ex.Message}");
                resultado = false;
            }

            return resultado;
        }

        #endregion
        #region Utilidades

        /// <summary>
        /// Calcular el estado del proyecto
        /// </summary>
        /// <param name="proEstado">Código del estado</param>
        /// <returns>Estado legible, no en código</returns>
        private string CalcularEstado(string proEstado)
        {
            switch (proEstado)
            {
                case "D":
                    return "En digitación";
                case "E":
                    return "Enviado";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Obtener el nombre del la línea
        /// </summary>
        /// <param name="idLinea">ID Linea</param>
        /// <returns>Nombre de la linea</returns>
        private string GetLinea(decimal? idLinea)
        {
            if (idLinea != null)
                return _lineasRepository.Get(p => p.LinId == Convert.ToDecimal(idLinea)).FirstOrDefault().LinNombre;
            else
                return string.Empty;
        }

        #endregion

    }
}