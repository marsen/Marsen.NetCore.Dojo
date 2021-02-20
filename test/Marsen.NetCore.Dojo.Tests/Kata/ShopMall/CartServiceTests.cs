using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ShopMall;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ShopMall
{
    public class CartServiceTests
    {
        private readonly CartService _cart = new();
        private readonly Product _milk = new() {Name = "milk", Price = 10};
        private const string Oil = "oil";

        #region TotalPrice Test Cases

        [Fact]
        public void No_product_cart_TOTAL_PRICE_should_be_0()
        {
            _cart.TotalPrice.Should().Be(0);
        }

        [Fact]
        public void There_is_one_Product_A_in_cart_TOTAL_PRICE_should_be_10()
        {
            GivenAdd10DollarMilk(1);
            _cart.TotalPrice.Should().Be(10);
        }

        [Fact]
        public void There_is_one_Product_B_in_cart_TOTAL_PRICE_should_be_7()
        {
            GivenAdd7DollarOil(1);
            _cart.TotalPrice.Should().Be(7);
        }

        [Fact]
        public void There_is_one_Product_A_and_Product_B_in_cart_TOTAL_PRICE_should_be_17()
        {
            GivenAdd10DollarMilk(1);
            GivenAdd7DollarOil(1);
            _cart.TotalPrice.Should().Be(17);
        }

        [Fact]
        public void There_is_2_Product_B_in_cart_TOTAL_PRICE_should_be_14()
        {
            GivenAdd7DollarOil(2);
            _cart.TotalPrice.Should().Be(14);
        }

        [Fact]
        public void There_is_One_Product_A_and_2_Product_B_in_cart_TOTAL_PRICE_should_be_44()
        {
            GivenAdd10DollarMilk(3);
            GivenAdd7DollarOil(2);
            _cart.TotalPrice.Should().Be(44);
        }

        #endregion

        [Fact]
        public void Buy_Nothing_Cart_ProductList_Count_Should_Be_0()
        {
            _cart.ProductList.ToList().Count.Should().Be(0);
        }

        [Fact]
        public void Add_Milk_Cart_Should_Contain_Milk()
        {
            CartProduct milk = new(new Product {Name = "milk", Price = 10}, 1);
            _cart.Add(milk);
            Assert.Contains(milk, _cart.ProductList.Where(x => x.Product.Name == "milk"));
        }

        private void GivenAdd10DollarMilk(int qty)
        {
            _cart.Add(new(_milk, qty));
        }

        private void GivenAdd7DollarOil(int qty)
        {
            _cart.Add(new(new Product {Name = Oil, Price = 7}, qty));
        }
    }
}