using PromotionAPI.Model;
using PromotionAPI.Rules;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionAPI.Tests
{
    public class TestPromotionRules
    {
        /// <summary>
        /// SKU list
        /// </summary>
        static readonly IEnumerable<SKU> PriceList =     new List<SKU> {
        new SKU { SKUId = 'A', UnitPrice = 50 },
        new SKU { SKUId = 'B', UnitPrice = 30 },
        new SKU { SKUId = 'C', UnitPrice = 20 },
        new SKU { SKUId = 'D', UnitPrice = 15 }
        };


        /// <summary>
        /// Promotions
        /// </summary>
        static readonly IEnumerable<PromotionRules> Promotions = new List<PromotionRules> {
                        new PromotionRules {
                          Items = new List<Item> { new Item { SKUId = 'A', Quantity = 3 }},
                          TotalAmount = 130 }, // 3 of A for 130
                        new PromotionRules {
                          Items = new List<Item> {
                            new Item { SKUId = 'B', Quantity = 2 }},
                          TotalAmount = 45 }, // 2 of B for 45
                        new PromotionRules {
                          Items = new List<Item> {
                            new Item { SKUId = 'C', Quantity = 1 },
                            new Item { SKUId = 'D', Quantity = 1 }},
                          TotalAmount = 30 }  // C + D for 30
                        };

        static readonly PromotionEngine promotionEngine = new PromotionEngine(PriceList, Promotions);
        [Fact]
        public void Test_Scenario_A()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKUId = 'A', Quantity = 1 },
            new Item { SKUId = 'B', Quantity = 1 },
            new Item { SKUId = 'C', Quantity = 1 }}
              };

            promotionEngine.CheckOut(order);
            Assert.True(order.TotalAmount == 100);
        }
        [Fact]
        public void Test_Scenario_B()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKUId = 'A', Quantity = 5 },
            new Item { SKUId = 'B', Quantity = 5 },
            new Item { SKUId = 'C', Quantity = 1 }}
              };

            promotionEngine.CheckOut(order);
            Assert.True(order.TotalAmount == 370);
        }
        [Fact]
        public void Test_Scenario_C()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKUId = 'A', Quantity = 3 },
            new Item { SKUId = 'B', Quantity = 5 },
            new Item { SKUId = 'C', Quantity = 1 },
            new Item { SKUId = 'D', Quantity = 1 }}
              };

            promotionEngine.CheckOut(order);
            Assert.True(order.TotalAmount == 280);
        }
    }
}
