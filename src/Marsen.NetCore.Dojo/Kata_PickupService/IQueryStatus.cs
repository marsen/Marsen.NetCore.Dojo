using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    internal interface IQueryStatus
    {
        List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo);
    }
}