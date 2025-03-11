namespace L2Art.Api.Controllers.ItemName
{
    public record ItemNameRequest(
            int ItemId,
            string? Name,
            string?[]? AdditionalName,
            string? Description,
            int? Popup,
            string? DefaultAction,
            int? UseOrder,
            int? NameClass,
            int? Color,
            string? TooltipTexture,
            string? TooltipBGTexture,
            string? TooltipBGTextureCompare,
            string? TooltipBGDecoTexture,
            bool? IsTrade,
            bool? IsDrop,
            bool? IsDestruct,
            bool? IsPrivateStore,
            int? KeepType,
            bool? IsNpcTrade,
            bool? IsCommissionStore,
            int? EnchantBless,
            bool? CreateItemsList,
            int? SortOrder,
            int? AuctionCategory

        )
    {
    }
}
