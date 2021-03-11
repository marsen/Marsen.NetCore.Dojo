using Marsen.NetCore.Dojo.Kata.ShopMall.Model;

namespace Marsen.NetCore.Dojo.Kata.ShopMall.ViewModel
{
    public class Product
    {
        public string Name { get; init; }
        public string Price { get; init; }
        public string SubTotal { get; init; }
        public int Qty { get; init; }
    }
}