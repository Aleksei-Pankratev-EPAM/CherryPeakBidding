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

            services.AddSingleton<IConnectionFactory>(connectionFactory);
            services.AddScoped<IRabbitMqChannelProvider, RabbitMqChannelProvider>();
            services.AddSingleton(typeof(IRabbitMqQueueBuilder<>), typeof(RabbitMqDefaultQueueBuilder<>));
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

        /// <summary>
        /// Register a message consumer of specified type.
        /// </summary>
        /// <typeparam name="TConsumer">A class of message consumer.</typeparam>
        /// <typeparam name="TMessage">Type of consumed messages.</typeparam>
        /// <param name="services">Service collection.</param>
        /// <returns>A modified version of service collection.</returns>
        public static IServiceCollection AddMessageConsumer<TConsumer>(this IServiceCollection services)
            where TConsumer : class, IMessageConsumer
        {
            services.AddScoped<IMessageConsumer, TConsumer>();
            return services;
        }
    }
}
