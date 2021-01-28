using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class ProductTests
    {
        private Product _product;

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_0_SubTotal_Should_Be_0()
        {
            GivePriceAndQty(10, 0);
            _product.SubTotal.Should().Be(0);
        }

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_1_SubTotal_Should_Be_10()
        {
            GivePriceAndQty(10, 1);
            _product.SubTotal.Should().Be(10);
        }

        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_2_SubTotal_Should_Be_20()
        {
            GivePriceAndQty(10, 2);
            _product.SubTotal.Should().Be(20);
        }

        [Fact]
        public void When_Product_A_Price_is_7_Qty_is_2_SubTotal_Should_Be_14()
        {
            GivePriceAndQty(7, 2);
            _product.SubTotal.Should().Be(14);
        }


        private void GivePriceAndQty(int price, int qty)
        {
            _product = new Product("A", price, qty);
        }
    }
}