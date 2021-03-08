using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel
{
    public class Cart
    {
        public string Id { get; set; }
        public IEnumerable<ViewModel.Product> ProductList { get; init; }
        public int TotalPrice { get; init; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}