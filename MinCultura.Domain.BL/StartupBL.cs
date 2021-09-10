using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.BL
{
    public class StartupBL
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
           
            services.AddScoped<ICuentausuarioRepository<Cuentausuario>, CuentausuarioRepository>();
            services.AddScoped<IServicioRepository<Servicio>, ServicioRepository>();
            services.AddScoped<IZonasGeograficasRepository<BasZonasGeograficas>, ZonasGeograficasRepository>();
            services.AddScoped<BaseRepository<Perfil>, PerfilRepository>();
            services.AddScoped<BaseRepository<AppVigencias>, AppVigenciasRepository>();
            services.AddScoped<BaseRepository<AppTiposEntidades>, AppTiposEntidadesRepository>();
            services.AddScoped<BaseRepository<AppTipoProyectoProponente>, AppTipoProyectoProponenteRepository>();
            services.AddScoped<IAppProponentesRepository<AppProponentes>, AppProponentesRepository>();
            services.AddScoped<IAppProyectosRepository<AppProyectos>, AppProyectosRepository>();
            services.AddScoped<BaseRepository<PerfilesCuentausuario>, PerfilesCuentausuarioRepository>();
            services.AddScoped<BaseRepository<AppLineas>, LineasRepository>();
            services.AddScoped<IAppIndicadoresRepository<AppIndicadores>, IndicadoresRepository>();
            services.AddScoped<IAppIndicadoresLineaRepository<AppIndicadoresLinea>, IndicadoresLineaRepository>();
            services.AddScoped<IValoresIndicadorRepository<AppValoresIndicador>, ValoresIndicadorRepository>();
            services.AddScoped<BaseRepository<BasEntidadesFinancieras>, BasEntidadesFinancierasRepository>();
            services.AddScoped<BaseRepository<AppAreas>, AreasRepository>();
            services.AddScoped<BaseRepository<AppTemas>, TemasRepository>();
            services.AddScoped<IAppTemasProyectosRepository<AppTemasProyectos>, AppTemasProyectosRepository>();
            services.AddScoped<IAppComponentesRepository<AppComponentes>,ComponentesRepository>();
            services.AddScoped<IAppCronogramaRepository<AppCronograma>, AppCronogramaRepository>();
            services.AddScoped<IActividadesObligatoriasRepository<AppActividadesObligatorias>, ActividadesObligatoriasRepository>();
            services.AddScoped<IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias>, ProyectoActividadesObligatoriasRepository>();
            services.AddScoped<BaseRepository<PlantillaCorreos>, PlantillaCorreosRepository>();
            services.AddScoped<BaseRepository<EnvioCorreos>, EnvioCorreosRepository>();
            services.AddScoped<BaseRepository<Trayectoria>, TrayectoriaRepository>();
            services.AddScoped<BaseRepository<TipoTrayectoria>, TipoTrayectoriaRepository>();
            services.AddScoped<BaseRepository<AppPresupuestoDetalleTipoTitulos>, AppPresupuestoDetalleTipoTitulosRepository>();
            services.AddScoped<BaseRepository<AppPresupuestoDetalleTipo>, AppPresupuestoDetalleTipoRepository>();
            services.AddScoped<IAppPresupuestoDetalleRepository<AppPresupuestoDetalle>, AppPresupuestoDetalleRepository>();
            services.AddScoped<ITrayectoriaProyectoRepository<TrayectoriaProyecto>, TrayectoriaProyectoRepository>();
            services.AddScoped<IAppRadicadoProyectosRepository<AppRadicadoProyectos>, AppRadicadoProyectosRepository>();
            services.AddScoped<BaseRepository<PresupuestoParametrizacionLineasTope>, PresupuestoParametrizacionLineasTopeRepository>();
            services.AddScoped<BaseRepository<AppDocumentosTipoEntidades>, AppDocumentosTipoEntidadesRepository>();
            services.AddScoped<BaseRepository<AppTipoDocumentos>, AppTipoDocumentosRepository>();
            services.AddScoped<IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores>, AppTipoDocumentosValoresRepository>();
            services.AddScoped<IResultadoRepository<Resultado>, ResultadoRepository>();
            services.AddScoped<BaseRepository<Funcionario>, FuncionarioRepository>();
            services.AddScoped<IIndicadorLineaCategoriaMunicipioRepository<AppIndicadorLineaCategoriaMunicipio>, IndicadorLineaCategoriaMunicipioRepository>();
            services.AddScoped<IValoresIndicadorLineaCategoriaMunicipioRepository<AppValoresIndicadorLineaCategoriaMunicipio>, ValoresIndicadorLineaCategoriaMunicipioRepository>();
            services.AddScoped<BaseRepository<AppBeneficiarios>, AppBeneficiariosRepository>();
            services.AddScoped<IEvaluacionRequisitosRepository<AppEvaluacionRequisitos>, EvaluacionRequisitosRepository>();
            services.AddScoped<IRequisitosRepository<AppRequisitos>, RequisitosRepository>();
            services.AddScoped<BaseRepository <ConEstados>, ConEstadosRepository>();
            services.AddScoped<BaseRepository<ConZonas>, ConZonasRepository>();
            services.AddScoped<BaseRepository<ConActividades>, ConActividadesRepository>();
            services.AddScoped<BaseRepository<ConSeguimientos>, ConSeguimientosRepository>();
            services.AddScoped<IAppDetallesTipoEntidadesRepository<AppDetalleTiposEntidades>, AppDetalleTipoEntidadRepository>();
            services.AddScoped<IResultadoRepository<Resultado>, ResultadoRepository>();

            //Contexto de Concertacion
            services.AddDbContext<ConcertacionContext>(config =>
            {
                config.UseSqlServer(connectionString);
            });
        }
    }
}
