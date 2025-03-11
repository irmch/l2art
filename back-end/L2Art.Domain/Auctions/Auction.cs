using ErrorOr;
using L2Art.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Auctions
{
    public class Auction : Entity
    {
        public ItemMetaData ItemMetaData { get; private set; }
        public ItemInfo ItemInfo { get; private set; }
        public VisualInfo VisualInfo { get; private set; }
        public bool isActive {  get; private set; }
        public DateTime CreatedAt {  get; private set; }
        public DateTime UpdatedAt {  get; private set; }
        private Auction() {}

        private Auction(Guid id, ItemMetaData itemMetaData, ItemInfo itemInfo, VisualInfo visualInfo) : base(id)
        {
            ItemMetaData = itemMetaData;
            ItemInfo = itemInfo;
            VisualInfo = visualInfo;
            isActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static ErrorOr<Auction> Create(ItemMetaData itemMetaData, ItemInfo itemInfo, VisualInfo visualInfo) 
        {
            var auction =  new Auction(Guid.NewGuid(), itemMetaData, itemInfo, visualInfo);

            return auction;
        }

        public void ChangeAuctionStatus(bool status)
        {
            isActive = status;
        }
    }
}
