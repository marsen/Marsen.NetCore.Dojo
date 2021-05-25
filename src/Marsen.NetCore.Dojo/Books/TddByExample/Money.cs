using System;

namespace Marsen.NetCore.Dojo.Books.TddByExample
{
    public partial class Money : IExpression
    {
        private readonly string _currency;

        public readonly int Amount;

        private Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public Money reduce(string to, Bank bank)
        {
            if (to == "USD") return new Money(Amount / bank.rate(_currency, to), to);

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

    public partial class Money
    {
        public override string ToString()
        {
            return $@"{Amount} {_currency}";
        }

        public override bool Equals(object? obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount && _currency == money._currency;
        }
    }
}