using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Auctions
{
    public interface IAuctionRepository
    {
        void Add(Auction auction);

        Task<ErrorOr<List<Auction>>> GetAllActiveAuctions(CancellationToken cancellationToken);
        Task<ErrorOr<Auction>> GetAuctionByCommissionId(long CommissionId, CancellationToken cancellationToken);
        Task<ErrorOr<List<Auction>>> GetAuctionsByItemId(int itemId, CancellationToken cancellationToken);
    }
}
