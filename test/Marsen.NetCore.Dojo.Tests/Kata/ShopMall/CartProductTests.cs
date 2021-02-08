using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartProductTests
    {
        private CartProduct _cartProduct;

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_0_SubTotal_Should_Be_0()
        {
            GivePriceAndQty(10, 0);
            _cartProduct.SubTotal.Should().Be(0);
        }

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_1_SubTotal_Should_Be_10()
        {
            GivePriceAndQty(10, 1);
            _cartProduct.SubTotal.Should().Be(10);
        }

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_2_SubTotal_Should_Be_20()
        {
            GivePriceAndQty(10, 2);
            _cartProduct.SubTotal.Should().Be(20);
        }

        [Fact]
        public void When_Product_A_Price_is_7_Qty_is_2_SubTotal_Should_Be_14()
        {
            GivePriceAndQty(7, 2);
            _cartProduct.SubTotal.Should().Be(14);
        }


        private void GivePriceAndQty(int price, int qty)
        {
            _cartProduct = new CartProduct(new Product{Name = "A",Price = price}, qty);
            //_cartProduct = new CartProduct("A", price, qty);
        }
    }
}