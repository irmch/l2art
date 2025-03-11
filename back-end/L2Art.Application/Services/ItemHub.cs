using L2Art.Application.Auctions.Query;
using L2Art.Application.PrivateShops.Query;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace L2Art.Application.Services
{
    public class ItemHub : Hub
    {
        private readonly IMediator _mediator;

        public ItemHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Subscribe()
        {
            Console.WriteLine($"✅ Client subscribed: {Context.ConnectionId}");
            await Clients.Caller.SendAsync("SubscriptionConfirmed", "You are now subscribed!");
        }

        public override async Task OnConnectedAsync()
        {
            var token = new CancellationTokenSource().Token;
            var privateShops = await _mediator.Send(new GetUnderpricedItemsQuery(), token);
            var auctionItems = await _mediator.Send(new GetUnderpricedAuctionItemsQuery(), token);

            if (privateShops.IsError)
            {
                Console.WriteLine("Error while getting private shops data: " + privateShops.FirstError);
                return;
            }

            if (auctionItems.IsError)
            {
                Console.WriteLine("Error while getting auction data: " + auctionItems.FirstError);
                return;
            }

            await Clients.Caller.SendAsync("BestDealPrivateShops_init", JsonSerializer.Serialize(privateShops.Value));
            await Clients.Caller.SendAsync("BestDealAuction_init", JsonSerializer.Serialize(auctionItems.Value));

            await base.OnConnectedAsync();
        }
    }
}
