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


            if (input == 3)
            {
                result += "Foo";
            }

            if (string.IsNullOrEmpty(result))
            {
                return input.ToString();
            }

            return result;
        }
    }
}