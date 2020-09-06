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
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Total for Cart: " + new CalculateTotal().GetTotal(items, promotions, cart1));                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
