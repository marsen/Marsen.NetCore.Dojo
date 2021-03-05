using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        private Cart _cart;

        public CartService()
        {
            _cart = new Cart();
        }
        public CartView PutIn(CartProduct product)
        {
            _cart.PutIn(product);
            return new CartView{ ProductList=_cart.ProductList ,TotalPrice = _cart.TotalPrice};
        }
    }

    public class CartView
    {
        public IEnumerable<CartProduct> ProductList { get; set; }
        public int TotalPrice { get; set; }
    }
}