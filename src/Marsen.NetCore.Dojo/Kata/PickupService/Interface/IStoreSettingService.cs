namespace Marsen.NetCore.Dojo.Kata.Service.Interface
{
    public interface IStoreSettingService
    {
        string GetValue(long storeId, string groupTypeDef, string key);
    }
}