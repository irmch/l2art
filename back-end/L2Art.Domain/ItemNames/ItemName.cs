using L2Art.Domain.Abstractions;
using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.ItemNames
{
    public class ItemName : Entity
    {
        public int? ItemId { get; private set; }
        public string? Name { get; private set; }
        public string?[]? AdditionalName { get; private set; }
        public string? Description { get; private set; }
        public int? Popup { get; private set; }
        public string? DefaultAction { get; private set; }
        public int? UseOrder { get; private set; }
        public int? NameClass { get; private set; }
        public int? Color { get; private set; }
        public string? TooltipTexture { get; private set; }
        public string? TooltipBGTexture { get; private set; }
        public string? TooltipBGTextureCompare { get; private set; }
        public string? TooltipBGDecoTexture { get; private set; }
        public bool? IsTrade { get; private set; }
        public bool? IsDrop { get; private set; }
        public bool? IsDestruct { get; private set; }
        public bool? IsPrivateStore { get; private set; }
        public int? KeepType { get; private set; }
        public bool? IsNpcTrade { get; private set; }
        public bool? IsCommissionStore { get; private set; }
        public int? EnchantBless { get; private set; }
        public bool? CreateItemsList { get; private set; }
        public int? SortOrder { get; private set; }
        public int? AuctionCategory { get; private set; }

        private ItemName() { }

        private ItemName(Guid id, int? itemId, string? name, string?[]? additionalName, string? description, int? popup, string? defaultAction, int? useOrder, int? nameClass, int? color, string? tooltipTexture, string? tooltipBGTexture, string? tooltipBGTextureCompare, string? tooltipBGDecoTexture, bool? isTrade, bool? isDrop, bool? isDestruct, bool? isPrivateStore, int? keepType, bool? isNpcTrade, bool? isCommissionStore, int? enchantBless, bool? createItemsList, int? sortOrder, int? auctionCategory): base(id)
        {
            ItemId = itemId;
            Name = name;
            AdditionalName = additionalName;
            Description = description;
            Popup = popup;
            DefaultAction = defaultAction;
            UseOrder = useOrder;
            NameClass = nameClass;
            Color = color;
            TooltipTexture = tooltipTexture;
            TooltipBGTexture = tooltipBGTexture;
            TooltipBGTextureCompare = tooltipBGTextureCompare;
            TooltipBGDecoTexture = tooltipBGDecoTexture;
            IsTrade = isTrade;
            IsDrop = isDrop;
            IsDestruct = isDestruct;
            IsPrivateStore = isPrivateStore;
            KeepType = keepType;
            IsNpcTrade = isNpcTrade;
            IsCommissionStore = isCommissionStore;
            EnchantBless = enchantBless;
            CreateItemsList = createItemsList;
            SortOrder = sortOrder;
            AuctionCategory = auctionCategory;
        }

        public static ItemName Create(int? itemId, string? name, string?[]? additionalName, string? description, int? popup, string? defaultAction, int? useOrder, int? nameClass, int? color, string? tooltipTexture, string? tooltipBGTexture, string? tooltipBGTextureCompare, string? tooltipBGDecoTexture, bool? isTrade, bool? isDrop, bool? isDestruct, bool? isPrivateStore, int? keepType, bool? isNpcTrade, bool? isCommissionStore, int? enchantBless, bool? createItemsList, int? sortOrder, int? auctionCategory)
        {

            return new ItemName(Guid.NewGuid(), itemId, name, additionalName, description, popup, defaultAction, useOrder, nameClass, color, tooltipTexture, tooltipBGTexture, tooltipBGTextureCompare, tooltipBGDecoTexture, isTrade, isDrop, isDestruct, isPrivateStore, keepType, isNpcTrade, isCommissionStore, enchantBless, createItemsList, sortOrder, auctionCategory);
        }
    }
}
