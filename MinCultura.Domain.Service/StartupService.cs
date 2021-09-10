using Microsoft.Extensions.DependencyInjection;
using MinCultura.Domain.BL;
using MinCultura.Domain.BL.Interface;

namespace MinCultura.Domain.Service
{
    public class StartupService
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ILoginBL, LoginBL>();
            services.AddScoped<IServicioBL, ServicioBL>();
            services.AddScoped<IZonasGeograficasBL, ZonasGeograficasBL>();
            services.AddScoped<IListasBL, ListasBL>();
            services.AddScoped<IFormulariosBL, FormulariosBL>();
            services.AddScoped<ITrayectoriasProyectoBL, TrayectoriasProyectoBL>();
            services.AddScoped<IEnvioProyectoBL, EnvioProyectoBL>();
            services.AddScoped<IEvaluacionBL, EvaluacionBL>();
            

            StartupBL.ConfigureServices(services, connectionString);
        }
    }
}
