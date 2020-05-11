﻿using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            var list = new List<string>();
            for (var i = 0; i < input.Length; i++)
            {
                list.Add(
                    input.Substring(i, 1).ToUpper() + 
                    Repeat(input.Substring(i, 1), i).ToLower());
            }

            return string.Join('-', list);
        }

        private string Repeat(string substring, int times)
        {
            var result = string.Empty;
            for (var i = 0; i < times; i++)
            {
                result += substring;
            }

            return result;
        }
    }
}