using L2Art.Domain.Auctions;
using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Abstractions
{
    public interface IPrivateShopItemTradingService
    {
        List<PrivateShop> FindBestDealsPrivateShop(List<PrivateShop> privateShops, double maxOverpricePercentage, double minDiscountPercentage);
        List<Auction> FindBestDealsAuction(List<Auction> privateShops, double maxOverpricePercentage, double minDiscountPercentage);
    }
}
