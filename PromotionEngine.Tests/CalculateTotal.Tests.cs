using PromotionEngine.Models;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class CalculateTotalTests
    {
        [Fact]
        public void GetTotal_GivenItemsPromotionsCart1Values_ReturnTotalCartValueAsInt()
        {
            var calculateTotal = new CalculateTotal();
            List<Item> items = data.Items;
            List<Promotion> promotions = data.Promotions;
            Cart cart1 = data.Cart1;
            int expectedTotal = 100;
            Assert.Equal(expectedTotal, calculateTotal
                .GetTotal(items, promotions, cart1));
        }
    }
}
