namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public class Sum : IExpression
    {
        public readonly IExpression Addend;
        public readonly IExpression Augend;

        public Sum(IExpression augend, IExpression addend)
        {
            Augend = augend;
            Addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            var result = Augend.Reduce(bank, to).Amount + Addend.Reduce(bank, to).Amount;
            return Money.Dollar(result);
        }

        public IExpression Times(int multiplier)
        {
            return new Sum(Augend.Times(multiplier), Addend.Times(multiplier));
        }

        public IExpression Plus(IExpression addend)
        {
            return new Sum(this, addend);
        }
    }
}