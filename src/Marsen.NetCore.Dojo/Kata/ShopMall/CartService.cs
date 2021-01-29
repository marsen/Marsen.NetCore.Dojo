using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartService
    {
        private readonly List<Product> _products = new();
        public int TotalPrice => _products.Sum(x => x.SubTotal);
        public List<Product> ProductList => _products;

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}