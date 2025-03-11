using ErrorOr;
using L2Art.Domain.Abstractions;
using L2Art.Domain.ItemNames;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Application.ItemNames.Command
{
    internal sealed class ItemNameCommandHandler : IRequestHandler<ItemNameCommand, ErrorOr<ItemName>>
    {
        private readonly IItemNameRepository _itemNameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ItemNameCommandHandler(IItemNameRepository itemNameRepository, IUnitOfWork unitOfWork)
        {
            _itemNameRepository = itemNameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<ItemName>> Handle(ItemNameCommand request, CancellationToken cancellationToken)
        {
            var itemName = ItemName.Create(
                    request.ItemId,
                    request.Name,
                    request.AdditionalName,
                    request.Description,
                    request.Popup,
                    request.DefaultAction,
                    request.UseOrder,
                    request.NameClass,
                    request.Color,
                    request.TooltipTexture,
                    request.TooltipBGTexture,
                    request.TooltipBGTextureCompare,
                    request.TooltipBGDecoTexture,
                    request.IsTrade,
                    request.IsDrop,
                    request.IsDestruct,
                    request.IsPrivateStore,
                    request.KeepType,
                    request.IsNpcTrade,
                    request.IsCommissionStore,
                    request.EnchantBless,
                    request.CreateItemsList,
                    request.SortOrder,
                    request.AuctionCategory
                );

            _itemNameRepository.Add(itemName);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return itemName;
        }
    }
}
