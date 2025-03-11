﻿namespace L2Art.Api.Controllers.PrivateStore
{
    public record PrivateStoreRequest(
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
        );
}
