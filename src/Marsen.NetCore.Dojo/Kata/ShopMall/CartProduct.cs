namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartProduct
    {
        private readonly int _price;
        private readonly int _qty;

        public CartProduct(string name, int price, int qty)
        {
            _price = price;
            _qty = qty;
        }

        public int SubTotal => _price * _qty;
    }
}