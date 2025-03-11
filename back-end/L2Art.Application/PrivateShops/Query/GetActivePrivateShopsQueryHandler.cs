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
    public class GetActivePrivateShopsQueryHandler : IRequestHandler<GetActivePrivateShopsQuery, ErrorOr<List<PrivateShop>>>
    {
        private readonly IPrivateShopsRepository _privateShopsRepository; 
        public GetActivePrivateShopsQueryHandler(IPrivateShopsRepository privateShopsRepository)
        {
            _privateShopsRepository = privateShopsRepository;
        }

        public async Task<ErrorOr<List<PrivateShop>>> Handle(GetActivePrivateShopsQuery request, CancellationToken cancellationToken)
        {
            var activePrivateShops = await _privateShopsRepository.GetAllActiveShopsAsync(cancellationToken);

            return activePrivateShops;
        }
    }
}
