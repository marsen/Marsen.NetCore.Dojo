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
            //// TODO login id 抽參數
            httpClient.DefaultRequestHeaders.Add("login_id", "testId");
            //// TODO authorization 抽參數
            httpClient.DefaultRequestHeaders.Add("authorization", "testAuth");
            
            var requestContent = JsonSerializer.Serialize(new { Type = "DeliveryOrder", waybillNo });
            var httpContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
            //// TODO 4.指定 API URL
            //// TODO 5.呼叫
            //// TODO Parse Response
            ////  
            return result;
        }
    }
}