using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
namespace Bussiness_logic.Services
{
    public class TemporalBlockCleanupService : BackgroundService
    {
        private readonly TemporalBlockService _temporalService;

        public TemporalBlockCleanupService(TemporalBlockService temporalService)
        {
            _temporalService = temporalService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _temporalService.CleanupExpiredBlocks();
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
