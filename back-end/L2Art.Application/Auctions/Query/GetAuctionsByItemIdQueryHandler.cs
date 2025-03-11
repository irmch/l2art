using ErrorOr;
using L2Art.Domain.Auctions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Query
{
    public class GetAuctionsByItemIdQueryHandler : IRequestHandler<GetAuctionsByItemIdQuery, ErrorOr<List<AuctionResponse>>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionsByItemIdQueryHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<ErrorOr<List<AuctionResponse>>> Handle(GetAuctionsByItemIdQuery request, CancellationToken cancellationToken)
        {
            var res = (await _auctionRepository.GetAuctionsByItemId(request.itemId, cancellationToken)).Value
                   .OrderByDescending(auction => auction.CreatedAt)
                   .Take(50)
                   .OrderBy(auction => auction.CreatedAt)
                   .ToList();

            var response = res.Select(ps => new AuctionResponse(
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
