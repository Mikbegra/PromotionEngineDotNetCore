using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionAPI.Model
{
    public class Order
    {
        public List<Item> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
