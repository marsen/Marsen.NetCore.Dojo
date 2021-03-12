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
                //// TODO:Replace with mapper
                ProductList = _cart
                    .ProductList
                    .Select(p => new Product
                    {
                        Name = p.Product.Name,
                        Price = TotalPrice(p.Product.Price),
                        SubTotal = TotalPrice(p.SubTotal),
                        Qty = p.Qty
                    }),
                TotalPrice = TotalPrice(_cart.TotalPrice)
            };
        }

        private string TotalPrice(int price)
        {
            return $"{price} NTD";
        }
    }
}