using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MinCultura.Domain.BL;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.DAL.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinCultura.Domain.Worker.EnvioCorreos
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        /// <summary>
        /// Contexto de trabajo
        /// </summary>
        private IServiceScopeFactory _serviceScopeFactory;
        private const int MILLISECOND = 1000;
        private IEnvioCorreoBL envioCorreosBL;
        private EnviarCorreo enviarNotificacion;

        /// <summary>
        /// Constructor del Worker
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceScopeFactory"></param>
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Inicializa los objetos requeridos por el worker
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Ejecuta las tareas dependiendo del tiempo establecido
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            int dealy = int.Parse(config.GetSection("TiempoDeEjecucion").Value);
            string pathSaveReport = config.GetSection("pathSaveReport").Value;
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();
                    var dbContext = scope.ServiceProvider.GetService<ConcertacionContext>();
                    envioCorreosBL = new EnvioCorreosBL(dbContext);
                    enviarNotificacion = new EnviarCorreo(new ConexionEnvioCorreo()
                    {
                        FromAddress = config.GetSection("EmailSettings:UsernameEmail").Value,
                        FromName = config.GetSection("EmailSettings:FromEmail").Value,
                        FromPassword = config.GetSection("EmailSettings:UsernamePassword").Value,
                        Host = config.GetSection("EmailSettings:PrimaryDomain").Value,
                        Port = Convert.ToInt32(config.GetSection("EmailSettings:PrimaryPort").Value)
                    });
                    int intento = 0;
                    //Buscar los correos sin envíar
                    var correosPendientes = envioCorreosBL.GetCorreosPendientes();
                    
                    foreach (var record in correosPendientes)
                    {
                        intento = record.Intento + 1;
                        if (enviarNotificacion.EnviarCorreoElectronico(record.Remitentes, record.Asunto, record.Cuerpo, pathSaveReport, record.AdjuntoCorreo))
                        {
                            //Actualizar el estado del correo a envíado
                            record.Enviado = true;
                            record.Intento = intento;
                            record.FechaEnvio = DateTime.Now;
                        }
                        else
                        {
                            //Actualizar el número de intentos
                            record.Intento = intento;
                            if (record.Intento == 5)
                            {
                                record.Enviado = true;
                                record.Intento = intento;
                                record.FechaEnvio = DateTime.Now;
                                record.Observaciones = "Error al enviar el correo, se realizaron los 5 intentos.";
                            }
                        }
                        envioCorreosBL.Update(record);
                        intento = 0;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Ocurrió un error al realizar el proceso de envío de notificaciones. Error: {error}", ex.Message);
                }
            }
            await Task.Delay(dealy * MILLISECOND, stoppingToken);

        }

        /// <summary>
        /// Finaliza los objetos instaciados y utilizados al cancelar el servicio
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Finalizando worker 'MinCultura.Domain.Worker.EnvioCorreos' para el envío de notificaciones del programa nacional de concertación cultural.");
            return base.StopAsync(cancellationToken);
        }
    }
}
