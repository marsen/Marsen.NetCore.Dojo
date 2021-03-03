using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        readonly CartService _cartService = new();

        #region Test Data
        /// <summary>
        /// Test Data
        /// </summary>
        private Product milk = new() {Name = "Milk", Price = 10};
        
        private readonly Product oil = new() {Name = "Oil", Price = 7};
        
        private readonly Product bun = new() {Name = "Bun", Price = 6};
        #endregion

        [Theory]
        [InlineData(1,0,0,10)]
        [InlineData(1,1,0,17)]
        [InlineData(1,0,1,16)]
        [InlineData(1,1,1,23)]
        [InlineData(2,3,4,65)]
        public void TestCartTotal(int qtyOfMilk,int qtyOfOil,int qtyOfBun,int expected)
        {
            _cartService.Add(new CartProduct(milk, qtyOfMilk));
            _cartService.Add(new CartProduct(oil, qtyOfOil));
            _cartService.Add(new CartProduct(bun, qtyOfBun));
            _cartService.TotalPrice.Should().Be(expected);
        }

        [Theory]
        [InlineData(1,10)]
        [InlineData(2,20)]
        [InlineData(3,30)]
        public void TestCartSubtotal(int qty, int expected)
        {
            CartProduct cartProduct = new CartProduct(milk, qty);
            Assert.Equal(cartProduct.SubTotal, expected);
        }
    }
}