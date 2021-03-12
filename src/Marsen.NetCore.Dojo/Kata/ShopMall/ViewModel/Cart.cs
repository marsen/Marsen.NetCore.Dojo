using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel
{
    public class Cart
    {
        public IEnumerable<Product> ProductList { get; init; }
        public string TotalPrice { get; init; }
    }
}