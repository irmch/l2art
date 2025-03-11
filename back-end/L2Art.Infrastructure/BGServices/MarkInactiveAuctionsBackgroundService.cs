using L2Art.Application.Services;
using L2Art.Domain.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.BGServices
{
    public class MarkInactiveAuctionsBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);
        private readonly IHubContext<ItemHub> _hubContext;

        public MarkInactiveAuctionsBackgroundService(IServiceScopeFactory scopeFactory, IHubContext<ItemHub> hubContext)
        {
            _scopeFactory = scopeFactory;
            _hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<MarkInactiveItemsService>();

                var changedActiveStatusOfShops = await service.MarkInactiveAuction(TimeSpan.FromMinutes(1), stoppingToken);

                foreach (var item in changedActiveStatusOfShops)
                {
                    await _hubContext.Clients.All.SendAsync("BestDealAuction_delete", JsonSerializer.Serialize(item), stoppingToken);
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
