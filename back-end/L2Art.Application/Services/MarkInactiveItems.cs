using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Services
{
    public class MarkInactiveItemsService
    {
        private readonly IPrivateShopsRepository _privateShopRepository;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MarkInactiveItemsService(IPrivateShopsRepository privateShopsRepository, IAuctionRepository auctionRepository, IUnitOfWork unitOfWork)
        {
            _privateShopRepository = privateShopsRepository;
            _auctionRepository = auctionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PrivateShop>> MarkInactiveItems(TimeSpan expirationTime, CancellationToken cancellationToken)
        {
            var cutoffTime = DateTime.UtcNow - expirationTime;

            var outdatedItems = await _privateShopRepository.GetAllActiveShopsAsync(cancellationToken);
            var changedItems = new List<PrivateShop>();
            foreach (var item in outdatedItems)
            {
                if (item.UpdatedAt < cutoffTime)
                {
                    changedItems.Add(item);
                    item.ChangeShopActiveStatus(false);
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return changedItems;
        }


        public async Task<List<Auction>> MarkInactiveAuction(TimeSpan expirationTime, CancellationToken cancellationToken)
        {
            var cutoffTime = DateTime.UtcNow - expirationTime;

            var outdatedItems = await _auctionRepository.GetAllActiveAuctions(cancellationToken);
            var changedItems = new List<Auction>();
            foreach (var item in outdatedItems.Value)
            {
                if (item.UpdatedAt < cutoffTime)
                {
                    changedItems.Add(item);
                    item.ChangeAuctionStatus(false);
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return changedItems;
        }
    }
}
