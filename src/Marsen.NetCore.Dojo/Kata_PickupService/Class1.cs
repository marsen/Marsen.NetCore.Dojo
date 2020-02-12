using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            var result = new List<ShippingOrderUpdateEntity>();
            //// TODO Call API
            //// TODO Parse Response
            ////  
            return result;
        }
    }
}