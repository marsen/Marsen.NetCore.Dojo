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

        public Money Reduce(Bank bank, string to)
        {
            if (to is "USD" or "CHF") 
                return new Money(Amount / bank.rate(Currency, to), to);

            throw new NotImplementedException();
        }

        public IExpression Times(int multiplier)
        {
            return new Money(Amount * multiplier, Currency);
        }

        public IExpression Plus(IExpression addend)
        {
            return new Sum(this, addend);
        }
    }
}