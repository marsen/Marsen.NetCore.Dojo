namespace Marsen.NetCore.Dojo.Kata.ShopMall.Model
{
    public readonly struct Money
    {
        private int Value { get; init; }
        private string Symbol { get; init; }
        public override string ToString() => $"{Value} {Symbol}";

        public static Money operator +(Money a, Money b)
        {
            return new() {Value = a.Value + b.Value, Symbol = a.Symbol};
        }

        public static Money operator ++(Money a)
        {
            return new() {Value = a.Value + 1, Symbol = a.Symbol};
        }

        public static Money operator *(int d, Money a)
        {
            return new() {Value = d * a.Value, Symbol = a.Symbol};
        }

        public static Money operator *(Money a, int d)
        {
            return new() {Value = d * a.Value, Symbol = a.Symbol};
        }
    }
}