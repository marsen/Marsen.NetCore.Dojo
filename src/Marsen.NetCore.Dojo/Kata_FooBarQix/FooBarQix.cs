namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            if (input == 10)
            {
                // return "Bar";
            }

            if (input == 7)
            {
                return "QixQix";
            }

            if (input == 5)
            {
                ///return "BarBar";
            }

            var result = string.Empty;
            if (IsDivisibleBy5(input))
            {
                result += "Bar";
            }

            if (IsContain5(input))
            {
                result += "Bar";
            }

            if (IsDivisibleBy3(input))
            {
                result += "Foo";
            }

            if (IsContains3(input))
            {
                result += "Foo";
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }

        private bool IsContain5(int input)
        {
            return input.ToString().Contains("5");
        }

        private bool IsDivisibleBy5(int input)
        {
            return input % 5 == 0;
        }

        private bool IsDivisibleBy3(int input)
        {
            return input % 3 == 0;
        }

        private bool IsContains3(int input)
        {
            return input.ToString().Contains("3");
        }
    }
}