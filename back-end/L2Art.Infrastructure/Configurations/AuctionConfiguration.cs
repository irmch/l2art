using L2Art.Domain.Auctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Configurations
{
    public class AuctionConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.isActive).HasColumnName("IsActive");

            builder.OwnsOne(au => au.ItemMetaData, au => {
                au.Property(t => t.CommissionId).HasColumnName("CommissionId");
                au.Property(t => t.PricePerUnit).HasColumnName("PricePerUnit");
                au.Property(t => t.CommissionItemType).HasColumnName("CommissionItemType");
                au.Property(t => t.SellerName).HasColumnName("SellerName");
                au.Property(t => t.DurationInDays).HasColumnName("DurationInDays");
                au.Property(t => t.TypeOfModification).HasColumnName("TypeOfModification");
                au.Property(t => t.EpochSecondEndTime).HasColumnName("EpochSecondEndTime");

            });

            builder.OwnsOne(au => au.ItemInfo, au => {
                au.Property(t => t.ObjectId).HasColumnName("ObjectId");
                au.Property(t => t.ItemId).HasColumnName("ItemId");
                au.Property(t => t.Count).HasColumnName("Count");
                au.Property(t => t.StoreItemType).HasColumnName("StoreItemType");
                au.Property(t => t.ItemSlot).HasColumnName("ItemSlot");
                au.Property(t => t.Enchant).HasColumnName("Enchant");
                au.Property(t => t.AttributeType).HasColumnName("AttributeType");
                au.Property(t => t.WeaponAttributeStat).HasColumnName("WeaponAttributeStat");
                au.Property(t => t.WaterAttribute).HasColumnName("WaterAttribute");
                au.Property(t => t.FireAttribute).HasColumnName("FireAttribute");
                au.Property(t => t.EarthAttribute).HasColumnName("EarthAttribute");
                au.Property(t => t.WindAttribute).HasColumnName("WindAttribute");
                au.Property(t => t.DarkAttribute).HasColumnName("DarkAttribute");
                au.Property(t => t.HolyAttribute).HasColumnName("HolyAttribute");
                au.Property(t => t.SoulCrystal1).HasColumnName("SoulCrystal1");
                au.Property(t => t.SoulCrystal2).HasColumnName("SoulCrystal2");
                au.Property(t => t.SoulCrystal3).HasColumnName("SoulCrystal3");
                au.Property(t => t.ItemName).HasColumnName("ItemName");

            });

            builder.OwnsOne(au => au.VisualInfo, au => {
                au.Property(t => t.VisualId).HasColumnName("VisualId");
                au.Property(t => t.VisualIdName).HasColumnName("VisualIdName");
            });
        }
    }
}
