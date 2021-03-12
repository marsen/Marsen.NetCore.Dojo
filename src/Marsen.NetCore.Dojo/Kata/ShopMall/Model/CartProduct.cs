namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public class CartProduct
    {
        public readonly Product Product;
        public readonly int Qty;

        public CartProduct(Product product, int qty)
        {
            Product = product;
            Qty = qty;
        }

        public int SubTotal => Product.Price * Qty;
    }
}