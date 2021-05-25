namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public interface IExpression
    {
        Money reduce(string to, Bank bank);
    }
}