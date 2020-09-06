using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine
{
    public static class data
    {
        public static List<Item> Items = new List<Item>
        {
            new Item{Name='A',Price=50},
            new Item{Name='B',Price=30},
            new Item{Name='C',Price=20},
            new Item{Name='D',Price=15},
        };
        public static List<Promotion> Promotions = new List<Promotion>
        {
            new Promotion{Id=0,OnSingleItem=true,IsFixedPrice=true,Items=new List<char>(){'A'},Quantity=new List<int>(){3},Price=130 },
            new Promotion{Id=1,OnSingleItem=true,IsFixedPrice=true,Items=new List<char>(){'B'},Quantity=new List<int>(){2},Price=45 },
            new Promotion{Id=2,OnSingleItem=false,IsFixedPrice=true,Items=new List<char>(){'C','D'},Quantity=new List<int>(){1,1},Price=30 },
        };
        public static Cart Cart1 = new Cart
        {
            Id = 0,
            Items = new List<char> { 'A', 'B', 'C' },
            Quantity = new List<int> { 1, 1, 1 }
        };
        public static Cart Cart2 = new Cart
        {
            Id = 0,
            Items = new List<char> { 'A', 'B', 'C' },
            Quantity = new List<int> { 5, 5, 1 }
        };
        public static Cart Cart3 = new Cart
        {
            Id = 0,
            Items = new List<char> { 'A', 'B', 'C', 'D' },
            Quantity = new List<int> { 3, 5, 1, 1 }
        };
    }
}
