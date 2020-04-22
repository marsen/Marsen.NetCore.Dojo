namespace Marsen.NetCore.Dojo.Kata.PickupService.Interface
{
    public interface IConfigService
    {
        string GetAppSetting(string key, string defaultValue = "", bool usePrefix = false);

    }
}