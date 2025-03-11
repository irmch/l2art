using L2Art.Domain.ItemNames;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Repository
{
    internal class ItemNameRepository : Repository<ItemName>, IItemNameRepository
    {
        public ItemNameRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override void Add(ItemName entity)
        {
            _DbContext.Add(entity);
        }

        public async Task<ItemName?> GetItemByItemId(int itemId, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<ItemName>().Where(item => item.ItemId == itemId).FirstOrDefaultAsync();
        }
    }
}
