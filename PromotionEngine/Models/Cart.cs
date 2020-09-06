using System;
using System.Collections.Generic;

namespace PromotionEngine.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Char> Items { get; set; }
        public List<int> Quantity { get; set; }
    }
}
