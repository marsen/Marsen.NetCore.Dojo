namespace Marsen.NetCore.Dojo.Kata.ReverseString
{
    public class HalfLoopReversal : IStringReversal
    {
        public string Do(string input)
        {
            if (input is null)
            {
                return null;
            }

            var cArray = input.ToCharArray();
            for (var i = 0; i < cArray.Length / 2; i++)
            {
                var temp = cArray[i];
                var l = cArray.Length - 1 - i;
                cArray[i] = cArray[l];
                cArray[l] = temp;
            }

            return new string(cArray);
        }
    }
}