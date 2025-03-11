using ErrorOr;
using L2Art.Domain.PrivateShops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Infrastructure.Repository
{
    internal class PrivateShopsRepository : Repository<PrivateShop>, IPrivateShopsRepository
    {
        public PrivateShopsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override void Add(PrivateShop booking)
        {
            _DbContext.Add(booking);
        }

        public async Task<List<PrivateShop>> GetSimilarPrivateShopsByIdAndEnchant(int itemId, int enchant, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>().Where(shop => shop.TraderInfo.ItemId == itemId && shop.ItemInfo.Enchant == enchant).ToListAsync();
        }

        public async Task<PrivateShop> GetByIdAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>().Where(shop => shop.Id == guid).FirstOrDefaultAsync();
        }

        public async Task<List<PrivateShop>> GetPrivateShopsByParams(
                int? itemCount,
                string? vendorName,
                int? vendorId,
                byte? storeType,
                long? price,
                int? x,
                int? y,
                int? z,
                short? typeOfModification,
                int? objectId,
                int? itemId,
                long? quantity,
                int? storeItemType,
                long? itemSlot,
                short? enchant,
                int? ls1,
                int? ls2,
                int? ls3,
                short? attributeType,
                short? weaponAttributeStat,
                short? waterAttribute,
                short? fireAttribute,
                short? earthAttribute,
                short? windAttribute,
                short? darkAttribute,
                short? holyAttribute,
                int? soulCrystal1,
                int? soulCrystal2,
                int? soulCrystal3,
                int? visualId,
                CancellationToken cancellationToken
            )
        {
            var query = _DbContext.Set<PrivateShop>().AsQueryable();

            if (itemCount.HasValue)
            {
                query = query.Where(ps => ps.ItemCount.itemCount == itemCount.Value);
            }

            if (!string.IsNullOrEmpty(vendorName))
            {
                query = query.Where(ps => ps.TraderInfo.VendorName == vendorName);
            }

            if (vendorId.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.VendorId == vendorId.Value);
            }

            if (storeType.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.StoreType == storeType.Value);
            }

            if (price.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.Price == price.Value);
            }

            if (x.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.x == x.Value);
            }

            if (y.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.y == y.Value);
            }

            if (z.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.z == z.Value);
            }

            if (typeOfModification.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.TypeOfModification == typeOfModification.Value);
            }

            if (objectId.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.ObjectId == objectId.Value);
            }

            if (itemId.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.ItemId == itemId.Value);
            }

            if (quantity.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.Quantity == quantity.Value);
            }

            if (storeItemType.HasValue)
            {
                query = query.Where(ps => ps.TraderInfo.StoreItemType == storeItemType.Value);
            }

            if (itemSlot.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.ItemSlot == itemSlot.Value);
            }

            if (enchant.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.Enchant == enchant.Value);
            }

            if (ls1.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.Ls1 == ls1.Value);
            }

            if (ls2.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.Ls2 == ls2.Value);
            }

            if (ls3.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.Ls3 == ls3.Value);
            }

            if (attributeType.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.AttributeType == attributeType.Value);
            }

            if (weaponAttributeStat.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.WeaponAttributeStat == weaponAttributeStat.Value);
            }

            if (waterAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.WaterAttribute == waterAttribute.Value);
            }

            if (fireAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.FireAttribute == fireAttribute.Value);
            }

            if (earthAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.EarthAttribute == earthAttribute.Value);
            }

            if (windAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.WindAttribute == windAttribute.Value);
            }

            if (darkAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.DarkAttribute == darkAttribute.Value);
            }

            if (holyAttribute.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.HolyAttribute == holyAttribute.Value);
            }

            if (soulCrystal1.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.SoulCrystal1 == soulCrystal1.Value);
            }

            if (soulCrystal2.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.SoulCrystal2 == soulCrystal2.Value);
            }

            if (soulCrystal3.HasValue)
            {
                query = query.Where(ps => ps.ItemInfo.SoulCrystal3 == soulCrystal3.Value);
            }

            if (visualId.HasValue)
            {
                query = query.Where(ps => ps.VisualInfo.VisualId == visualId.Value);
            }

            return await query.ToListAsync(cancellationToken);
        }


        public async Task<List<PrivateShop>> GetAllPrivateShops(byte privateShopType, CancellationToken cancellationToken)
        {
            if (privateShopType == 0)
            {
                return await _DbContext.Set<PrivateShop>()
                    .Where((shop) => shop.TraderInfo.StoreType == 0)
                    .ToListAsync(cancellationToken);
            } else if (privateShopType == 1)
            {
                return await _DbContext.Set<PrivateShop>()
                    .Where((shop) => shop.TraderInfo.StoreType == 1)
                    .ToListAsync(cancellationToken);
            } else
            {
                return await _DbContext.Set<PrivateShop>().ToListAsync(cancellationToken);
            }
        }

        public async Task<PrivateShop?> GetByObjectIdAndVendorId(int objectId, int vendorId, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>()
                .Where(
                    ti => ti.TraderInfo.ObjectId == objectId &&
                    ti.TraderInfo.VendorId == vendorId
                )
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<PrivateShop>> GetAllActiveShopsAsync(CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>()
                .Where(
                    ia => ia.IsActive == true
                )
                .ToListAsync(cancellationToken);
        }

        public async Task<PrivateShop?> GetPrivateShopByObjectId(int objectId, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>()
                .Where(
                    ti => ti.TraderInfo.ObjectId == objectId
                )
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PrivateShop?> GetActivePrivateShopByObjectId(int objectId, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>()
                .Where(
                    ti => ti.TraderInfo.ObjectId == objectId &&
                    ti.IsActive == true
                )
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<PrivateShop>> GetPrivateShopsByItemId(int itemId, CancellationToken cancellationToken)
        {
            return await _DbContext.Set<PrivateShop>()
                .Where(
                    ti => ti.TraderInfo.ItemId == itemId
                ).ToListAsync();
        }
    }
}
