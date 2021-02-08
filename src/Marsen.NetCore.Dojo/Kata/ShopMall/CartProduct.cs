namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class Product
    {
        public int Price;
        public string Name;
    }

    public class CartProduct : Product
    {
        private readonly int _qty;

        public CartProduct(Product product, int qty)
        {
            Name = product.Name;
            Price = product.Price;
            _qty = qty;
        }

        public int SubTotal => Price * _qty;
    }
}