namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            var result = string.Empty;

            if (IsDivisibleBy(7, input))
            {
                result += "Qix";
            }

            if (IsContains(7, input))
            {
                result += "Qix";
            }

            if (IsDivisibleBy(3, input))
            {
                result += "Foo";
            }

            if (IsDivisibleBy(5, input))
            {
                result += "Bar";
            }

            if (IsContains(5, input))
            {
                result += "Bar";
            }

            if (IsContains(3, input))
            {
                result += "Foo";
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }

        private bool IsContains(int i, int input)
        {
            return input.ToString().Contains(i.ToString());
        }

        private bool IsDivisibleBy(int i, int input)
        {
            return input % i == 0;
        }
    }
}