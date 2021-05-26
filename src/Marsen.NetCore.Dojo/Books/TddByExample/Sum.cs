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

        public Money reduce(Bank bank, string to)
        {
            var result = Augend.reduce(bank, to).Amount + Addend.reduce(bank, to).Amount;
            return Money.dollar(result);
        }

        public IExpression times(int multiplier)
        {
            return new Sum(Augend.times(multiplier), Addend.times(multiplier));
        }

        public IExpression plus(IExpression addend)
        {
            return new Sum(this, addend);
        }
    }
}