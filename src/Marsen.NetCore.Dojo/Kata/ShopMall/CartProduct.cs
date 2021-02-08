namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartProduct
    {
        private readonly int _price;
        private readonly int _qty;
        public readonly string Name;

        public CartProduct(string name, int price, int qty)
        {
            Name = name;
            _price = price;
            _qty = qty;
        }

        public int SubTotal => _price * _qty;
    }
}