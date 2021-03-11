using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public class Cart
    {
        private readonly List<CartProduct> _products = new();
        public Money TotalPrice => new()
        {
            Value = _products.Sum(x => x.SubTotal.Value), 
            Symbol = "NTD"
        };
        public IEnumerable<CartProduct> ProductList => _products;

        public void PutIn(CartProduct product)
        {
            _products.Add(product);
        }
    }
}