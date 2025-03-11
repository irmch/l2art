using ErrorOr;
using L2Art.Domain.Abstractions;
using L2Art.Domain.ItemNames;
using L2Art.Domain.PrivateShops;
using L2Art.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Query
{
    public class GetUnderpricedItemsQueryHandler : IRequestHandler<GetUnderpricedItemsQuery, ErrorOr<List<PrivateShopResponse>>>
    {
        private readonly IPrivateShopsRepository _privateShopsRepository;
        private readonly IPrivateShopItemTradingService _privateShopTradingService;
        public GetUnderpricedItemsQueryHandler(IPrivateShopsRepository privateShopsRepository, IPrivateShopItemTradingService privateStoreItemTradingService)
        {
            _privateShopsRepository = privateShopsRepository;
            _privateShopTradingService = privateStoreItemTradingService;
        }

        public async Task<ErrorOr<List<PrivateShopResponse>>> Handle(GetUnderpricedItemsQuery request, CancellationToken cancellationToken)
        {
            var privateShops = await _privateShopsRepository.GetAllActiveShopsAsync(cancellationToken);

            var sellsTypePrivateShops = privateShops.Where(privateShop => privateShop.TraderInfo.StoreType == 0).ToList();


            var groupedItemShops = sellsTypePrivateShops.GroupBy(g => new { g.TraderInfo.ItemId, g.ItemInfo.Enchant }).Select(group => new
            {
                Key = group.Key,
                Shops = group.ToList()
            })
           .ToList();

            var bestDealPrivateShops = new List<PrivateShop>();

            foreach (var item in groupedItemShops)
            {
                if (item.Shops.Count > 2)
                {
                    var resBestDeal = _privateShopTradingService.FindBestDealsPrivateShop(item.Shops, 10, 30);

                    bestDealPrivateShops.AddRange(resBestDeal);
                }
            }

            var response = bestDealPrivateShops.Select(ps => new PrivateShopResponse(
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

            return response;
            
        }
    }
}
