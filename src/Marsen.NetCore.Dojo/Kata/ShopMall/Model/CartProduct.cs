namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public class CartProduct
    {
        private readonly Product _product;
        private readonly int _qty;

        public CartProduct(Product product, int qty)
        {
            _product = product;
            _qty = qty;
        }

        public int SubTotal => _product.Price * _qty;
    }
}