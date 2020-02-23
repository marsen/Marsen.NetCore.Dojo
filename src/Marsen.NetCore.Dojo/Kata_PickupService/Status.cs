using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public enum Status
    {
        DONE,
        Shipping,
        FAIL,
        Expiry,
        Arrived,
    }
}