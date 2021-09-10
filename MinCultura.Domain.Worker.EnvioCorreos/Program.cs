using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinCultura.Domain.DAL.Context;
using Serilog;
using Serilog.Events;

namespace MinCultura.Domain.Worker.EnvioCorreos
{
    public class Program
    {
        /// <summary>
        /// Función principal que inicial el worker
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json", optional: false)
                 .Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(config.GetSection("RutaLog").Value)
                .CreateLogger();
            try
            {
                Log.Information("Iniciando worker 'MinCultura.Domain.Worker.EnvioCorreos' para el envío de notificaciones del programa nacional de concertación cultural.");
                CreateHostBuilder(args, config).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Fatal(ex, "Ocurrio un problema iniciando el worker para el envío de notificaciones del programa nacional de concertación cultural.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Create Host Builder
        /// </summary>
        /// <param name="args">Argumentos</param>
        /// <param name="config">Variables de configuración</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot config)
        {
            return Host.CreateDefaultBuilder(args)
                 .UseWindowsService()
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.AddDbContext<ConcertacionContext>(
                         options => options.UseSqlServer(config.GetSection("ConnectionStrings:DefaultConnection").Value));
                     services.AddHostedService<Worker>();

                 }).UseSerilog();
        }
    }
}
