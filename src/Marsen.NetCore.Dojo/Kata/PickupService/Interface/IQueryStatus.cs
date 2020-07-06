using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata.Service.Entity;

namespace Marsen.NetCore.Dojo.Kata.Service.Interface
{
    internal interface IQueryStatus
    {
        List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo);
    }
}