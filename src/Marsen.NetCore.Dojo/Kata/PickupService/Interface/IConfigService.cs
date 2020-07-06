namespace Marsen.NetCore.Dojo.Kata.Service.Interface
{
    public interface IConfigService
    {
        string GetAppSetting(string key, string defaultValue = "", bool usePrefix = false);

    }
}