using L2Art.Domain.PrivateShops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Configurations
{
    internal sealed class PrivateShopsConfiguration : IEntityTypeConfiguration<PrivateShop>
    {
        public void Configure(EntityTypeBuilder<PrivateShop> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(p => p.ItemCount, ic =>
            {
                ic.Property(i => i.itemCount).HasColumnName("ItemCount");
            });

            builder.OwnsOne(p => p.TraderInfo, ti =>
            {
                ti.Property(t => t.VendorName).HasColumnName("VendorName");
                ti.Property(t => t.VendorId).HasColumnName("VendorId");
                ti.Property(t => t.StoreType).HasColumnName("StoreType");
                ti.Property(t => t.Price).HasColumnName("Price");
                ti.Property(t => t.x).HasColumnName("X");
                ti.Property(t => t.y).HasColumnName("Y");
                ti.Property(t => t.z).HasColumnName("Z");
                ti.Property(t => t.TypeOfModification).HasColumnName("TypeOfModification");
                ti.Property(t => t.ObjectId).HasColumnName("ObjectId");
                ti.Property(t => t.ItemId).HasColumnName("ItemId");
                ti.Property(t => t.Quantity).HasColumnName("Quantity");
                ti.Property(t => t.StoreItemType).HasColumnName("StoreItemType");
                ti.Property(t => t.ItemName).HasColumnName("ItemName");
            });

            builder.OwnsOne(p => p.ItemInfo, ii =>
            {
                ii.Property(t => t.ItemSlot).HasColumnName("ItemSlot");
                ii.Property(t => t.Enchant).HasColumnName("Enchant");
                ii.Property(t => t.Ls1).HasColumnName("Ls1");
                ii.Property(t => t.Ls2).HasColumnName("Ls2");
                ii.Property(t => t.Ls3).HasColumnName("Ls3");
                ii.Property(t => t.AttributeType).HasColumnName("AttributeType");
                ii.Property(t => t.WeaponAttributeStat).HasColumnName("WeaponAttributeStat");
                ii.Property(t => t.WaterAttribute).HasColumnName("WaterAttribute");
                ii.Property(t => t.FireAttribute).HasColumnName("FireAttribute");
                ii.Property(t => t.EarthAttribute).HasColumnName("EarthAttribute");
                ii.Property(t => t.WindAttribute).HasColumnName("WindAttribute");
                ii.Property(t => t.DarkAttribute).HasColumnName("DarkAttribute");
                ii.Property(t => t.HolyAttribute).HasColumnName("HolyAttribute");
                ii.Property(t => t.SoulCrystal1).HasColumnName("SoulCrystal1");
                ii.Property(t => t.SoulCrystal2).HasColumnName("SoulCrystal2");
                ii.Property(t => t.SoulCrystal3).HasColumnName("SoulCrystal3");
            });

            builder.OwnsOne(p => p.VisualInfo, vi =>
            {
                vi.Property(t => t.VisualId).HasColumnName("VisualId");
                vi.Property(t => t.VisualIdName).HasColumnName("VisualIdName");
            });
            builder.Property(p => p.CreatedAt);
            builder.Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true)
                .ValueGeneratedOnAdd();
        }
    }
}
