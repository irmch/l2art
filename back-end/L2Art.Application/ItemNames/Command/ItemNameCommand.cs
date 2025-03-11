using ErrorOr;
using L2Art.Domain.ItemNames;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace L2Art.Application.ItemNames.Command
{
    public record ItemNameCommand(
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
            int? AuctionCategory) : IRequest<ErrorOr<ItemName>>
    {
    }
}
