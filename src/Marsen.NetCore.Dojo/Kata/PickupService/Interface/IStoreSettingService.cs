namespace Marsen.NetCore.Dojo.Kata.PickupService.Interface;

public interface IStoreSettingService
{
    string GetValue(long storeId, string groupTypeDef, string key);
}