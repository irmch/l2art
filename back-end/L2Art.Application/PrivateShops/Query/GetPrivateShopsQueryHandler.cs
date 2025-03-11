using ErrorOr;
using L2Art.Domain.PrivateShops;
using L2Art.Domain.Services;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Query
{
    public class GetPrivateShopsQueryHandler : IRequestHandler<GetPrivateShopsQuery, ErrorOr<IReadOnlyList<PrivateShopResponse>>>
    {
        private readonly IPrivateShopsRepository _privateShopsRepository;
        public GetPrivateShopsQueryHandler(IPrivateShopsRepository privateShopsRepository, PrivateShopTradingService privateShopTradingService)
        {
            _privateShopsRepository = privateShopsRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<PrivateShopResponse>>> Handle(GetPrivateShopsQuery query, CancellationToken cancellationToken)
        {
            var privateShops = await _privateShopsRepository.GetAllPrivateShops(10, cancellationToken);

            if (privateShops == null)
            {
                return Error.NotFound(description: "No private shops found with the specified parameters.");
            }


            var response = privateShops.Select(ps => new PrivateShopResponse(
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
