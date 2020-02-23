namespace Marsen.NetCore.Dojo.Kata_PickupService.Interface
{
    public interface IStoreSettingService
    {
        string GetValue(long shopId, string groupTypeDef, string key);
    }
}