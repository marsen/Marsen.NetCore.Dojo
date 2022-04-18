namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money
    {
        public static Money Dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money Franc(int amount)
        {
            return new Money(amount, "CHF");
        }
    }
}