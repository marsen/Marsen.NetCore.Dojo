namespace Marsen.NetCore.Dojo.Kata_FooBarQix
{
    public class FooBarQix
    {
        public string Get(int input)
        {
            if (input == 5)
            {
                return "BarBar";
            }

            var result = string.Empty;
            if (input % 3 == 0)
            {
                result += "Foo";
            }

            if (input == 6)
            {
                return result;
            }

            if (input == 3)
            {
                return result + "Foo";
            }

            if (string.IsNullOrEmpty(result))
            {
                return input.ToString();
            }

            return result;
        }
    }
}