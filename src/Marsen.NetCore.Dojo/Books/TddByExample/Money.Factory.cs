namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money
    {
        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }
    }
}