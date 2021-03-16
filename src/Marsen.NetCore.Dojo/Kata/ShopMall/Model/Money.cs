namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public readonly struct Money
    {
        private int Price { get; init; }
        private string Symbol { get; init; }
        public override string ToString() => $"{Price.ToString()} {Symbol}";

        public static Money operator +(Money a, Money b)
        {
            return new() {Price = a.Price + b.Price, Symbol = a.Symbol};
        }

        public static Money operator ++(Money a)
        {
            return new() {Price = a.Price + 1, Symbol = a.Symbol};
        }

        public static Money operator *(int d, Money a)
        {
            return new() {Price = d * a.Price, Symbol = a.Symbol};
        }

        public static Money operator *(Money a, int d)
        {
            return new() {Price = d * a.Price, Symbol = a.Symbol};
        }
    }
}