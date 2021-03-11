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

        public Money SubTotal => new() {Value = Product.Price.Value * Qty, Symbol = "NTD"};
    }
}