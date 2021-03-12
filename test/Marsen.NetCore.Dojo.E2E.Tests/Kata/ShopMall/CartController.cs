using Marsen.NetCore.Dojo.Kata.ShopMall.Application;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Cart = Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel.Cart;

namespace Marsen.NetCore.Dojo.E2E.Tests.Kata.ShopMall
{
    public class CartController
    {
        public Cart Get()
        {
            var service = new CartService();
            service.PutIn(new CartProduct(new Product {Name = "Milk", Price = 10}, 1));
            service.PutIn(new CartProduct(new Product {Name = "Oil", Price = 7}, 2));
            service.PutIn(new CartProduct(new Product {Name = "Bun", Price = 6}, 3));
            return service.GetCart();
        }
    }
}