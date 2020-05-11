﻿using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.Core;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeater
    {
        public string Repeat(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("input should not be null or empty");
            }
            var list = input
                .Select(
                    (c, index) => c.ToString().ToUpper() +
                    Repeat(c.ToString(), index).ToLower())
                .ToList();

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