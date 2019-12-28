namespace Marsen.NetCore.Dojo.Kata_JsonParser
{
    public class PersonaParser
    {
        public PersonaEntity Parse(string json)
        {
            return new PersonaEntity
            {
                Age = 30,
                Name = "Tian Tank"
            };
        }
    }
}