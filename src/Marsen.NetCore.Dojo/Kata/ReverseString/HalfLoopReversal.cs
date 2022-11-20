using System;

namespace Marsen.NetCore.Dojo.Kata.ReverseString;

public class HalfLoopReversal : IStringReversal
{
    public string Do(string input)
    {
        if (input is null) return null;

        var arr = input.ToCharArray();
        var lastIdx = arr.Length - 1;
        for (var i = 0; i < arr.Length / 2; i++)
        {
            (arr[i], arr[lastIdx - i]) = (arr[lastIdx - i], arr[i]);
        }

        return new string(arr);
    }
}