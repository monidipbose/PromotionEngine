using PromotionEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class CalculateTotal
    {
        public int GetTotal(List<Item> items, List<Promotion> promotions, Cart cart)
        {
            List<char> promoAppliedItems = new List<char>();
            int total = 0;
            int i = 0;
            foreach (var item in cart.Items)
            {
                int itemPrice = items.FirstOrDefault(a => a.Name == item).Price;
                if (!promoAppliedItems.Contains(item))
                {
                    var promo = GetPromotion(item, promotions);
                    if (promo != null)
                    {
                        if (promo.OnSingleItem)
                        {
                            int afterPromo = applyPromoOnSingle(item, itemPrice, cart.Quantity[i], promo);
                            if (afterPromo != 0)
                            {
                                total += afterPromo;
                                promoAppliedItems.Add(item);
                            }
                            else
                            {
                                total += itemPrice * cart.Quantity[i];
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        total += (cart.Quantity[i] * itemPrice);
                    }
                }
                i++;
            }
            return total;
        }

        public Promotion? GetPromotion(char item, List<Promotion> promotions)
        {
            foreach (var promotion in promotions)
            {
                if (promotion.Items.Contains(item))
                {
                    return promotion;
                }
            }
            return null;
        }

        public int applyPromoOnSingle(char item, int itemPrice, int quantity, Promotion promotion)
        {
            int total = 0;
            if (quantity >= promotion.Quantity[0])
            {
                total = ((quantity / promotion.Quantity[0]) * promotion.Price) + ((quantity % promotion.Quantity[0]) * itemPrice);
            }
            return total;
        }
    }
}
