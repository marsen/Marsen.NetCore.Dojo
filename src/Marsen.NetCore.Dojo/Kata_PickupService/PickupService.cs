using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            var result = new List<ShippingOrderUpdateEntity>();
            //// TODO Call API
            var httpClient = new HttpClient();
            //// TODO 2.建立 auth
            //// TODO 3.準備 HttpContent 資料
            //// TODO 4.指定 API URL
            //// TODO 5.呼叫
            //// TODO Parse Response
            ////  
            return result;
        }
    }
}