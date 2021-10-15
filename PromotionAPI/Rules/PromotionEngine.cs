using PromotionAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionAPI.Rules
{
    public class PromotionEngine
    {
        private IEnumerable<SKU> _priceList;
        private IEnumerable<PromotionRules> _promotions;

        public PromotionEngine(IEnumerable<SKU> priceList, IEnumerable<PromotionRules> promotions)
        {
            this._priceList = priceList;
            this._promotions = promotions;
        }

        public void CheckOut(Order order)
        {
            var foundItems = new List<Item>();
            if (_promotions != null && _promotions.Count() > 0)
                foreach (var promotion in _promotions)
                {
                    var validatedItems = promotion.Validate(order, foundItems);
                    UpdateValidatedItems(foundItems, validatedItems);
                }

            ApplyRegularPrice(order, foundItems);
        }

        private void ApplyRegularPrice(Order order, List<Item> foundItems)
        {
            foreach (var item in order.Items)
            {
                var validateItem = foundItems.FirstOrDefault(x => x.SKUId == item.SKUId) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    order.TotalAmount += quantity * _priceList.First(x => x.SKUId == item.SKUId).UnitPrice;
            }
        }

        private static void UpdateValidatedItems(List<Item> foundItems, IEnumerable<Item> validatedItems)
        {
            if (validatedItems == null || validatedItems.Count() < 1)
                return;

            foreach (var item in validatedItems)
                if (!foundItems.Any(x => x.SKUId == item.SKUId))
                    foundItems.Add(item);
        }
    }
}
