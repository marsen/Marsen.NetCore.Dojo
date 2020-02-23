namespace Marsen.NetCore.Dojo.Kata_PickupService.Interface
{
    public interface IConfigService
    {
        string GetAppSetting(string key, string defaultValue = "", bool usePrefix = false);

    }
}