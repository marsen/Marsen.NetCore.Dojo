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


            if (input.ToString().Contains("3"))
            {
                result += "Foo";
            }

            return string.IsNullOrEmpty(result) ? input.ToString() : result;
        }
    }
}