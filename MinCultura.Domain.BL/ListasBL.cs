using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    public class ListasBL : BaseBL, IListasBL
    {
        private readonly BaseRepository<AppVigencias> _vigenciasRepository;
        private readonly BaseRepository<AppTiposEntidades> _tiposEntidadesRepository;
        private readonly BaseRepository<AppLineas> _lineasRepository;
        private readonly IAppIndicadoresLineaRepository<AppIndicadoresLinea> _indicadoresLineaRepository;
        private readonly IAppIndicadoresRepository<AppIndicadores> _indicadoresRepository;
        private readonly BaseRepository<AppAreas> _areasRepository;
        private readonly BaseRepository<AppTemas> _temasRepository;
        private readonly BaseRepository<BasEntidadesFinancieras> _entidadesFinancierasRepository;
        private readonly IActividadesObligatoriasRepository<AppActividadesObligatorias> _actividadesObligatoriasRepositor;
        private readonly BaseRepository<Trayectoria> _trayectoriaRepository;
        private readonly BaseRepository<TipoTrayectoria> _tipotrayectoriaRepository;
        private readonly BaseRepository<AppPresupuestoDetalleTipoTitulos> _appPresupuestoDetalleTipoTitulos;
        private readonly BaseRepository<AppPresupuestoDetalleTipo> _appPresupuestoDetalleTipo;
        private readonly IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> _appPresupuestoDetalle;
        private readonly BaseRepository<PresupuestoParametrizacionLineasTope> _presupuestoParametrizacionLineasTope;
        private readonly IAppProyectosRepository<AppProyectos> _appProyectosRepositor;
        private readonly IAppProponentesRepository<AppProponentes> _appProponentesRepositor;
        private readonly BaseRepository<AppDocumentosTipoEntidades> _appDocumentosTipoEntidades;
        private readonly BaseRepository<AppTipoDocumentos> _appTipoDocumentos;
        private readonly IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> _appTipoDocumentosValores;
        private readonly IResultadoRepository<Resultado> _resultado;
        private readonly IRequisitosRepository<AppRequisitos> _appRequisitosRepositor;

        private readonly BaseRepository<ConZonas> _conZonasRepositor;
        private readonly BaseRepository<ConEstados> _conEstadosRepositor;
        private readonly BaseRepository<ConActividades> _conActividades;



        private readonly IIndicadorLineaCategoriaMunicipioRepository<AppIndicadorLineaCategoriaMunicipio> _appIndicadorLineaCategoriaMunicipioRepositor;
        private readonly IMapper _mapper;

        public ListasBL(BaseRepository<AppVigencias> vigenciasRepository,
            BaseRepository<AppTiposEntidades> tiposEntidadesRepository,
            BaseRepository<AppLineas> lineasRepository,
            IAppIndicadoresLineaRepository<AppIndicadoresLinea> indicadoresLineaRespository,
            IAppIndicadoresRepository<AppIndicadores> indicadoresRespository,
            BaseRepository<BasEntidadesFinancieras> entidadesFinancierasRepository,
            BaseRepository<AppAreas> areasRepository,
            BaseRepository<AppTemas> temasreprository,
            IActividadesObligatoriasRepository<AppActividadesObligatorias> actividadesObligatorias,
            BaseRepository<Trayectoria> trayectoriaRepository,
            BaseRepository<TipoTrayectoria> tipotrayectoriaRepository,
            BaseRepository<AppPresupuestoDetalleTipoTitulos> appPresupuestoDetalleTipoTitulos,
            BaseRepository<AppPresupuestoDetalleTipo> appPresupuestoDetalleTipo,
            IAppPresupuestoDetalleRepository<AppPresupuestoDetalle> appPresupuestoDetalle,
            BaseRepository<PresupuestoParametrizacionLineasTope> presupuestoParametrizacionLineasTope,
            IAppProyectosRepository<AppProyectos> appProyectosRepositor,
            IAppProponentesRepository<AppProponentes> appProponentesRepositor,
            BaseRepository<AppDocumentosTipoEntidades> appDocumentosTipoEntidades,
            BaseRepository<AppTipoDocumentos> appTipoDocumentos,
            BaseRepository<ConZonas> conZonasRepositor,
            IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores> appTipoDocumentosValores,
            IIndicadorLineaCategoriaMunicipioRepository<AppIndicadorLineaCategoriaMunicipio> appIndicadorLineaCategoriaMunicipio,
            IResultadoRepository<Resultado> resultado,
            IRequisitosRepository<AppRequisitos> appRequisitosRepositor,
            BaseRepository<ConEstados> conEstadosRepositor,
            BaseRepository<ConActividades> ConActividadesRepositor,

        IMapper mapper)
        {
            _vigenciasRepository = vigenciasRepository;
            _tiposEntidadesRepository = tiposEntidadesRepository;
            _lineasRepository = lineasRepository;
            _indicadoresLineaRepository = indicadoresLineaRespository;
            _indicadoresRepository = indicadoresRespository;
            _entidadesFinancierasRepository = entidadesFinancierasRepository;
            _areasRepository = areasRepository;
            _temasRepository = temasreprository;
            _actividadesObligatoriasRepositor = actividadesObligatorias;
            _trayectoriaRepository = trayectoriaRepository;
            _tipotrayectoriaRepository = tipotrayectoriaRepository;
            _appPresupuestoDetalleTipoTitulos = appPresupuestoDetalleTipoTitulos;
            _appPresupuestoDetalleTipo = appPresupuestoDetalleTipo;
            _appPresupuestoDetalle = appPresupuestoDetalle;
            _presupuestoParametrizacionLineasTope = presupuestoParametrizacionLineasTope;
            _appProyectosRepositor = appProyectosRepositor;
            _appProponentesRepositor = appProponentesRepositor;
            _appDocumentosTipoEntidades = appDocumentosTipoEntidades;
            _appTipoDocumentos = appTipoDocumentos;
            _appTipoDocumentosValores = appTipoDocumentosValores;
            _appIndicadorLineaCategoriaMunicipioRepositor = appIndicadorLineaCategoriaMunicipio;
            _resultado = resultado;
            _conZonasRepositor = conZonasRepositor;
            _conEstadosRepositor = conEstadosRepositor;
            _appRequisitosRepositor = appRequisitosRepositor;
            _conActividades = ConActividadesRepositor;
            _mapper = mapper;
        }
        
        public Collection<AppVigenciasDto> GetAppVigencias()
        {
            return _mapper.Map<Collection<AppVigenciasDto>>(_vigenciasRepository.Get());
        }

        public Collection<AppTiposEntidadesDto> GetTiposEntidades(decimal idVigencia)
        {
            return _mapper.Map<Collection<AppTiposEntidadesDto>>(_tiposEntidadesRepository.Get(p => p.VigId.Equals(idVigencia)));
        }

        public Collection<LineaDto> GetLineas(decimal idVigencia)
        {
            return _mapper.Map<Collection<LineaDto>>(_lineasRepository.Get(p => p.VigId.Equals(idVigencia)));
        }

        public Collection<ConActividadesDto> GetActividades()
        {
            return _mapper.Map<Collection<ConActividadesDto>>(_conActividades.Get());
        }

        public Collection<IndicadoresLineaDto> GetIndicadoresByLinea(decimal idLinea)
        {
            //Collection<AppIndicadores> lstIndicadores = new Collection<AppIndicadores>();
            return _mapper.Map<Collection<IndicadoresLineaDto>>(_indicadoresLineaRepository.Get(p => p.LinId.Equals(idLinea)));
            //Collection<IndicadoresLineaDto> lstIndicadoresLinea =_mapper.Map<Collection<IndicadoresLineaDto>>( _indicadoresLineaRepository.Get(p => p.LinId.Equals(idLinea)));
            //foreach (var indicadorLinea in lstIndicadoresLinea)
            //{
            //    AppIndicadores indicador = _indicadoresRepository.Get(p => p.IndId.Equals(indicadorLinea.IndId)).FirstOrDefault();
            //    lstIndicadores.Add(indicador);
            //}
            //return _mapper.Map<Collection<IndicadoresDto>>(lstIndicadores);
        }


        public Collection<TemasDto> GetTemasByLinea(decimal idLinea)
        {
            Collection<AppTemas> lstTemas = new Collection<AppTemas>();
            Collection<TemasDto> lstTemasLinea = _mapper.Map<Collection<TemasDto>>(_temasRepository.Get(p => p.LinId.Equals(idLinea)));
            foreach (var temaLinea in lstTemasLinea)
            {
                AppTemas tema = _temasRepository.Get(p => p.TemId.Equals(temaLinea.TemId)).FirstOrDefault();
                lstTemas.Add(tema);
            }
            return _mapper.Map<Collection<TemasDto>>(lstTemas);
        }

        public Collection<AreaDto> GetAreas(decimal idVigencia)
        {
            return  _mapper.Map<Collection<AreaDto>>(_areasRepository.Get(p => p.VigId.Equals(idVigencia)));
        }

        public Collection<EntidadesFinancierasDto> GetEntidadesFinancieras()
        {
            return _mapper.Map<Collection<EntidadesFinancierasDto>>(_entidadesFinancierasRepository.Get(p => p.EntVisible.Equals("1")));
        }

        public Collection<ActividadesObligatoriasDto> GetActividadesObligatorias()
        {
            return _mapper.Map<Collection<ActividadesObligatoriasDto>>(_actividadesObligatoriasRepositor.Get());
        }
        public Collection<PresupuestoParametrizacionLineasTopeDto> GetPresupuestoParametrizacionLineasTope(string zonId, decimal lineaId)
        {
            return _mapper.Map<Collection<PresupuestoParametrizacionLineasTopeDto>>(_presupuestoParametrizacionLineasTope.Get(p => p.ZON_ID == zonId && p.LIN_ID == lineaId));
        }

        public Collection<IndicadoresDto> GetIndicadores()
        {
            return _mapper.Map<Collection<IndicadoresDto>>(_indicadoresRepository.Get());
        }


        public Collection<TrayectoriasDTO> GetTrayectorias(decimal idVigencia, int tipoTrayectoria)
        {
            return _mapper.Map<Collection<TrayectoriasDTO>>(_trayectoriaRepository.Get(p => p.VIG_ID == idVigencia && p.TTR_ID == tipoTrayectoria));
        }
        public Collection<TrayectoriasDTO> GetTrayectorias(decimal idVigencia)
        {
            return _mapper.Map<Collection<TrayectoriasDTO>>(_trayectoriaRepository.Get(p => p.VIG_ID == idVigencia ));
        }

        public Collection<TipoTrayectoriasDTO> GetTipoTrayectorias()
        {
            return _mapper.Map<Collection<TipoTrayectoriasDTO>>(_tipotrayectoriaRepository.Get(p => p.TTR_ACTIVO == 1));
        }

        public Collection<AppPresupuestoDetalleTipoTitulosDto> GetAppPresupuestoDetalleTipoTitulos()
        {
            return _mapper.Map<Collection<AppPresupuestoDetalleTipoTitulosDto>>(_appPresupuestoDetalleTipoTitulos.Get());
        }

        public Collection<AppPresupuestoDetalleTipoDto> GetAppPresupuestoDetalleTipo(decimal idVigencia)
        {
            return _mapper.Map<Collection<AppPresupuestoDetalleTipoDto>>(_appPresupuestoDetalleTipo.Get(p => p.VIG_ID == idVigencia));
        }


        public Collection<AppTipoDocumentosDto> GetAppTipoDocumentos()
        {
            return _mapper.Map<Collection<AppTipoDocumentosDto>>(_appTipoDocumentos.Get());
        }
        public Collection<AppDocumentosTipoEntidadesDto> GetAppDocumentosTipoEntidades(int tipId)
        {
            Collection<AppDocumentosTipoEntidadesDto>  consulta1 = _mapper.Map<Collection<AppDocumentosTipoEntidadesDto>>(_appDocumentosTipoEntidades.Get(p => p.TipId == tipId));
            Collection<AppTipoDocumentosDto> consulta2 = _mapper.Map<Collection<AppTipoDocumentosDto>>(_appTipoDocumentos.Get());

            Collection<AppDocumentosTipoEntidadesDto> listaDocumentos = new Collection<AppDocumentosTipoEntidadesDto>();

            var resultado = from ru in consulta1
                            join ti in consulta2 on ru.TdoId equals ti.TdoId
                            select new
                            {
                                TdoId = ru.TdoId,
                                TdoNombre = ti.TdoNombre,
                                TdoObservacion = ti.TdoObservacion,
                                TdoNs = ru.TdoNs,
                                TdoOrden = ru.TdoOrden
                            };


            AppDocumentosTipoEntidadesDto documentos;

            foreach (var item in resultado)
            {
                documentos = new AppDocumentosTipoEntidadesDto
                {
                    TdoId = item.TdoId,
                    TdoNombre = item.TdoNombre,
                    TdoObservacion = item.TdoObservacion,
                    TdoNs = item.TdoNs,
                    TdoOrden = item.TdoOrden
                };



                listaDocumentos.Add(documentos);
            }


            return listaDocumentos;
        }

        public Collection<AppTipoDocumentosValoresDto> GetappTipoDocumentosValores(int idPro)
        {
            ProyectoDto proyecto = _mapper.Map <ProyectoDto>(_appProyectosRepositor.Get(p => p.ProId == idPro).FirstOrDefault());

            ProponenteDto proponente = _mapper.Map<ProponenteDto>(_appProponentesRepositor.Get(n => n.ProId == proyecto.ProIdProponente).FirstOrDefault());

            Collection<AppDocumentosTipoEntidadesDto> consulta1 = GetAppDocumentosTipoEntidades(proponente.TipId.Value);
            Collection<AppTipoDocumentosValoresDto> consulta2 = consulta2 = _mapper.Map<Collection<AppTipoDocumentosValoresDto>>(_appTipoDocumentosValores.Get(m => m.ProId == idPro));
            Collection<AppTipoDocumentosValoresDto> presDetList = new Collection<AppTipoDocumentosValoresDto>();


            var resultado = from ru in consulta1
                            join es in consulta2 on ru.TdoId equals es.TdoId into Documentos
                            from rues in Documentos.DefaultIfEmpty(new AppTipoDocumentosValoresDto()
                            {
                                TdoId = ru.TdoId,
                                TdvNombre = "",
                                TdvNumeroPaginas = 0,
                                TdvRutaAdjunto = "",
                                TdoNombre = ru.TdoNombre,
                                TdoObservaciones = ru.TdoObservacion,
                                TdoNs = ru.TdoNs

                            })
                            select new
                            {
                                TdoId = ru.TdoId,
                                TdvNombre = rues.TdvNombre,
                                TdvNumeroPaginas = rues.TdvNumeroPaginas,
                                TdvRutaAdjunto = rues.TdvRutaAdjunto,
                                TdoNombre = ru.TdoNombre,
                                TdoObservaciones = ru.TdoObservacion,
                                TdoNs = ru.TdoNs
                            };


            AppTipoDocumentosValoresDto documentos;

            foreach (var item in resultado)
            {
                documentos = new AppTipoDocumentosValoresDto
                {
                    TdoId = item.TdoId,
                    TdvNombre = item.TdvNombre,
                    TdvNumeroPaginas = item.TdvNumeroPaginas,
                    TdvRutaAdjunto = item.TdvRutaAdjunto,
                    TdoNombre = item.TdoNombre,
                    TdoObservaciones = item.TdoObservaciones,
                    TdoNs = item.TdoNs
                };
                presDetList.Add(documentos);
            }
            return presDetList;
        }

        public Collection<AppPresupuestoDetalleDto> GetAppPresupuestoDetalle(decimal idVigencia, decimal idProyecto)
        {
            Collection<AppPresupuestoDetalleDto> presDetList = new Collection<AppPresupuestoDetalleDto>();
            Collection<AppPresupuestoDetalleTipoDto> consulta1 = null;
            Collection<AppPresupuestoDetalleDto> consulta2 = null;
            Collection<AppPresupuestoDetalleTipoTitulosDto> consulta3 = null;
            Collection<PresupuestoParametrizacionLineasTopeDto> consulta4 = null;
            ProyectoDto consulta5 = null;
            ProponenteDto proponente = null;
            Collection<AppTiposEntidadesDto> GetTiposEntidades;
            
            GetTiposEntidades = _mapper.Map<Collection<AppTiposEntidadesDto>>(_tiposEntidadesRepository.Get(o => o.VigId.Equals(idVigencia)));

            consulta1 = _mapper.Map<Collection<AppPresupuestoDetalleTipoDto>>(_appPresupuestoDetalleTipo.Get(x => x.VIG_ID == idVigencia));

            consulta2 = _mapper.Map<Collection<AppPresupuestoDetalleDto>>(_appPresupuestoDetalle.Get(m => m.ProId == idProyecto));

            consulta3 = _mapper.Map<Collection<AppPresupuestoDetalleTipoTitulosDto>>(_appPresupuestoDetalleTipoTitulos.Get());

            consulta5 = _mapper.Map<ProyectoDto>(_appProyectosRepositor.Get(l => l.ProId == idProyecto).FirstOrDefault());

            proponente =  _mapper.Map<ProponenteDto>(_appProponentesRepositor.Get(n => n.ProId == consulta5.ProIdProponente).FirstOrDefault());

            consulta4 = _mapper.Map<Collection<PresupuestoParametrizacionLineasTopeDto>>(_presupuestoParametrizacionLineasTope.Get(l => l.ZON_ID == consulta5.ZonId && l.LIN_ID == consulta5.LinId));

            decimal topePresupuesto = consulta4[0].VALOR_TOPE_PRESUPUESTO;
            int tipId = proponente.TipId.Value;
            bool aceptaRecursosPropios = false;

            foreach (var item in GetTiposEntidades)
            {
                if(item.TipId == tipId)
                {
                    aceptaRecursosPropios = item.TipRecursosEntidad;

                }
            }

            List <AppPresupuestoDetalleDto> appPresupuestoDetalle = new List<AppPresupuestoDetalleDto>();

            var resultado = from ru in consulta1
                join ti in consulta3 on ru.ATT_ID equals ti.ATT_ID
                join es in consulta2 on ru.AptId equals es.AptId into DetalleTipo
                from rues in DetalleTipo.DefaultIfEmpty(new AppPresupuestoDetalleDto()
                {
                    PdeValorTotal = 0,
                    PdeRecursosMunicipio = 0,
                    PdeRecursosDepartmento = 0,
                    PdeRecursosMinisterio = 0,
                    PdeIngresosPropios = 0,
                    PdeOtrosRecursos = 0,
                    ProId = 0,
                    AptId = ru.AptId,
                    PdeDetalleOtrosRecursos = "",
                    UsuCreo = "",
                    UsuModifico = "",
                    FecCreo = DateTime.Now,
                    FecModifico = DateTime.Now,
                    APT_DESCRIPCION = ru.AptDescripcion,
                    TCP_ID = ru.TCP_ID,
                    ATT_DESCRIPCION = ti.ATT_DESCRIPCION,
                    ATT_ID = ru.ATT_ID,
                    APT_ORDEN = ru.AptOrden,
                    VALOR_TOPE_PRESUPUESTO = 0,

                })
                select new
                {
                    PdeValorTotal = rues.PdeValorTotal,
                    PdeRecursosMunicipio = rues.PdeRecursosMunicipio,
                    PdeRecursosDepartmento = rues.PdeRecursosDepartmento,
                    PdeRecursosMinisterio = rues.PdeRecursosMinisterio,
                    PdeIngresosPropios = rues.PdeIngresosPropios,
                    PdeOtrosRecursos = rues.PdeOtrosRecursos,
                    ProId = rues.ProId,
                    AptId = ru.AptId,
                    PdeDetalleOtrosRecursos = rues.PdeDetalleOtrosRecursos,
                    UsuCreo = rues.UsuCreo,
                    UsuModifico = rues.UsuModifico,
                    FecCreo = rues.FecCreo,
                    FecModifico = rues.FecModifico,
                    APT_DESCRIPCION = ru.AptDescripcion,
                    TCP_ID = ru.TCP_ID,
                    ATT_DESCRIPCION = ti.ATT_DESCRIPCION,
                    ATT_ID = ru.ATT_ID,
                    APT_ORDEN = ru.AptOrden
                };

            AppPresupuestoDetalleDto presupuesto = null;

            resultado = resultado.OrderBy(s => s.APT_ORDEN);

            foreach (var item in resultado)
            {
                presupuesto = new AppPresupuestoDetalleDto
                {
                    PdeValorTotal = item.PdeValorTotal,
                    PdeRecursosMunicipio = item.PdeRecursosMunicipio,
                    PdeRecursosDepartmento = item.PdeRecursosDepartmento,
                    PdeRecursosMinisterio = item.PdeRecursosMinisterio,
                    PdeIngresosPropios = item.PdeIngresosPropios,
                    PdeOtrosRecursos = item.PdeOtrosRecursos,
                    ProId = item.ProId,
                    AptId = item.AptId,
                    PdeDetalleOtrosRecursos = item.PdeDetalleOtrosRecursos,
                    UsuCreo = item.UsuCreo,
                    UsuModifico = item.UsuModifico,
                    FecCreo = item.FecCreo,
                    FecModifico = item.FecModifico,
                    APT_DESCRIPCION = item.APT_DESCRIPCION,
                    TCP_ID = item.TCP_ID,
                    ATT_DESCRIPCION = item.ATT_DESCRIPCION,
                    ATT_ID = item.ATT_ID,
                    APT_ORDEN = item.APT_ORDEN,
                    VALOR_TOPE_PRESUPUESTO = topePresupuesto,
                    TIP_RECURSOS_ENTIDAD = aceptaRecursosPropios
                };
                presDetList.Add(presupuesto);
            }
            return presDetList;
        }

        public Collection<IndicadorLineaCategoriaMunicipioDto> GetAppIndicadorLineaCategoriaMunicipios()
        {
            return _mapper.Map<Collection<IndicadorLineaCategoriaMunicipioDto>>(_appIndicadorLineaCategoriaMunicipioRepositor.Get());
        }

        public Collection<ConZonasDto> GetZonas()
        {
            return _mapper.Map<Collection<ConZonasDto>>(_conZonasRepositor.Get());
        }

        public Collection<ConEstadosDto> GetEstados()
        {
            return _mapper.Map<Collection<ConEstadosDto>>(_conEstadosRepositor.Get());
        }

        public Collection<RequisitosDto> GetRequisitos(int tipId)
        {
            var vigenciaId = GetAppVigencias().Where(v => v.VigEstado == "A").FirstOrDefault().VigId;
            return _mapper.Map<Collection<RequisitosDto>>(_appRequisitosRepositor.Get(r => r.TipId == tipId && r.VigId == vigenciaId));
        }

        public Collection<ResultadoDTO> GetResultado(int idVigencia, string depId, string munId, string proyecto, string proponente, string nroRadicacion)
        {
            var resultado = _resultado.Get( idVigencia, depId,  munId,  proyecto,  proponente,  nroRadicacion);
            return _mapper.Map<Collection<ResultadoDTO>>(resultado);
        }
    }

}
