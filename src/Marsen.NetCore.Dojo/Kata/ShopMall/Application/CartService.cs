using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        public Cart Add(CartProduct product, Cart cart)
        {
            cart.Add(product);
            return cart;
        }
    }
}