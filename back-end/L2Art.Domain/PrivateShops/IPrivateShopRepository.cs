using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.PrivateShops
{
    public interface IPrivateShopsRepository
    {
        Task<PrivateShop> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<PrivateShop>> GetSimilarPrivateShopsByIdAndEnchant(int itemId, int enchant, CancellationToken cancellationToken);
        Task<PrivateShop> GetByObjectIdAndVendorId(int objectId, int vendorId, CancellationToken cancellationToken);
        Task<List<PrivateShop>> GetAllPrivateShops(byte privateShopType, CancellationToken cancellationToken);
        Task<List<PrivateShop>> GetPrivateShopsByParams(
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
            );
        Task<List<PrivateShop>> GetAllActiveShopsAsync(CancellationToken cancellationToken);
        Task<PrivateShop?> GetPrivateShopByObjectId(int objectId, CancellationToken cancellationToken);
        Task<PrivateShop?> GetActivePrivateShopByObjectId(int objectId, CancellationToken cancellationToken);
        Task<List<PrivateShop>> GetPrivateShopsByItemId(int itemId, CancellationToken cancellationToken);

        void Add(PrivateShop booking);

    }
}
