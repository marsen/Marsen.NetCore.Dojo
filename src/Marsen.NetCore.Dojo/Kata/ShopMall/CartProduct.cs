namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class Product
    {
        protected int Price;
        public string Name;
    }

    public class CartProduct : Product
    {
        private readonly int _qty;

        public CartProduct(string name, int price, int qty)
        {
            Name = name;
            Price = price;
            _qty = qty;
        }

        public int SubTotal => Price * _qty;
    }
}