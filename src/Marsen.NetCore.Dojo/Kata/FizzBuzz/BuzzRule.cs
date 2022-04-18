namespace Marsen.NetCore.Dojo.Kata.FizzBuzz;

public class BuzzRule : IRule
{
    public string Apply(int input, string result)
    {
        return result + (isDivide(input) ? "Buzz" : string.Empty);
    }

    private bool isDivide(int input)
    {
        return input % 5 == 0;
    }
}