﻿namespace Marsen.NetCore.Dojo.Kata_FizzBuzz
{
    public class NormalRule
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