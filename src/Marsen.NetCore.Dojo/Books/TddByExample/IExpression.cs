namespace Marsen.NetCore.Dojo.Books.TddByExample;

public interface IExpression
{
    Money Reduce(Bank bank, string to);
    IExpression Times(int multiplier);
    IExpression Plus(IExpression addend);
}