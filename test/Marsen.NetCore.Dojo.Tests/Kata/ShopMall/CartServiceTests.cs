using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        [Fact]
        public void No_product_cart_TOTAL_PRICE_should_be_0()
        {
            CartService cartService = new CartService();
            Assert.Equal(cartService.TotalPrice, 0);
        }
    }

    public class CartService
    {
        public int TotalPrice { get; set; }
    }
}