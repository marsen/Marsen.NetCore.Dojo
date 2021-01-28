using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        private readonly CartService _cartService = new();

        [Fact]
        public void No_product_cart_TOTAL_PRICE_should_be_0()
        {
            _cartService.TotalPrice.Should().Be(0);
        }
    }

    public class CartService
    {
        public int TotalPrice { get; set; }
    }
}