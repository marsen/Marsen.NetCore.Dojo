namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class BuzzRule
    {
        public string Apply(int input, string result)
        {
            if (input % 5 == 0)
            {
                result += "Buzz";
            }

            return result;
        }
    }
}