using ErrorOr;
using L2Art.Application.PrivateShops.Query;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
using L2Art.Domain.PrivateShops;
using L2Art.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L2Art.Application.Auctions.Query
{
    public class GetUnderpricedAuctionItemsQueryHandler : IRequestHandler<GetUnderpricedAuctionItemsQuery, ErrorOr<List<AuctionResponse>>>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IPrivateShopItemTradingService _privateShopItemTrading;

        public GetUnderpricedAuctionItemsQueryHandler(IAuctionRepository auctionRepository, IPrivateShopItemTradingService privateShopItemTrading)
        {
            _auctionRepository = auctionRepository;
            _privateShopItemTrading = privateShopItemTrading;
        }

        public async Task<ErrorOr<List<AuctionResponse>>> Handle(GetUnderpricedAuctionItemsQuery request, CancellationToken cancellationToken)
        {
            var auctionItems = (await _auctionRepository.GetAllActiveAuctions(cancellationToken)).Value;


            var groupedItemShops = auctionItems.GroupBy(g => new { g.ItemInfo.ItemId, g.ItemInfo.Enchant }).Select(group => new
            {
                Key = group.Key,
                Shops = group.ToList()
            })
           .ToList();

            var bestDealPrivateShops = new List<Auction>();

            foreach (var item in groupedItemShops)
            {
                if (item.Shops.Count > 2)
                {
                    var resBestDeal = _privateShopItemTrading.FindBestDealsAuction(item.Shops, 10, 30);

                    bestDealPrivateShops.AddRange(resBestDeal);
                }
            }

            var response = bestDealPrivateShops.Select(ps => new AuctionResponse(
                ps.ItemMetaData.CommissionId,
                ps.ItemMetaData.PricePerUnit,
                ps.ItemMetaData.CommissionItemType,
                ps.ItemMetaData.DurationInDays,
                ps.ItemMetaData.EpochSecondEndTime,
                ps.ItemMetaData.SellerName,
                ps.ItemMetaData.TypeOfModification,
                ps.ItemInfo.ObjectId,
                ps.ItemInfo.ItemId,
                ps.ItemInfo.Count,
                ps.ItemInfo.StoreItemType,
                ps.ItemInfo.ItemSlot,
                ps.ItemInfo.Enchant,
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
                ps.VisualInfo.VisualId,
                ps.ItemInfo.ItemName
            )).ToList();

            return response;

        }
    }
}
