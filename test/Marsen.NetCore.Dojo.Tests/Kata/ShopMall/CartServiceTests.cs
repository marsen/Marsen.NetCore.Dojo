using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall.Application;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        readonly CartService _cartService = new();

        /// <summary>
        /// Test Data
        /// </summary>
        private Product milk = new() {Name = "Milk", Price = 10};

        [Fact]
        public void TestCartTotal()
        {
            _cartService.PutIn(new CartProduct(milk, 1));
            var cart = _cartService.GetCart();
            cart.TotalPrice.Should().Be(10);
        }

        [Fact]
        public void TestCartSubtotal()
        {
            CartProduct cartProduct = new CartProduct(milk, 1);
            Assert.Equal(10, cartProduct.SubTotal);
        }
    }
}