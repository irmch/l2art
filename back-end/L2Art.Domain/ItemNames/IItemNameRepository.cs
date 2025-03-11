using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.ItemNames
{
    public interface IItemNameRepository
    {
        Task<ItemName?> GetItemByItemId(int itemName, CancellationToken cancellationToken);
        void Add(ItemName entity);
    }
}
