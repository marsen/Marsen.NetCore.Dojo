namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money
    {
        public override string ToString()
        {
            return $"{Amount.ToString()} {Currency}";
        }

        public override bool Equals(object obj)
        {
            var money = (Money)obj!;
            return Amount == money.Amount && Currency == money.Currency;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}