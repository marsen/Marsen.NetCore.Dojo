namespace Marsen.NetCore.Dojo.Kata.FizzBuzz
{
    public class NormalRule : IRule
    {
        public string Apply(int input, string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                result = input.ToString();
            }

            return result;
        }
    }
}