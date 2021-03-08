namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public class CartProduct
    {
        public readonly Product Product;
        private readonly int _qty;

        public CartProduct(Product product, int qty)
        {
            Product = product;
            _qty = qty;
        }

        public int SubTotal => Product.Price.Value * _qty;
    }
}