using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        private readonly CartService _cartService = new();
        private readonly Product _10PriceProduct = new("A", 10, 1);
        private readonly Product _7PriceProduct = new("B", 7, 1);

        [Fact]
        public void No_product_cart_TOTAL_PRICE_should_be_0()
        {
            _cartService.TotalPrice.Should().Be(0);
        }

        [Fact]
        public void There_is_one_Product_A_in_cart_TOTAL_PRICE_should_be_10()
        {
            _cartService.Add(_10PriceProduct);
            _cartService.TotalPrice.Should().Be(10);
        }

        [Fact]
        public void There_is_one_Product_B_in_cart_TOTAL_PRICE_should_be_7()
        {
            _cartService.Add(_7PriceProduct);
            _cartService.TotalPrice.Should().Be(7);
        }
    }

    public class CartService
    {
        private List<Product> _products = new();
        public int TotalPrice => _products.Sum(x => x.SubTotal);

        public void Add(Product product)
        {
            _products = new List<Product> {product};
        }
    }
}