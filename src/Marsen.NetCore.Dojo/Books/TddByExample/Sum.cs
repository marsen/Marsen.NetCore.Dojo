namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public class Sum : IExpression
    {
        public IExpression augend;
        public IExpression addend;

        public Sum(IExpression augend, IExpression addend)
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money reduce(string to, Bank bank)
        {
            var result = augend.reduce(to, bank).Amount + addend.reduce(to, bank).Amount;
            return Money.dollar(result);
        }
    }
}