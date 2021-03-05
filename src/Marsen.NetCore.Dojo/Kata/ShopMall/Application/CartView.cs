using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.Application
{
    public class CartView
    {
        public IEnumerable<CartProduct> ProductList { get; set; }
        public int TotalPrice { get; set; }
    }
}