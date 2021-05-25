namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class Sum : IExpression
    {
        public Money augend;
        public Money addend;

        public Sum(Money augend, Money addend)
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money reduce(string to)
        {
            return Money.dollar(this.augend.Amount + this.addend.Amount);
        }
    }
}