namespace Marsen.NetCore.Dojo.Classes.GOOS
{
    public class Greeter
    {
        public string Invoke(string name, string hourOfDay)
        {
            return Is14OClock(hourOfDay) ? "Zzz" : SayHi(name);
        }

        private static string SayHi(string name)
        {
            return $"Hello {(HaveName(name) ? name : "World")}";
        }

        private static bool HaveName(string name)
        {
            return string.IsNullOrEmpty(name) == false;
        }

        private static bool Is14OClock(string hourOfDay)
        {
            return hourOfDay == "14";
        }
    }
}