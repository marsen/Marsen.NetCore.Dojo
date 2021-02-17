namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartProduct
    {
        public readonly Product Product;
        private readonly int _price;
        private readonly int _qty;

        public CartProduct(Product product, int qty)
        {
            Product = product;
            _qty = qty;
        }

        public int SubTotal => Product.Price * _qty;
    }

    public class Product
    {
        public int Price;
        public string Name;
    }
}