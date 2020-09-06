using PromotionEngine.Models;
using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        public static List<Item> items = data.Items;
        public static List<Promotion> promotions = data.Promotions;
        public static Cart cart1 = data.Cart1;
        public static Cart cart2 = data.Cart2;
        public static Cart cart3 = data.Cart3;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Total for Cart 1: " + new CalculateTotal().GetTotal(items, promotions, cart1));
                Console.WriteLine("Total for Cart 2: " + new CalculateTotal().GetTotal(items, promotions, cart2));
                Console.WriteLine("Total for Cart 3: " + new CalculateTotal().GetTotal(items, promotions, cart3));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
