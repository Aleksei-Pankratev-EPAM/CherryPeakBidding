using CherryPeakTrading.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CherryPeakTrading.DI.Logging
{
    public static class StructuredLoggingExtensions
    {
        /// <summary>
        /// Create a logger and assign it to global static <see cref="Log.Logger"/> -
        /// this logger is used in contexts where DI container is not accessible: e.g. on application startup.
        /// </summary>
        /// <param name="esConnectionString">A connection string to Elastic Search instance.</param>
        /// <returns>An globally registered instance of a logger.</returns>
        public static ILogger CreateGlobalLogger(string esConnectionString)
        {
            if (Log.Logger == null)
            {
                var loggerFactory = new SerilogLoggerFactory(esConnectionString);
                Log.Logger = loggerFactory.CreateLogger();
            }

            return Log.Logger;
        }

        /// <summary>
        /// Create a logger and bind it to <see cref="ILogger"/> interface in a provided service collection.
        /// </summary>
        /// <param name="services">A service collection to bind logger.</param>
        /// <param name="esConnectionString">A connection string to Elastic Search instance.</param>
        /// <returns>A modified version of service collection.</returns>
        public static IServiceCollection AddStructuredLogging(this IServiceCollection services, string esConnectionString)
        {
            var loggerFactory = new SerilogLoggerFactory(esConnectionString);
            var logger = loggerFactory.CreateLogger();
            services.AddSingleton(logger);
            return services;
        }
    }
}
