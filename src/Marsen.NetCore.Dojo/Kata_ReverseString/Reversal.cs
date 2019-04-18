namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class Reversal
    {
        public string Do(string input)
        {
            if (input is null)
            {
                return input;
            }

            var result = string.Empty;
            foreach (var c in input.ToCharArray())
            {
                result = c + result;
            }

            return result;
        }
    }
}