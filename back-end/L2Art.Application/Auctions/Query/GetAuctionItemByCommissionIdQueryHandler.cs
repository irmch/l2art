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
    public class GetAuctionItemByCommissionIdQueryHandler : IRequestHandler<GetAuctionItemByCommissionIdQuery, ErrorOr<AuctionResponse>>
    {
        private readonly IAuctionRepository _auctionRepository;

        public GetAuctionItemByCommissionIdQueryHandler(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<ErrorOr<AuctionResponse>> Handle(GetAuctionItemByCommissionIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _auctionRepository.GetAuctionByCommissionId(request.commissionId, cancellationToken);

            if (res.IsError)
            {
                return Error.NotFound("GetAuctionItemByCommissionIdQueryHandler.NotFound", $"Auction with id {request.commissionId} not found");
            }

            var auctionResponse = new AuctionResponse(
                res.Value.ItemMetaData.CommissionId,
                res.Value.ItemMetaData.PricePerUnit,
                res.Value.ItemMetaData.CommissionItemType,
                res.Value.ItemMetaData.DurationInDays,
                res.Value.ItemMetaData.EpochSecondEndTime,
                res.Value.ItemMetaData.SellerName,
                res.Value.ItemMetaData.TypeOfModification,
                res.Value.ItemInfo.ObjectId,
                res.Value.ItemInfo.ItemId,
                res.Value.ItemInfo.Count,
                res.Value.ItemInfo.StoreItemType,
                res.Value.ItemInfo.ItemSlot,
                res.Value.ItemInfo.Enchant,
                res.Value.ItemInfo.AttributeType,
                res.Value.ItemInfo.WeaponAttributeStat,
                res.Value.ItemInfo.WaterAttribute,
                res.Value.ItemInfo.FireAttribute,
                res.Value.ItemInfo.EarthAttribute,
                res.Value.ItemInfo.WindAttribute,
                res.Value.ItemInfo.DarkAttribute,
                res.Value.ItemInfo.HolyAttribute,
                res.Value.ItemInfo.SoulCrystal1,
                res.Value.ItemInfo.SoulCrystal2,
                res.Value.ItemInfo.SoulCrystal3,
                res.Value.VisualInfo.VisualId,
                res.Value.ItemInfo.ItemName
                );
            return auctionResponse;
        }
    }
}
