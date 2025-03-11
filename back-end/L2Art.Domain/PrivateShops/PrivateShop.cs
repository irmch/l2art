using ErrorOr;
using L2Art.Domain.Abstractions;
using L2Art.Domain.PrivateShops.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.PrivateShops
{
    public class PrivateShop : Entity
    {
        public ItemCount ItemCount { get; private set; }
        public TraderInfo TraderInfo { get; private set; }
        public ItemInfo ItemInfo { get; private set; }
        public VisualInfo VisualInfo { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private PrivateShop() { }

        private PrivateShop(Guid id, ItemCount itemCount, TraderInfo traderInfo, ItemInfo itemInfo, VisualInfo visualInfo) : base(id)
        {
            Id = id;
            ItemCount = itemCount;
            TraderInfo = traderInfo;
            ItemInfo = itemInfo;    
            VisualInfo = visualInfo;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public static PrivateShop Create(ItemCount itemCount, TraderInfo traderInfo, ItemInfo itemInfo, VisualInfo visualInfo)
        {
            var privateShop = new PrivateShop(
                    Guid.NewGuid(),
                    itemCount,
                    traderInfo,
                    itemInfo,
                    visualInfo
                );
            privateShop.RaiseDomainEvent(new PrivateShopCreatedDomainEvent(privateShop.Id));
            return privateShop;
        }

        public void Update(ItemCount itemCount, TraderInfo traderInfo, ItemInfo itemInfo, VisualInfo visualInfo)
        {
            ItemCount = itemCount;
            TraderInfo = traderInfo;
            ItemInfo = itemInfo;
            VisualInfo = visualInfo;
            UpdatedAt = DateTime.UtcNow;

            RaiseDomainEvent(new PrivateShopUpdatedDomainEvent(Id));
        }

        public void ChangeShopActiveStatus(bool isActiveStatus)
        {
            IsActive = isActiveStatus;
        }

    }
}
