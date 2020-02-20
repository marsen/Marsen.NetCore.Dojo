using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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
            //// TODO DeliveryOrder 抽常數
            var httpContent = new StringContent(
                JsonSerializer.Serialize(new {Type = "DeliveryOrder", waybillNo}),
                Encoding.UTF8, "application/json");
            //// TODO url 抽參數
            //string url= "http://www.mocky.io/v2/5e4d09c22d00002800c0d91e";
            string url = "http://www.mocky.io/v2/5e4e56832f0000f55116a60b";
            var responseMessage = httpClient.PostAsync(url, httpContent).Result;
            //// TODO Parse Response Entity
            //// TODO Switch Status
            //// TODO Return ShippingOrderUpdateEntity List 
            return result;
        }
    }
}