namespace Marsen.NetCore.Dojo.Classes.GOOS
{
    public class Greeter
    {
        public string Invoke(string name, string hourOfDay)
        {
            if (hourOfDay=="14")
            {
                return "Zzz";
            }
            var response = "Hello World";
            if (string.IsNullOrEmpty(name) == false)
            {
                response = $"Hello {name}";
            }

            return response;
        }
    }
}