using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.PrivateShops
{
    public record ItemInfo(
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
            int SoulCrystal3
        );
}
