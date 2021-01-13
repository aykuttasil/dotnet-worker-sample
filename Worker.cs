using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is starting.");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var client = new RestClient();
                var url = "https://dog.ceo/api/breeds/image/random";
                var request = new RestRequest(url);
                var resp = await client.ExecuteAsync<string>(request);
                if (resp.IsSuccessful)
                {
                    _logger.LogInformation("Successful");
                }
                else
                {
                    _logger.LogError("Hata: " + resp.ErrorMessage);
                }

                await Task.Delay(1 * 2000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service is stopping.");
            await base.StopAsync(stoppingToken);
        }

    }
}
