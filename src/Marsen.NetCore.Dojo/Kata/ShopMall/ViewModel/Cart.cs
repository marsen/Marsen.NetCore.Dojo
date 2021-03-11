using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel
{
    public class Cart
    {
        public IEnumerable<Product> ProductList { get; init; }
        public Money TotalPrice { get; init; }
    }
}