using L2Art.Application.Services;
using L2Art.Domain.Abstractions;
using L2Art.Domain.PrivateShops;
using L2Art.Domain.PrivateShops.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Events
{
    public sealed class PrivateShopUpdatedDomainEventHandler : INotificationHandler<PrivateShopUpdatedDomainEvent>
    {
        private readonly IHubContext<ItemHub> _hubContext;
        private readonly IPrivateShopsRepository _privateShopRepository;
        public PrivateShopUpdatedDomainEventHandler(IPrivateShopsRepository privateShopsRepository, IHubContext<ItemHub> hubContext)
        {
            _hubContext = hubContext;
            _privateShopRepository = privateShopsRepository;
        }

        public async Task Handle(PrivateShopUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var privateShop = await _privateShopRepository.GetByIdAsync(notification.updatedId, cancellationToken);
            await _hubContext.Clients.All.SendAsync("BestDealPrivateShops_update", JsonSerializer.Serialize(privateShop), cancellationToken);
        }
    }
}
