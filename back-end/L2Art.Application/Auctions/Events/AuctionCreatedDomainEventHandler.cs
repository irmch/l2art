using L2Art.Application.Services;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
using L2Art.Domain.Auctions.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Events
{
    internal class AuctionCreatedDomainEventHandler : INotificationHandler<AuctionCreatedDomainEvent>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IPrivateShopItemTradingService _privateShopItemTradingService;
        private readonly IHubContext<ItemHub> _hubContext;

        public AuctionCreatedDomainEventHandler(IAuctionRepository auctionRepository, IPrivateShopItemTradingService privateShopItemTradingService, IHubContext<ItemHub> hubContext)
        {
            _auctionRepository = auctionRepository;
            _privateShopItemTradingService = privateShopItemTradingService;
            _hubContext = hubContext;
        }

        public async Task Handle(AuctionCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var auction = (await _auctionRepository.GetAuctionByCommissionId(notification.commissionId, cancellationToken)).Value;

            var auctions = (await _auctionRepository.GetAllActiveAuctions(cancellationToken)).Value;

            var groupedItemShops = auctions
                                    .Where(item => item.ItemInfo.ItemId == auction.ItemInfo.ItemId && item.ItemInfo.Enchant == auction.ItemInfo.Enchant)
                                    .GroupBy(g => new { g.ItemInfo.ItemId, g.ItemInfo.Enchant }).Select(group => new
                                    {
                                        Key = group.Key,
                                        Shops = group.ToList()
                                    })
                                   .ToList();

            var bestDeaList = new List<Auction>();

            foreach (var item in groupedItemShops)
            {
                if (item.Shops.Count > 2)
                {
                    bestDeaList = _privateShopItemTradingService.FindBestDealsAuction(item.Shops, 10, 30);
                }
            }

            foreach (var item in bestDeaList)
            {
                await _hubContext.Clients.All.SendAsync("BestDealAuction_addNew", JsonSerializer.Serialize(item), cancellationToken);
            }
        }
    }
}
