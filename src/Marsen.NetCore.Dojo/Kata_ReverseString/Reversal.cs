namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal
    {
        public string Do(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var result = string.Empty;
            foreach (var c in input.ToCharArray())
            {
                result = c.ToString() + result;
            }

            return result;
        }
    }
}