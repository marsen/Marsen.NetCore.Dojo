namespace Marsen.NetCore.Dojo.Kata.ShopMall
{
    public class CartProduct
    {
        private readonly Product _product;
        public readonly string Name;
        private readonly int _price;
        private readonly int _qty;

        public CartProduct(Product product,int qty)
        {
            _product = product;
            _qty = qty;
        }
        public CartProduct(string name, int price, int qty)
        {
            Name = name;
            _product = new Product {Price = price,Name = name};
            _qty = qty;
        }

        public int SubTotal => _product.Price * _qty;
    }

    public class Product
    {
        public int Price;
        public string Name;
    }
}