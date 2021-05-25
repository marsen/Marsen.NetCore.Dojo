using System.Linq;
using Xunit.Sdk;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class Money : IExpression
    {
        public override string ToString()
        {
            return $@"{Amount} {_currency}";
        }

        public Money reduce(string to)
        {
            return Money.dollar(1);
        }

        public readonly int Amount;
        private readonly string _currency;

        private Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public override bool Equals(object? obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount && _currency == money._currency;
        }

        public static Money dollar(int amount)
        {
            return new(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new(amount, "CHF");
        }

        public Money times(int multiplier)
        {
            return new(Amount * multiplier, _currency);
        }

        public string currency()
        {
            return _currency;
        }

        public Sum plus(Money money)
        {
            return new(this, money);
        }
    }
}