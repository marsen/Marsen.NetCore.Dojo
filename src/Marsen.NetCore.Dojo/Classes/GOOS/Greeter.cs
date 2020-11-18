namespace Marsen.NetCore.Dojo.Classes.GOOS
{
    public class Greeter
    {
        public string Invoke(string name, string hourOfDay)
        {
            var response = "Hello World";
            if (string.IsNullOrEmpty(name) == false)
            {
                response = $"Hello {name}";
            }

            return response;
        }
    }
}