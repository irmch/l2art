using L2Art.Application.PrivateShops;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ErrorOr;
using L2Art.Application.PrivateShops.Command;
using L2Art.Application.PrivateShops.Query;

namespace L2Art.Api.Controllers.PrivateStore
{
    public static class PrivateStoreEndpoints
    {
        public static IEndpointRouteBuilder MapPrivateStoreEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder.MapGroup("/api/private-shop");

            endpoints.MapGet(string.Empty, GetAllPrivateShops)
                .WithName(nameof(GetAllPrivateShops));

            endpoints.MapPost(string.Empty, CreatePrivateStore)
                .WithName(nameof(CreatePrivateStore));

            endpoints.MapGet("{ItemId:int}", GetPrivateShopsByItemId)
                .WithName(nameof(GetPrivateShopsByItemId));

            return endpoints;
        }

        public static async Task<IResult> GetAllPrivateShops(ISender sender, CancellationToken cancellationToken)
        {
            var query = new GetPrivateShopsQuery();

            var res = await sender.Send(query, cancellationToken);

            return res.Match(
                    success => Results.Ok(success),
                    error => Results.NotFound(error)
                );
        }

        public static async Task<IResult> GetPrivateShopsByItemId(int ItemId, ISender sender, CancellationToken cancellationToken)
        {
            var command = new GetPrivateShopsByItemIdQuery(ItemId);

            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.NotFound(error));
        }

        public static async Task<IResult> CreatePrivateStore([FromBody] PrivateStoreRequest privateStore, ISender sender, CancellationToken cancellationToken)
        {
            var command = new PrivateShopsNewItemCommand(
                privateStore.itemCount,
                privateStore.VendorName,
                privateStore.VendorId,
                privateStore.StoreType,
                privateStore.Price,
                privateStore.x,
                privateStore.y,
                privateStore.z,
                privateStore.TypeOfModification,
                privateStore.ObjectId,
                privateStore.ItemId,
                privateStore.Quantity,
                privateStore.StoreItemType,
                privateStore.ItemSlot,
                privateStore.Enchant,
                privateStore.Ls1,
                privateStore.Ls2,
                privateStore.Ls3,
                privateStore.AttributeType,
                privateStore.WeaponAttributeStat,
                privateStore.WaterAttribute,
                privateStore.FireAttribute,
                privateStore.EarthAttribute,
                privateStore.WindAttribute,
                privateStore.DarkAttribute,
                privateStore.HolyAttribute,
                privateStore.SoulCrystal1,
                privateStore.SoulCrystal2,
                privateStore.SoulCrystal3,
                privateStore.VisualId
            );
            var res = await sender.Send(command, cancellationToken);
            return res.Match(
                success => Results.Ok(success),
                error => Results.BadRequest(error)
            );
        }
    }
}
