using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            throw new NotImplementedException();
        }
    }
}