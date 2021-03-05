using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel;

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
}