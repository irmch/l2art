using ErrorOr;
using L2Art.Domain.Auctions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Command
{
    public record AuctionNewItemCommand(
            long CommissionId,
            long PricePerUnit,
            int CommissionItemType,
            int DurationInDays,
            int EpochSecondEndTime,
            string SellerName,
            short TypeOfModification,
            int ObjectId,
            int ItemId,
            int Count,
            long StoreItemType,
            long ItemSlot,
            short Enchant,
            short AttributeType,
            short WeaponAttributeStat,
            short WaterAttribute,
            short FireAttribute,
            short EarthAttribute,
            short WindAttribute,
            short DarkAttribute,
            short HolyAttribute,
            int SoulCrystal1,
            int SoulCrystal2,
            int SoulCrystal3,
            int VisualId
        ) : IRequest<ErrorOr<Auction>>;
}
