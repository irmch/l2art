namespace L2Art.Domain.Auctions
{
    public record ItemInfo(
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
            string ItemName
        );
}