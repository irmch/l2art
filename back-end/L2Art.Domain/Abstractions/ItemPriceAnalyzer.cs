using L2Art.Domain.Auctions;
using L2Art.Domain.PrivateShops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Abstractions
{
    public abstract class ItemPriceAnalyzer
    {
        protected List<PrivateShop> GetProfitableItems(List<PrivateShop> items, double maxOverpricePercentage, double minDiscountPercentage)
        {
            if (items == null || items.Count == 0)
                return new List<PrivateShop>();

            double medianPrice = GetMedianPrice(items.Select(i => i.TraderInfo.Price).ToList());

            double maxAllowedPrice = medianPrice * (1 + maxOverpricePercentage / 100);
            var filteredItems = items.Where(i => i.TraderInfo.Price <= maxAllowedPrice).ToList();

            double minProfitablePrice = medianPrice * (1 - minDiscountPercentage / 100);
            var profitableItems = filteredItems.Where(i => i.TraderInfo.Price <= minProfitablePrice).ToList();

            return profitableItems;
        }

        protected List<Auction> GetProfitableItemsAuction(List<Auction> items, double maxOverpricePercentage, double minDiscountPercentage)
        {
            if (items == null || items.Count == 0)
                return new List<Auction>();

            double medianPrice = GetMedianPrice(items.Select(i => i.ItemMetaData.PricePerUnit).ToList());

            double maxAllowedPrice = medianPrice * (1 + maxOverpricePercentage / 100);
            var filteredItems = items.Where(i => i.ItemMetaData.PricePerUnit <= maxAllowedPrice).ToList();

            double minProfitablePrice = medianPrice * (1 - minDiscountPercentage / 100);
            var profitableItems = filteredItems.Where(i => i.ItemMetaData.PricePerUnit <= minProfitablePrice).ToList();

            return profitableItems;
        }

        private double GetMedianPrice(List<long> prices)
        {
            if (prices.Count == 0) return 0;
            prices.Sort();
            int mid = prices.Count / 2;
            return prices.Count % 2 != 0 ? prices[mid] : (prices[mid - 1] + prices[mid]) / 2.0;
        }
    }
}
