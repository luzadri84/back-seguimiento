using Serilog;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MinCultura.Domain.Common.Exceptions
{
    /// <summary>
    /// Definición de excepción base con logger
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        protected BaseException(string message) : base(message)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/log.log",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day,
                    shared: true)
                .CreateLogger();

            MethodBase method = new StackFrame(2).GetMethod();
            Log.Error(this,
                    messageTemplate: "[{propertyValue0}][{propertyValue1}][{propertyValue2}] {propertyValue3}",
                    method.ReflectedType.FullName,
                    method.Name,
                    GetType().Name,
                    message);
            // Log.CloseAndFlush();
        }
    }
}
