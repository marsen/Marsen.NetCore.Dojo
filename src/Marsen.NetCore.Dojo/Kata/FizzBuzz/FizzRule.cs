namespace Marsen.NetCore.Dojo.Kata.FizzBuzz
{
    public class FizzRule : IRule
    {
        public string Apply(int input, string result)
        {
            if (input % 3 == 0)
            {
                result += "Fizz";
            }

            return result;
        }
    }
}