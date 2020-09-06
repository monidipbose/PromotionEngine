using System;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public bool OnSingleItem { get; set; }
        public bool IsFixedPrice { get; set; }
        public List<Char> Items { get; set; }
        public List<int> Quantity { get; set; }
        public int Price { get; set; }
        public int DiscountPercent { get; set; }
    }
}
