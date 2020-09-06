using PromotionEngine.Models;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class CalculateTotalFixture
    {
        public CalculateTotal calculateTotal => new CalculateTotal();
        public List<Item> items = data.Items;
        public List<Promotion> promotions = data.Promotions;
        public Cart cart1 = data.Cart1;
        public Cart cart2 = data.Cart2;
        public Cart cart3 = data.Cart3;
    }
    public class CalculateTotalTests : IClassFixture<CalculateTotalFixture>
    {
        private CalculateTotalFixture _calculateTotalFixture;
        public CalculateTotalTests(CalculateTotalFixture calculateTotalFixture)
        {
            _calculateTotalFixture = calculateTotalFixture;
        }

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

        [Fact]
        public void GetPromotion_GivenItemNameAndPromotions_ReturnAvailablePromotionForThisItem()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            char itemName = 'A';
            var result = calculateTotal.GetPromotion(itemName, _calculateTotalFixture.promotions);
            Assert.NotNull(result);
            Assert.IsType<Promotion>(result);
            Assert.Equal(130, result.Price);
        }
        [Fact]
        public void GetPromotion_GivenItemNameAndPromotions_ReturnNullAsNoPromotionAvailableForThisItem()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            char itemName = 'E';
            var result = calculateTotal.GetPromotion(itemName, _calculateTotalFixture.promotions);
            Assert.Null(result);
        }

        [Fact]
        public void applyPromoOnSingle_GivenItemNameItemPriceQuantityAndPromotion_ReturnTotalAmountForThisItemAfterApplyPromotion()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            char itemName = 'A';
            int itemPrice = 50;
            int itemQuantity = 5;
            int result = calculateTotal
                .applyPromoOnSingle(itemName, itemPrice, itemQuantity, calculateTotal.GetPromotion(itemName, _calculateTotalFixture.promotions));
            int expectedAmount = 230;
            Assert.Equal(expectedAmount, result);
        }
        [Fact]
        public void applyPromoOnSingle_GivenItemNameItemPriceQuantityAndPromotion_ReturnZeroAsQuantityIsLesserForApplyingPromotion()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            char itemName = 'A';
            int itemPrice = 50;
            int itemQuantity = 1;
            int result = calculateTotal
                .applyPromoOnSingle(itemName, itemPrice, itemQuantity, calculateTotal.GetPromotion(itemName, _calculateTotalFixture.promotions));
            int expectedAmount = 0;
            Assert.Equal(expectedAmount, result);
        }
    }
}
