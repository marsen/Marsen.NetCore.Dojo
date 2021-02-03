using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartService
    {
        private readonly List<CartProduct> _products = new();
        public int TotalPrice => _products.Sum(x => x.SubTotal);
        public List<CartProduct> ProductList => _products;
        public void Add(CartProduct cartProduct)
        {
            _products.Add(cartProduct);
        }
    }
}