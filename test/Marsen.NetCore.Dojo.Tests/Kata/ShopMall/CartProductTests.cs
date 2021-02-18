using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartProductTests
    {
        private CartProduct _cartProduct;
        private readonly Product _10dollar = new() {Name = "A", Price = 10};
        private readonly Product _7dollar = new() {Name = "B", Price = 7};

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_0_SubTotal_Should_Be_0()
        {
            Given(_10dollar, 0);
            _cartProduct.SubTotal.Should().Be(0);
        }


        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_1_SubTotal_Should_Be_10()
        {
            Given(_10dollar, 1);
            _cartProduct.SubTotal.Should().Be(10);
        }

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_2_SubTotal_Should_Be_20()
        {
            Given(_10dollar, 2);
            _cartProduct.SubTotal.Should().Be(20);
        }

        [Fact]
        public void When_Product_A_Price_is_7_Qty_is_2_SubTotal_Should_Be_14()
        {
            Given(_7dollar, 2);
            _cartProduct.SubTotal.Should().Be(14);
        }

        private void Given(Product product, int qty)
        {
            _cartProduct = new CartProduct(product, qty);
        }
    }
}