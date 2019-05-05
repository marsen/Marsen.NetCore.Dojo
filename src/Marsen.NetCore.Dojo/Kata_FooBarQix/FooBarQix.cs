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

            if (input == 3)
            {
                return "FooFoo";
            }

            return input.ToString();
        }
    }
}