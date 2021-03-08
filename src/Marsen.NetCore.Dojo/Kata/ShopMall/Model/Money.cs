namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public struct Money
    {
        public int Value { get; init; }
        public string Symbol { get; init; }
        public override string ToString() => $"{Value} {Symbol}";
    }
}