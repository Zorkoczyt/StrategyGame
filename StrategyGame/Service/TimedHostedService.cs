using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StrategyGame.Service
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IGameService _gameService;

        public TimedHostedService(ILogger<TimedHostedService> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting");
            _timer = new Timer(DoWork, null, TimeSpan.FromHours(1), TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation($"[{DateTime.Now}] New Game turn has started");
            _gameService.ProcessRound();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background service is stopping");
            _timer?.Change(Timeout.Infinite,0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
