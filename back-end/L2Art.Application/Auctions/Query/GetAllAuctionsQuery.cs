using ErrorOr;
using L2Art.Domain.Auctions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.Auctions.Query
{
    public record GetAllAuctionsQuery() : IRequest<ErrorOr<List<Auction>>>;
}
