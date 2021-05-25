using System;

namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money : IExpression
    {
        public readonly string Currency;

        public readonly int Amount;

        private Money(int amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money reduce(string to, Bank bank)
        {
            if (to == "USD") return new Money(Amount / bank.rate(Currency, to), to);

            throw new NotImplementedException();
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
            return new Money(Amount * multiplier, Currency);
        }

        public string currency()
        {
            return Currency;
        }

        public IExpression plus(Money money)
        {
            return new Sum(this, money);
        }
    }
}