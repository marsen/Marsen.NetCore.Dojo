namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public interface IExpression
    {
        Money reduce(Bank bank, string to);
        IExpression times(int multiplier);
        IExpression plus(IExpression addend);
    }
}