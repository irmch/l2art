using ErrorOr;
using L2Art.Application.ItemNames.Command;
using L2Art.Domain.ItemNames;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Xml.Linq;

namespace L2Art.Api.Controllers.ItemName
{
    public static class ItemNameEndpoints
    {
        public static IEndpointRouteBuilder MapItemNameEndpointBuilder(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/");
            group.MapPost("new-itemName", CreateItemName).WithName(nameof(CreateItemName));

            return group;
        }

        public static async Task<IResult> CreateItemName([FromBody] ItemNameRequest itemName, ISender sender, CancellationToken cancellationToken)
        {
            var command = new ItemNameCommand(
                    itemName.ItemId,
                    itemName.Name,
                    itemName.AdditionalName,
                    itemName.Description,
                    itemName.Popup,
                    itemName.DefaultAction,
                    itemName.UseOrder,
                    itemName.NameClass,
                    itemName.Color,
                    itemName.TooltipTexture,
                    itemName.TooltipBGTexture,
                    itemName.TooltipBGTextureCompare,
                    itemName.TooltipBGDecoTexture,
                    itemName.IsTrade,
                    itemName.IsDrop,
                    itemName.IsDestruct,
                    itemName.IsPrivateStore,
                    itemName.KeepType,
                    itemName.IsNpcTrade,
                    itemName.IsCommissionStore,
                    itemName.EnchantBless,
                    itemName.CreateItemsList,
                    itemName.SortOrder,
                    itemName.AuctionCategory
                );

            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.BadRequest(error));
        }
    }
}
