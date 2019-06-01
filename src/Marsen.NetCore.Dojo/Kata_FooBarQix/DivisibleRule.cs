namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class DivisibleRule
    {
        private readonly int _divisor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleRule" /> class.
        /// </summary>
        public DivisibleRule(int divisor)
        {
            _divisor = divisor;
        }
        public string Apply(int input, string result)
        {
            if (IsDivisibleBy(this._divisor, input))
            {
                result += "Foo";
            }

            return result;
        }

        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}