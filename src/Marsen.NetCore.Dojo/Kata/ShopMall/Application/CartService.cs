using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        public Cart PutIn(CartProduct product, Cart cart)
        {
            cart.PutIn(product);
            return cart;
        }
    }
}