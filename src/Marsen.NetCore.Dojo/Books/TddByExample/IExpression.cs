namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public interface IExpression
    {
        Money reduce(string to, Bank bank);
        IExpression times(int multiplier);
        IExpression plus(Money money);
    }
}