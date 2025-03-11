using ErrorOr;
using L2Art.Application.Users.Command;
using L2Art.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace L2Art.Api.Controllers.Authorization
{
    public static class AuthorizationEndpoints
    {
        public static IEndpointRouteBuilder MapAuthorizationEndpointsBuilder(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/");
            group.MapPost("registration", Registration)
                .WithName(nameof(Registration));

            group.MapPost("login", Login)
                .WithName(nameof(Login));

            return group;
        }

        public static async Task<IResult> Registration([FromBody] RegistrationRequest authorizationData, ISender sender, CancellationToken cancellationToken)
        {
            var command = new UserRegistrationCommand(authorizationData.userName, authorizationData.email, authorizationData.password);
            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(success), error => Results.BadRequest(error));
        }

        public static async Task<IResult> Login([FromBody] LoginRequest authorizationData, ISender sender, CancellationToken cancellationToken)
        {
            var command = new UserLoginCommand(authorizationData.email, authorizationData.password);
            var res = await sender.Send(command, cancellationToken);

            return res.Match(success => Results.Ok(), error => Results.BadRequest(error));
        }
    }
}
