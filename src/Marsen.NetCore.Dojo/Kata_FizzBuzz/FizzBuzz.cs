namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class FizzBuzz
    {
        public string Get(int input)
        {
            if (input == 5)
            {
                return "Buzz";
            }

            if (input == 3)
            {
                return "Fizz";
            }

            return input.ToString();
        }
    }
}