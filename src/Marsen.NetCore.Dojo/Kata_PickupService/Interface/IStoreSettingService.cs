namespace Marsen.NetCore.Dojo.Kata_PickupService.Interface
{
    public interface IStoreSettingService
    {
        string GetValue(long storeId, string groupTypeDef, string key);
    }
}