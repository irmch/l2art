using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Query
{
    public record PrivateShopResponse(
            int itemCount,
            string itemName,
            string vendorName,
            int vendorId,
            byte storeType,
            long price,
            int x,
            int y,
            int z,
            short typeOfModification,
            int objectId,
            int itemId,
            long quantity,
            int storeItemType,
            long itemSlot,
            short enchant,
            int ls1,
            int ls2,
            int ls3,
            short attributeType,
            short weaponAttributeStat,
            short waterAttribute,
            short fireAttribute,
            short earthAttribute,
            short windAttribute,
            short darkAttribute,
            short holyAttribute,
            int soulCrystal1,
            int soulCrystal2,
            int soulCrystal3,
            int visualId
        );
}
