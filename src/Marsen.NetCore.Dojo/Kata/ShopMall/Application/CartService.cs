using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;
using Cart = Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel.Cart;
using Product = Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel.Product;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartService
    {
        private readonly Model.Cart _cart;

        public CartService()
        {
            _cart = new Model.Cart();
        }

        public void PutIn(CartProduct product)
        {
            _cart.PutIn(product);
        }

        public Cart GetCart()
        {
            return new()
            {
                ProductList = _cart
                    .ProductList
                    .Select(p => new Product
                    {
                        Name = p.Product.Name,
                        Price = p.Product.Price.ToString()
                    }),
                TotalPrice = _cart.TotalPrice
            };
        }
    }
}