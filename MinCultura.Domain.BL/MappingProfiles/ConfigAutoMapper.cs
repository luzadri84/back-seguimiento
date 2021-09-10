using AutoMapper;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.BL.MappingProfiles
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<PerfilDto, Perfil>().ReverseMap();
            CreateMap<CuentaUsuarioDto, Cuentausuario>().ReverseMap();
            CreateMap<PerfilesCuentausuarioDto, PerfilesCuentausuario>().ReverseMap();
            CreateMap<ZonaGeograficaDto, BasZonasGeograficas>().ReverseMap();
            CreateMap<ServicioDto, Servicio>().ReverseMap();
            CreateMap<AppVigenciasDto, AppVigencias>().ReverseMap();
            CreateMap<AppTiposEntidadesDto, AppTiposEntidades>().ReverseMap();
            CreateMap<TipoProyectoProponenteDto, AppTipoProyectoProponente>().ReverseMap();
            CreateMap<LineaDto, AppLineas>().ReverseMap();
            CreateMap<IndicadoresDto, AppIndicadores>().ReverseMap();
            CreateMap<IndicadoresLineaDto, AppIndicadoresLinea>().ReverseMap();
            CreateMap<ProponenteDto, AppProponentes>().ReverseMap();
            CreateMap<ProyectoDto, AppProyectos>().ReverseMap();
            CreateMap<EntidadesFinancierasDto, BasEntidadesFinancieras>().ReverseMap();
            CreateMap<AreaDto, AppAreas>().ReverseMap();
            CreateMap<TemasProyectosDto, AppTemasProyectos>().ReverseMap();
            CreateMap<TemasDto, AppTemas>().ReverseMap();
            CreateMap<ComponentesDto, AppComponentes>().ReverseMap();
            CreateMap<CronogramaDto, AppCronograma>().ReverseMap();
            CreateMap<ActividadesObligatoriasDto, AppActividadesObligatorias>().ReverseMap();
            CreateMap<ValoresIndicadorDto, AppValoresIndicador>().ReverseMap();
            CreateMap<ProyectoActividadesObligatoriasDto, AppProyectoActividadesObligatorias>().ReverseMap();
            CreateMap<EnvioCorreosDto, EnvioCorreos>().ReverseMap();
            CreateMap<AdjuntoCorreoDto, AdjuntoCorreo>().ReverseMap();
            CreateMap<TrayectoriasDTO, Trayectoria>().ReverseMap();
            CreateMap<TipoTrayectoriasDTO, TipoTrayectoria>().ReverseMap();
            CreateMap<TrayectoriaProyectoDTO, TrayectoriaProyecto>().ReverseMap();
            CreateMap<ValoresIndicadorLineaCategoriaMunicipioDto, AppValoresIndicadorLineaCategoriaMunicipio>().ReverseMap();
            CreateMap<IndicadorLineaCategoriaMunicipioDto, AppIndicadorLineaCategoriaMunicipio>().ReverseMap();
            CreateMap<AppPresupuestoDetalleDto, AppDetalleTiposEntidades>().ReverseMap();


            CreateMap<AppPresupuestoDetalleTipoTitulosDto, AppPresupuestoDetalleTipoTitulos>().ReverseMap();
            CreateMap<AppPresupuestoDetalleTipoDto, AppPresupuestoDetalleTipo>().ReverseMap();
            CreateMap<AppPresupuestoDetalleDto, AppPresupuestoDetalle>().ReverseMap();
            CreateMap<PresupuestoParametrizacionLineasTopeDto, PresupuestoParametrizacionLineasTope>().ReverseMap();
            CreateMap<AppDocumentosTipoEntidadesDto, AppDocumentosTipoEntidades>().ReverseMap();
            CreateMap<AppTipoDocumentosDto, AppTipoDocumentos>().ReverseMap();
            CreateMap<AppTipoDocumentosValoresDto, AppTipoDocumentosValores>().ReverseMap();
            CreateMap<AppBeneficiariosDto, AppBeneficiarios>().ReverseMap();
            CreateMap<ResultadoDTO, Resultado>().ReverseMap();
            CreateMap<FuncionarioDto , Funcionario>().ReverseMap();
            CreateMap<EvaluacionRequisitosDto, AppEvaluacionRequisitos>().ReverseMap();
            CreateMap<RequisitosDto, AppRequisitos>().ReverseMap();
            CreateMap<ConZonasDto, ConZonas>().ReverseMap();
            CreateMap<ConEstadosDto, ConEstados>().ReverseMap();

            CreateMap<ConActividadesDto, ConActividades>().ReverseMap();
            CreateMap<ConSeguimientosDto, ConSeguimientos>().ReverseMap();



        }
    }
}
