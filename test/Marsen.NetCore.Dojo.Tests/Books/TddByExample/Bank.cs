using System.Collections;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class Bank
    {
        private Dictionary<string, int> _rateLookup = new();

        public Money reduce(IExpression expression, string currency)
        {
            if (expression.GetType() == typeof(Sum))
            {
                Sum sum = (Sum) expression;
                return sum.reduce(currency);
            }

            return expression.reduce(currency);
        }

        public void addRate(string chf, string usd, int i)
        {
            _rateLookup.Add($"{chf}{usd}", i);
        }
    }
}