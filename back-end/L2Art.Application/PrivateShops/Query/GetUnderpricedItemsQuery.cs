using ErrorOr;
using L2Art.Domain.PrivateShops;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.PrivateShops.Query
{
    public record GetUnderpricedItemsQuery : IRequest<ErrorOr<List<PrivateShopResponse>>>
    {
    }
}
