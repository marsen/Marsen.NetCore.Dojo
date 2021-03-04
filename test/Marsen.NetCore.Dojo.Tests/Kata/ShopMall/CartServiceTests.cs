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
        private Product milk = new Product {Name = "Milk", Price = 10};

        [Fact]
        public void TestCartTotal()
        {
            Cart cart = new Cart();
            cart = _cartService.PutIn(new CartProduct(milk, 1),cart);
            cart.TotalPrice.Should().Be(10);
        }

        [Fact]
        public void TestCartSubtotal()
        {
            CartProduct cartProduct = new CartProduct(milk, 1);
            Assert.Equal(cartProduct.SubTotal, 10);
        }
    }
}