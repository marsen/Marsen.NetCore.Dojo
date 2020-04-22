namespace Marsen.NetCore.Dojo.Kata.ReverseString
{
    public class RecursionReversal : IStringReversal
    {
        public string Do(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
            {
                return input;
            }

            var s1 = input.Substring(0, 1);
            var s2 = input.Substring(1);
            return Do(s2) + s1;
        }
    }
}