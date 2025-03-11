using ErrorOr;
using L2Art.Domain.PrivateShops;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Command
{
    public record PrivateShopsNewItemCommand(
            int itemCount,
            string VendorName,
            int VendorId,
            byte StoreType,
            long Price,
            int x,
            int y,
            int z,
            short TypeOfModification,
            int ObjectId,
            int ItemId,
            long Quantity,
            int StoreItemType,
            long ItemSlot,
            short Enchant,
            int Ls1,
            int Ls2,
            int Ls3,
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
        ) : IRequest<ErrorOr<PrivateShop>>;
}
