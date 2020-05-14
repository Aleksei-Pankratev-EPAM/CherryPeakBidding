using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace CherryPeakTrading.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;

        public Worker(ILogger logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Worker started at {time}", DateTimeOffset.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.Debug("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Worker stopped at {time}", DateTimeOffset.Now);
            return base.StopAsync(cancellationToken);
        }
    }
}
