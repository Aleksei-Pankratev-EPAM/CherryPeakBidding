using CherryPeakTrading.Data.Contracts.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace CherryPeakTrading.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IServiceProvider _serviceProvider;

        public Worker(
            ILogger logger,
            IServiceScopeFactory serviceScopeFactory,
            IConnectionFactory connectionFactory)
        {
            _logger = logger;
            _connectionFactory = connectionFactory;
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Worker started at {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            IConnection? connection = null;
            while (connection == null && !stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.Information("Trying to connect to the message queue");
                    connection = _connectionFactory.CreateConnection();
                }
                catch (Exception ex)
                {
                    _logger.Information("Could not connect to the message queue. {message}", ex.Message);
                    Console.WriteLine("Could not connect to the message queue. Sleep...");
                    await Task.Delay(1000, stoppingToken);
                }
            }

            var consumers = _serviceProvider
                .GetServices<IMessageConsumer>();

            foreach (var service in consumers)
            {
                service.StartListening();
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            foreach (var service in consumers)
            {
                service.StopListening();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Worker stopped at {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}
