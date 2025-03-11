using L2Art.Domain.ItemNames;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Configurations
{
    internal class ItemNameConfiguration : IEntityTypeConfiguration<ItemName>
    {
        public void Configure(EntityTypeBuilder<ItemName> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ItemId);
            builder.Property(x => x.Name);
            builder.Property(x => x.AdditionalName);
            builder.Property(x => x.Description);
            builder.Property(x => x.Popup);
            builder.Property(x => x.DefaultAction);
            builder.Property(x => x.UseOrder);
            builder.Property(x => x.NameClass);
            builder.Property(x => x.Color);
            builder.Property(x => x.TooltipTexture);
            builder.Property(x => x.TooltipBGTexture);
            builder.Property(x => x.TooltipBGTextureCompare);
            builder.Property(x => x.TooltipBGDecoTexture);
            builder.Property(x => x.IsTrade);
            builder.Property(x => x.IsDrop);
            builder.Property(x => x.IsDestruct);
            builder.Property(x => x.IsPrivateStore);
            builder.Property(x => x.KeepType);
            builder.Property(x => x.IsNpcTrade);
            builder.Property(x => x.IsCommissionStore);
            builder.Property(x => x.EnchantBless);
            builder.Property(x => x.CreateItemsList);
            builder.Property(x => x.SortOrder);
            builder.Property(x => x.AuctionCategory);
        }
    }
}
