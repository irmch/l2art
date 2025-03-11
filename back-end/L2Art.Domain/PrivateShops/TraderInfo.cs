using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.PrivateShops
{
    public record TraderInfo(
            string VendorName,
            int VendorId, 
            byte StoreType,
            long Price,
            int x,
            int y,
            int z,
            short TypeOfModification,
            int ObjectId,
            int ItemId,
            long Quantity,
            int StoreItemType,
            string ItemName
        );
}
