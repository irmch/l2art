using ErrorOr;
using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
using L2Art.Domain.ItemNames;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Command
{
    public class AuctionNewItemCommandHandler : IRequestHandler<AuctionNewItemCommand, ErrorOr<Auction>>
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemNameRepository _itemNameRepository;

        public AuctionNewItemCommandHandler(IAuctionRepository auctionRepository, IUnitOfWork unitOfWork, IItemNameRepository itemNameRepository)
        {
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
            _itemNameRepository = itemNameRepository;
        }

        public async Task<ErrorOr<Auction>> Handle(AuctionNewItemCommand request, CancellationToken cancellationToken)
        {

            var itemName = await _itemNameRepository.GetItemByItemId(request.ItemId, cancellationToken);

            var metaData = new ItemMetaData(
                    request.CommissionId,
                    request.PricePerUnit,
                    request.CommissionItemType,
                    request.DurationInDays,
                    request.EpochSecondEndTime,
                    request.SellerName,
                    request.TypeOfModification
                );

            var itemInfo = new ItemInfo(
                    request.ObjectId,
                    request.ItemId,
                    request.Count,
                    request.StoreItemType,
                    request.ItemSlot,
                    request.Enchant,
                    request.AttributeType,
                    request.WeaponAttributeStat,
                    request.WaterAttribute,
                    request.FireAttribute,
                    request.EarthAttribute,
                    request.WindAttribute,
                    request.DarkAttribute,
                    request.HolyAttribute,
                    request.SoulCrystal1,
                    request.SoulCrystal2,
                    request.SoulCrystal3,
                    itemName.Name
                );

            var visualInfo = new VisualInfo(
                    request.VisualId,
                    request.VisualId.ToString()
                );

            var auction = Auction.Create(metaData, itemInfo, visualInfo).Value;

            _auctionRepository.Add(auction);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return auction;
        }
    }
}
