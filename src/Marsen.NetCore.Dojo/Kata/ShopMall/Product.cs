namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class Product
    {
        private readonly int _price;
        private readonly int _qty;

        public Product(string name, int price, int qty)
        {
            _price = price;
            _qty = qty;
        }

        public int SubTotal => _price * _qty;
    }
}