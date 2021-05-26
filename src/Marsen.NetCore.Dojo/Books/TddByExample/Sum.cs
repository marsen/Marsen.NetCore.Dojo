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

        public Money reduce(string to, Bank bank)
        {
            var result = Augend.reduce(to, bank).Amount + Addend.reduce(to, bank).Amount;
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