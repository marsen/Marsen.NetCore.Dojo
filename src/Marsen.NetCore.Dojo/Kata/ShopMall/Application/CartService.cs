using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        public CartView PutIn(CartProduct product, Cart cart)
        {
            cart.PutIn(product);
            return new CartView{ ProductList=cart.ProductList ,TotalPrice = cart.TotalPrice};
        }
    }

    public class CartView
    {
        public IEnumerable<CartProduct> ProductList { get; set; }
        public int TotalPrice { get; set; }
    }
}