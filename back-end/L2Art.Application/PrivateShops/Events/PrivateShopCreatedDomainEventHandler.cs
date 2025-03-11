using L2Art.Application.PrivateShops.Query;
using L2Art.Application.Services;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
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
    internal sealed class PrivateShopCreatedDomainEventHandler : INotificationHandler<PrivateShopCreatedDomainEvent>
    {
        private readonly IHubContext<ItemHub> _hubContext;
        private readonly IPrivateShopsRepository _privateShopRepository;
        private readonly IPrivateShopItemTradingService _privateShopItemTradingService;
        public PrivateShopCreatedDomainEventHandler(IPrivateShopsRepository privateShopsRepository, IPrivateShopItemTradingService privateShopItemTradingService, IHubContext<ItemHub> hubContext)
        {
            _hubContext = hubContext;
            _privateShopRepository = privateShopsRepository;
            _privateShopItemTradingService = privateShopItemTradingService;
        }

        public async Task Handle(PrivateShopCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var privateShop = await _privateShopRepository.GetByIdAsync(notification.NewItemId, cancellationToken);

            var activeShopsById = (await _privateShopRepository.GetAllActiveShopsAsync(cancellationToken))
                .Where(item => item.TraderInfo.StoreItemType == 0)
                .Where(item => item.TraderInfo.ItemId == privateShop.TraderInfo.ItemId)
                .GroupBy(g => new { g.TraderInfo.ItemId, g.ItemInfo.Enchant }).Select(group => new
                {
                    Key = group.Key,
                    Shops = group.ToList()
                }).ToList();

            var bestDeaList = new List<PrivateShop>();

            foreach (var item in activeShopsById)
            {
                if (item.Shops.Count > 2)
                {
                    bestDeaList = _privateShopItemTradingService.FindBestDealsPrivateShop(item.Shops, 10, 30);
                }
            }

            var response = bestDeaList.Select(ps => new PrivateShopResponse(
                    ps.ItemCount.itemCount,
                    ps.TraderInfo.ItemName,
                    ps.TraderInfo.VendorName,
                    ps.TraderInfo.VendorId,
                    ps.TraderInfo.StoreType,
                    ps.TraderInfo.Price,
                    ps.TraderInfo.x,
                    ps.TraderInfo.y,
                    ps.TraderInfo.z,
                    ps.TraderInfo.TypeOfModification,
                    ps.TraderInfo.ObjectId,
                    ps.TraderInfo.ItemId,
                    ps.TraderInfo.Quantity,
                    ps.TraderInfo.StoreItemType,
                    ps.ItemInfo.ItemSlot,
                    ps.ItemInfo.Enchant,
                    ps.ItemInfo.Ls1,
                    ps.ItemInfo.Ls2,
                    ps.ItemInfo.Ls3,
                    ps.ItemInfo.AttributeType,
                    ps.ItemInfo.WeaponAttributeStat,
                    ps.ItemInfo.WaterAttribute,
                    ps.ItemInfo.FireAttribute,
                    ps.ItemInfo.EarthAttribute,
                    ps.ItemInfo.WindAttribute,
                    ps.ItemInfo.DarkAttribute,
                    ps.ItemInfo.HolyAttribute,
                    ps.ItemInfo.SoulCrystal1,
                    ps.ItemInfo.SoulCrystal2,
                    ps.ItemInfo.SoulCrystal3,
                    ps.VisualInfo.VisualId
                )).ToList();



            foreach ( var bestPriceItem in response)
            {
                var serializedPrivateShop = JsonSerializer.Serialize(bestPriceItem);

                await _hubContext.Clients.All.SendAsync("BestDealPrivateShops_addNew", serializedPrivateShop, cancellationToken);
            }
        }
    }
}
