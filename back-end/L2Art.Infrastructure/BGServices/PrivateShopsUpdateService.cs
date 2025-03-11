using L2Art.Application.PrivateShops.Query;
using L2Art.Application.Services;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.BGServices
{
    public class PrivateShopsUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHubContext<ItemHub> _hubContext;

        public PrivateShopsUpdateService(IServiceProvider serviceProvider, IHubContext<ItemHub> hubContext)
        {
            _serviceProvider = serviceProvider;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                    var result = await mediator.Send(new GetUnderpricedItemsQuery(), stoppingToken);

                    if (result.IsError)
                    {
                        Console.WriteLine("Error while getting data: " + result.FirstError);
                        continue;
                    }

                    await _hubContext.Clients.All.SendAsync("BestDealPrivateShops_UpdateList",
                        JsonSerializer.Serialize(result.Value),
                        stoppingToken);
                }

                await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
            }
        }
    }
}
