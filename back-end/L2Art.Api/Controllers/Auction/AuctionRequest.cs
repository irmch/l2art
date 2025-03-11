namespace L2Art.Api.Controllers.Auction
{
    public record AuctionRequest(
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
        );
}
