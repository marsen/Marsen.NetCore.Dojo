using System;

namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money : IExpression
    {
        public readonly int Amount;
        public readonly string Currency;

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

        public IExpression times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public IExpression plus(Money money)
        {
            return new Sum(this, money);
        }
    }
}