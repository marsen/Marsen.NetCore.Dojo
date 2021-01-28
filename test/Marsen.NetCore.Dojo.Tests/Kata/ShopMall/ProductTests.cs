using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class ProductTests
    {
        [Fact]
        public void When_Product_A_Price_is_10_Qty_is_0_SubTotal_Should_Be_0()
        {
            Product product = new Product("A", 10, 0);
            Assert.Equal(product.SubTotal,0);
        }
    }

    public class Product
    {
        public Product(string s, int i, int i1)
        {
            throw new NotImplementedException();
        }

        public int SubTotal { get; set; }
    }
}