namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public interface IStoreSettingService
    {
        string GetValue(long shopId, string groupTypeDef, string key);
    }
}