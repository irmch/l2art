using L2Art.Domain.Abstractions;
using L2Art.Domain.Auctions;
using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Services
{
    public class PrivateShopTradingService : ItemPriceAnalyzer, IPrivateShopItemTradingService
    {
        public PrivateShopTradingService() 
        {

        }

        public List<Auction> FindBestDealsAuction(List<Auction> privateShops, double maxOverpricePercentage, double minDiscountPercentage)
        {
            return GetProfitableItemsAuction(privateShops, maxOverpricePercentage, minDiscountPercentage);
        }

        public List<PrivateShop> FindBestDealsPrivateShop(List<PrivateShop> privateShops, double maxOverpricePercentage, double minDiscountPercentage)
        {
            return GetProfitableItems(privateShops, maxOverpricePercentage, minDiscountPercentage);
        }
    }
}
