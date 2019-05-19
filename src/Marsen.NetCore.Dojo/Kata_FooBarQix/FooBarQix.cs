﻿using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            var result = string.Empty;
            if (IsDivisibleBy(3, input))
            {
                result += "Foo";
            }

            if (IsDivisibleBy(5, input))
            {
                result += "Bar";
            }

            if (IsDivisibleBy(7, input))
            {
                result += "Qix";
            }

            foreach (var c in input.ToString().ToCharArray())
            {
                if (c == '3')
                {
                    result += "Foo";
                }

                if (c == '5')
                {
                    result += "Bar";
                }

                if (c == '7')
                {
                    result += "Qix";
                }
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }

        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}