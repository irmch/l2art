using L2Art.Application.Auctions.Command;
using L2Art.Application.Auctions.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace L2Art.Api.Controllers.Auction
{
    public static class AuctionEndpoint
    {
        public static IEndpointRouteBuilder MapAuctionEndpointsBuilder(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/auction");

            group.MapGet(string.Empty, GetAllActiveAuctions);
            group.MapGet("{itemId:int}", GetAuctionsByItemId);

            group.MapPost(string.Empty, CreateAuction);

            return group;
        }

        public async static Task<IResult> CreateAuction([FromBody] AuctionRequest auctionRequest, ISender sender, CancellationToken cancellationToken)
        {
            var command = new AuctionNewItemCommand(
                    auctionRequest.CommissionId,
                    auctionRequest.PricePerUnit,
                    auctionRequest.CommissionItemType,
                    auctionRequest.DurationInDays,
                    auctionRequest.EpochSecondEndTime,
                    auctionRequest.SellerName,
                    auctionRequest.TypeOfModification,
                    auctionRequest.ObjectId,
                    auctionRequest.ItemId,
                    auctionRequest.Count,
                    auctionRequest.StoreItemType,
                    auctionRequest.ItemSlot,
                    auctionRequest.Enchant,
                    auctionRequest.AttributeType,
                    auctionRequest.WeaponAttributeStat,
                    auctionRequest.WaterAttribute,
                    auctionRequest.FireAttribute,
                    auctionRequest.EarthAttribute,
                    auctionRequest.WindAttribute,
                    auctionRequest.DarkAttribute,
                    auctionRequest.HolyAttribute,
                    auctionRequest.SoulCrystal1,
                    auctionRequest.SoulCrystal2,
                    auctionRequest.SoulCrystal3,
                    auctionRequest.VisualId
                );
            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.BadRequest(error));
        }

        public async static Task<IResult> GetAllActiveAuctions(ISender sender, CancellationToken cancellationToken)
        {
            var command = new GetAllAuctionsQuery();

            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.BadRequest(error));
        }

        public async static Task<IResult> GetAuctionsByItemId(int itemId, ISender sender, CancellationToken cancellationToken)
        {
            var command = new GetAuctionsByItemIdQuery(itemId);

            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.NotFound(error));
        }
    }
}
