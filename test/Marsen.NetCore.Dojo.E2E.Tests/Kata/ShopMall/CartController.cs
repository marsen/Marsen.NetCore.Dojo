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
            service.PutIn(new CartProduct(new Product {Name = "Milk", Price = new Money{Value = 10, Symbol = "NTD"}}, 1));
            service.PutIn(new CartProduct(new Product {Name = "Oil", Price = new Money{Value = 7, Symbol = "NTD"}}, 2));
            service.PutIn(new CartProduct(new Product {Name = "Bun", Price = new Money{Value = 6, Symbol = "NTD"}}, 3));
            return service.GetCart();
        }
    }
}