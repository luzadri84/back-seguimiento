using Serilog;
using System.Diagnostics;
using System.Reflection;

namespace MinCultura.Domain.Common
{
    /// <summary>
    /// Definición de servicio base con logger
    /// </summary>
    public abstract class BaseBL
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected BaseBL()
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

        }

        protected void InfoLog(string message)
        {
            MethodBase method = new StackFrame(2).GetMethod();
            Log.Information(null,
                messageTemplate: "[{propertyValue0}][{propertyValue1}]: {propertyValue2}",
                method.ReflectedType.FullName,
                method.Name,
                message);
        }

        protected void DebugLog(string message)
        {
            MethodBase method = new StackFrame(2).GetMethod();
            Log.Debug(null,
                messageTemplate: "[{propertyValue0}][{propertyValue1}]: {propertyValue2}",
                method.ReflectedType.FullName,
                method.Name,
                message);
        }
    }
}
