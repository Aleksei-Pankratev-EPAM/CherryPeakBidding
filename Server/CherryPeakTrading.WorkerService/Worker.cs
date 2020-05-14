using CherryPeakTrading.Data.Contracts.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly IServiceProvider _serviceProvider;

        public Worker(
            ILogger logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceProvider = serviceScopeFactory.CreateScope().ServiceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Worker started at {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
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
