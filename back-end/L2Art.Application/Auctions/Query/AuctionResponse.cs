using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Query
{
    public record AuctionResponse(
            long commissionId,
            long pricePerUnit,
            int commissionItemType,
            int durationInDays,
            int epochSecondEndTime,
            string sellerName,
            short typeOfModification,
            int objectId,
            int itemId,
            int count,
            long storeItemType,
            long itemSlot,
            short enchant,
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
            int visualId,
            string itemName
        );
}
