using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity;

namespace Marsen.NetCore.Dojo.Kata.PickupService.Interface
{
    internal interface IQueryStatus
    {
        List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo);
    }
}