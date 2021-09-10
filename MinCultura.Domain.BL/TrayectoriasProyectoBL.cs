using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class TrayectoriasProyectoBL : BaseBL, ITrayectoriasProyectoBL
    {

        private readonly ConcertacionContext _context;
        private readonly ITrayectoriaProyectoRepository<TrayectoriaProyecto> _trayectoriaProyectosRepositor;
        private readonly IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> _appPresupuestoDetalle;
        private readonly IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> _appTipoDocumentosValores;
        private readonly BaseRepository<Trayectoria> _trayectoriaRepository;
        private readonly IMapper _mapper;

        public TrayectoriasProyectoBL(
            ConcertacionContext context,
            ITrayectoriaProyectoRepository<TrayectoriaProyecto> trayectoriaProyectosRepositor,
            IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> appPresupuestoDetalle,
            IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> appTipoDocumentosValores,
            BaseRepository<Trayectoria> trayectoriaRepository,

            IMapper mapper
            )
        {
            _context = context;
            _trayectoriaProyectosRepositor = trayectoriaProyectosRepositor;
            _appPresupuestoDetalle = appPresupuestoDetalle;
            _trayectoriaRepository = trayectoriaRepository;
            _appTipoDocumentosValores = appTipoDocumentosValores;
            _mapper = mapper;
        }

        /// <summary>
        /// Crear la trayectoria del proyecto
        /// </summary>
        /// <param name="trayectoriaProyectos">Información de la trayectoria proyecto</param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        public RespuestaDto CrearTrayectorias(List<TrayectoriaProyectoDTO> trayectoriaProyectos)
        {
            RespuestaDto respuesta = new RespuestaDto();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    decimal proId = trayectoriaProyectos.FirstOrDefault().PRO_ID;
                    if (DeleteAllTrayectoria(proId))
                    {
                        _trayectoriaProyectosRepositor.Create(_mapper.Map<List<TrayectoriaProyecto>>(trayectoriaProyectos));
                        transaction.Commit();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = "Trayectoria creada correctamente!";
                    }
                    else
                    {
                        transaction.Rollback();
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Error al crear la trayectoria!";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear la trayectoria del proyecto. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear la trayectoria del proyecto.";
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Crear el presupuesto del proyecto 
        /// </summary>
        /// <param name="presupuestoProyecto">Información del presupuesto del proyecto </param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        public RespuestaDto CrearPresupuesto(List<AppPresupuestoDetalleDto> presupuestoProyecto)
        {
            RespuestaDto respuesta = new RespuestaDto();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    decimal? proId = presupuestoProyecto.FirstOrDefault().ProId;
                    if (DeleteAllPresupuesto(Convert.ToDecimal(proId)))
                    {
                        _appPresupuestoDetalle.Create(_mapper.Map<List<AppPresupuestoDetalle>>(presupuestoProyecto));
                        transaction.Commit();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = "Presupuesto creado correctamente!";
                    }
                    else
                    {
                        transaction.Rollback();
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Error al crear el Presupuesto!";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el Presupuesto del proyecto. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el Presupuesto del proyecto.";
                }
            }
            return respuesta;
        }



        public Collection<TrayectoriaProyectoDTO> GetTrayectoriasProyecto(decimal idVigencia, decimal idProyecto)
        {
            Collection<TrayectoriaProyectoDTO> listTrayecotiras = new Collection<TrayectoriaProyectoDTO>();
            Collection<TrayectoriaProyectoDTO> consulta1 = _mapper.Map<Collection<TrayectoriaProyectoDTO>>(_trayectoriaProyectosRepositor.Get(x => x.PRO_ID == idProyecto));
            Collection<TrayectoriasDTO>  consulta2 = _mapper.Map<Collection<TrayectoriasDTO>>(_trayectoriaRepository.Get(y => y.VIG_ID == idVigencia));


            var resultado = from ru in consulta1
                            join ti in consulta2 on ru.TRA_ID equals ti.TRA_ID
                            select new
                            {
                                ru.TPR_ID, ru.TPR_RESPUESTA_TRAYECTORIA, ru.TRA_ID, ru.PRO_ID, ti.TTR_ID

                            };

            TrayectoriaProyectoDTO trayectoria = null;

            foreach (var item in resultado)
            {
                trayectoria = new TrayectoriaProyectoDTO
                {
                    TPR_ID = item.TPR_ID,
                    TPR_RESPUESTA_TRAYECTORIA = item.TPR_RESPUESTA_TRAYECTORIA,
                    TRA_ID = item.TRA_ID,
                    PRO_ID = item.PRO_ID,
                    TTR_ID = item.TTR_ID
                };
                listTrayecotiras.Add(trayectoria);
            }
            return listTrayecotiras;
        }

        private bool DeleteAllTrayectoria(decimal IdProyecto)
        {
            bool result;
            try
            {
                _trayectoriaProyectosRepositor.DeleteAll(IdProyecto);
                result = true; 
            }
            catch (Exception ex)
            {
                DebugLog($"Error al eliminar la trayectoria del proyecto. Error: {ex.Message}");
                result = false;
            }
            return result;
            
        }

        private bool DeleteAllPresupuesto(decimal IdProyecto)
        {
            bool result;
            try
            {
                _appPresupuestoDetalle.DeleteAll(IdProyecto);
                result = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al eliminar el presupuesto del proyecto. Error: {ex.Message}");
                result = false;
            }
            return result;
        }

        private bool DeleteAllTipoDocumentoValores(decimal IdProyecto, decimal IdTdo)
        {
            bool result;
            try
            {
                _appTipoDocumentosValores.DeleteAll(IdProyecto, IdTdo);
                result = true;
            }
            catch (Exception ex)
            {
                DebugLog($"Error al eliminar el documento. Error: {ex.Message}");
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Crear el presupuesto del proyecto 
        /// </summary>
        /// <param name="presupuestoProyecto">Información del presupuesto del proyecto </param>
        /// <returns>True si la operación es correcta y false en caso contrario</returns>
        public RespuestaDto CrearAppTipoDocumentosValores(AppTipoDocumentosValoresDto appTipoDocumentosValores)
        {
            RespuestaDto respuesta = new RespuestaDto();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    decimal? proId = appTipoDocumentosValores.ProId;
                    decimal? tdoId = appTipoDocumentosValores.TdoId;
                    if (DeleteAllTipoDocumentoValores(Convert.ToDecimal(proId), Convert.ToDecimal(tdoId)))
                    {
                        _appTipoDocumentosValores.Create(_mapper.Map<AppTipoDocumentosValores>(appTipoDocumentosValores));
                        transaction.Commit();
                        respuesta.Resultado = true;
                        respuesta.Mensaje = "Documento creado correctamente!";
                    }
                    else
                    {
                        transaction.Rollback();
                        respuesta.Resultado = false;
                        respuesta.Mensaje = "Error al crear el Documento!";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el Documento del proyecto. Error: {ex.Message}");
                    respuesta.Resultado = false;
                    respuesta.Mensaje = "Error al crear el Documento del proyecto.";
                }
            }
            return respuesta;
        }


    }
}
