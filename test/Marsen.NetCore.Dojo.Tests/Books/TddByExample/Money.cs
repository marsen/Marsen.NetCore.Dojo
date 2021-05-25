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

        public Money reduce(string to, Bank bank)
        {
            if (to == "USD")
            {
                return new Money(Amount / bank.rate(this._currency,to), to);
            }

            throw new NotEmptyException();
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

        public IExpression times(int multiplier)
        {
            return new Money(Amount * multiplier, _currency);
        }

        public string currency()
        {
            return _currency;
        }

        public IExpression plus(Money money)
        {
            return new Sum(this, money);
        }
    }
}