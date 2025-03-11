using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2Art.Domain.PrivateShops;
using MediatR;
using ErrorOr;
using System.Runtime.InteropServices;
using System.Diagnostics;
using L2Art.Domain.Abstractions;
using L2Art.Application.PrivateShops.Command;
using L2Art.Domain.Services;
using L2Art.Domain.ItemNames;

namespace L2Art.Application.PrivateShops.Command
{
    internal sealed class PrivateShopsNewItemCommandHandler : IRequestHandler<PrivateShopsNewItemCommand, ErrorOr<PrivateShop>>
    {
        private readonly IPrivateShopsRepository _PrivateShopsRepository;
        private readonly IItemNameRepository _itemNameRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public PrivateShopsNewItemCommandHandler(IPrivateShopsRepository PrivateShopsRepository, IItemNameRepository itemNameRepository, IUnitOfWork unitOfWork)
        {
            _PrivateShopsRepository = PrivateShopsRepository;
            _itemNameRepository = itemNameRepository;
            _UnitOfWork = unitOfWork;
        }
        public async Task<ErrorOr<PrivateShop>> Handle(PrivateShopsNewItemCommand request, CancellationToken cancellationToken)
        {
            var activePrivateShop = await _PrivateShopsRepository.GetActivePrivateShopByObjectId(request.ObjectId, cancellationToken);

            if (activePrivateShop is not null)
            {
                activePrivateShop.Update(activePrivateShop.ItemCount, activePrivateShop.TraderInfo, activePrivateShop.ItemInfo, activePrivateShop.VisualInfo);
                await _UnitOfWork.SaveChangesAsync();
                return activePrivateShop;
            }
            else
            {
                var item = await _itemNameRepository.GetItemByItemId(request.ItemId, cancellationToken);

                var itemCount = new ItemCount(
                    request.itemCount
                );

                var itemInfo = new ItemInfo(
                        request.ItemSlot,
                        request.Enchant,
                        request.Ls1,
                        request.Ls2,
                        request.Ls3,
                        request.AttributeType,
                        request.WeaponAttributeStat,
                        request.WaterAttribute,
                        request.FireAttribute,
                        request.EarthAttribute,
                        request.WindAttribute,
                        request.DarkAttribute,
                        request.HolyAttribute,
                        request.SoulCrystal1,
                        request.SoulCrystal2,
                        request.SoulCrystal3
                    );

                var traderInfo = new TraderInfo(
                        request.VendorName,
                        request.VendorId,
                        request.StoreType,
                        request.Price,
                        request.x,
                        request.y,
                        request.z,
                        request.TypeOfModification,
                        request.ObjectId,
                        request.ItemId,
                        request.Quantity,
                        request.StoreItemType,
                        item.Name
                    );

                var visualInfo = new VisualInfo(
                        request.VisualId,
                        request.VisualId.ToString() // need to change
                    );

                var newPrivateShop = PrivateShop.Create(itemCount, traderInfo, itemInfo, visualInfo);

                _PrivateShopsRepository.Add(newPrivateShop);
                await _UnitOfWork.SaveChangesAsync();

                return newPrivateShop;
            }
        }
    }
}
