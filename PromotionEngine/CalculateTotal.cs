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
                            List<char> itemsInPromo = promo.Items;
                            List<int> priceOfItemsInPromo = new List<int>();
                            List<int> quantityOfItemsInCart = new List<int>();
                            foreach (var itemInPromo in itemsInPromo)
                            {
                                if (!promoAppliedItems.Contains(itemInPromo) && cart.Items.Contains(itemInPromo))
                                {
                                    priceOfItemsInPromo.Add(items.FirstOrDefault(a => a.Name == itemInPromo).Price);
                                    quantityOfItemsInCart.Add(cart.Quantity[cart.Items.IndexOf(itemInPromo)]);
                                }
                            }
                            if (itemsInPromo.Count == priceOfItemsInPromo.Count)
                            {
                                int afterPromo = applyPromoOnMultiple(itemsInPromo, priceOfItemsInPromo, quantityOfItemsInCart, promo);
                                if (afterPromo != 0)
                                {
                                    total += afterPromo;
                                    foreach (var itemInPromo in itemsInPromo)
                                    {
                                        promoAppliedItems.Add(itemInPromo);
                                    }
                                }
                                else
                                {
                                    total += itemPrice * cart.Quantity[i];
                                }
                            }
                            else
                            {
                                total += itemPrice * cart.Quantity[cart.Items.IndexOf(item)];
                            }
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

        public int applyPromoOnMultiple(List<char> items, List<int> itemsPrice, List<int> quantities, Promotion promotion)
        {
            int total = 0;
            int amount = 0;
            for (int i = 0; i < quantities.Count; i++)
            {
                if (quantities[i] < promotion.Quantity[i])
                {
                    return total;
                }
            }
            while (!quantities.Contains(0))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    quantities[i] = quantities[i] - promotion.Quantity[i];
                }
                amount += promotion.Price;
            }
            total += amount;
            for (int i = 0; i < items.Count; i++)
            {
                total += (quantities[i] * itemsPrice[i]);
            }
            return total;
        }
    }
}
