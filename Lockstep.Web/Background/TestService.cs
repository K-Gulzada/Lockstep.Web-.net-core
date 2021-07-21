using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.Background
{
    internal class TestService:BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger _logger;

        public TestService(IServiceProvider provider, ILogger<TestService> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Start test service");
            using var scope = _provider.CreateScope();
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var specs = await File.ReadAllLinesAsync("C:\\Users\\КахарГ.NEW\\source\\repos", stoppingToken);
                    _logger.LogError("TIK-TAK");
                    Thread.Sleep(2000);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"error at test tasks{ex.Message}");
                throw;
            }
        }
    }
}
