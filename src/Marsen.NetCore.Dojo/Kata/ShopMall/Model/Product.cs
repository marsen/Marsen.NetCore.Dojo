namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public class Product
    {
        public Money Price;
        public string Name;
    }

    public struct Money
    {
        public int number { get; init; }
        public string symbol { get; init; }
        public override string ToString() => $"{number} {symbol}";
    }
}