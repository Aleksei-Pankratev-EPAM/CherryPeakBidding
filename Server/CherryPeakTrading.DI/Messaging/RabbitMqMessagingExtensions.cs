using CherryPeakTrading.Data.Contracts.Messaging;
using CherryPeakTrading.Infrastructure.Messaging;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace CherryPeakTrading.DI.Messaging
{
    public static class RabbitMqMessagingExtensions
    {
        /// <summary>
        /// An extension method for registering services required for both message publishing or consuming.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="configuration">Connection parameters.</param>
        /// <returns>A modified service collection.</returns>
        public static IServiceCollection AddMessaging(this IServiceCollection services, MessagingConfiguration configuration)
        {
            var connectionFactory = new ConnectionFactory
            {
                UserName = configuration.UserName,
                Password = configuration.Password,
                VirtualHost = configuration.VirtualHost,
                HostName = configuration.HostName,
                Port = configuration.Port,
                AutomaticRecoveryEnabled = true
            };

            services.AddSingleton(options => connectionFactory.CreateConnection());
            services.AddScoped<RabbitMqChannelProvider>();
            return services;
        }

        /// <summary>
        /// An extension method for registering services required for message publishing. <see cref="AddMessaging"/> must be called first.
        /// </summary>
        public static IServiceCollection AddMessagePublishing(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMessagePublisher<>), typeof(RabbitMqMessagePublisher<>));
            
            return services;
        }
    }
}
