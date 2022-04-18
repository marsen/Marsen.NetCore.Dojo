namespace Marsen.NetCore.Dojo.Kata.FizzBuzz;

public class NormalRule : IRule
{
    public string Apply(int input, string result)
    {
        return string.IsNullOrEmpty(result) ? input.ToString() : result;
    }
}