using ErrorOr;
using L2Art.Domain.Auctions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Repository
{
    internal class AuctionRepository : Repository<Auction>, IAuctionRepository
    {
        public AuctionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddNewAuction(Auction auction)
        {
            _DbContext.Add(auction);
        }

        public async Task<ErrorOr<List<Auction>>> GetAllActiveAuctions(CancellationToken cancellationToken)
        {
            var res = await _DbContext.Set<Auction>().Where(item => item.isActive == true).ToListAsync();

            if (res is null)
            {
                return Error.NotFound("Auctions.NotFound", "Auction active items not found");
            }

            return res;
        }

        public async Task<ErrorOr<Auction>> GetAuctionByCommissionId(long CommissionId, CancellationToken cancellationToken)
        {
            var res = await _DbContext.Set<Auction>().Where(item => item.ItemMetaData.CommissionId == CommissionId).FirstOrDefaultAsync();

            if(res is null)
            {
                return Error.NotFound("Auction.NotFound", "Auction item not found");
            }

            return res;
        }

        public async Task<ErrorOr<List<Auction>>> GetAuctionsByItemId(int itemId, CancellationToken cancellationToken)
        {
            var res = await _DbContext.Set<Auction>().Where(item => item.ItemInfo.ItemId == itemId).ToListAsync();

            if (res is null)
            {
                return Error.NotFound("Auctions.NotFound", "Auctions item not found");
            }

            return res;
        }
    }
}
