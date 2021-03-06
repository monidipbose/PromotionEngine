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
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            int expectedTotal = 100;
            Assert.Equal(expectedTotal, calculateTotal
                .GetTotal(_calculateTotalFixture.items, _calculateTotalFixture.promotions, _calculateTotalFixture.cart1));
        }
        [Fact]
        public void GetTotal_GivenItemsPromotionsCart2Values_ReturnTotalCartValueAsInt()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            int expectedTotal = 370;
            Assert.Equal(expectedTotal, calculateTotal
                .GetTotal(_calculateTotalFixture.items, _calculateTotalFixture.promotions, _calculateTotalFixture.cart2));
        }
        [Fact]
        public void GetTotal_GivenItemsPromotionsCart3Values_ReturnTotalCartValueAsInt()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            int expectedTotal = 280;
            Assert.Equal(expectedTotal, calculateTotal
                .GetTotal(_calculateTotalFixture.items, _calculateTotalFixture.promotions, _calculateTotalFixture.cart3));
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

        [Fact]
        public void applyPromoOnMultiple_GivenItemNamesItemPricesQuantitiesAndPromotion_ReturnTotalAmountForThisItemsAfterApplyPromotion()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            List<char> itemNames = new List<char> { 'C', 'D' };
            List<int> itemPrices = new List<int> { 20, 15 };
            List<int> itemQuantities = new List<int> { 1, 1 };
            int result = calculateTotal
                .applyPromoOnMultiple(itemNames, itemPrices, itemQuantities, calculateTotal.GetPromotion('C', _calculateTotalFixture.promotions));
            int expectedAmount = 30;
            Assert.Equal(expectedAmount, result);
        }
        [Fact]
        public void applyPromoOnMultiple_GivenItemNamesItemPricesQuantitiesAndPromotion_ReturnZeroAsQuantityIsLesserForApplyingPromotion()
        {
            var calculateTotal = _calculateTotalFixture.calculateTotal;
            List<char> itemNames = new List<char> { 'C', 'D' };
            List<int> itemPrices = new List<int> { 20, 15 };
            List<int> itemQuantities = new List<int> { 1, 0 };
            int result = calculateTotal
                .applyPromoOnMultiple(itemNames, itemPrices, itemQuantities, calculateTotal.GetPromotion('C', _calculateTotalFixture.promotions));
            int expectedAmount = 0;
            Assert.Equal(expectedAmount, result);
        }
    }
}
