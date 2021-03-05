using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Cart = Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel.Cart;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        private readonly Model.Cart _cart;

        public CartService()
        {
            _cart = new Model.Cart();
        }

        public Cart PutIn(CartProduct product)
        {
            _cart.PutIn(product);
            return GetCart();
        }

        public Cart GetCart()
        {
            return new() {ProductList = _cart.ProductList, TotalPrice = _cart.TotalPrice};
        }
    }
}