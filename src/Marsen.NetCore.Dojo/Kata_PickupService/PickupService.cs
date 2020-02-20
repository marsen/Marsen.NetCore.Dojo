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
            var responseMessage = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            //// TODO Parse Response Entity
            var obj = JsonSerializer.Deserialize<ResponseEntity>(responseMessage);
            //// TODO Switch Status
            //// TODO Return ShippingOrderUpdateEntity List 
            return result;
        }
    }

    public class ResponseEntity
    {
        public string result { get; set; }
        public List<Content> content { get; set; }
    }

    public class Item
    {
        public string commodity { get; set; }
        public int noOfItem { get; set; }
        public int commercialValue { get; set; }
        public string currency { get; set; }
        public string coo { get; set; }
        public string hsCode { get; set; }
    }

    public class Content
    {
        public string merchantId { get; set; }
        public string merchantRef { get; set; }
        public string waybillNo { get; set; }
        public string locationId { get; set; }
        public string pudoRef { get; set; }
        public string pudoVerifyCode { get; set; }
        public string senderId { get; set; }
        public string consigneeId { get; set; }
        public string customerName { get; set; }
        public string customerAddress1 { get; set; }
        public string customerAddress2 { get; set; }
        public string customerAddress3 { get; set; }
        public string customerAddress4 { get; set; }
        public string feedbackURL { get; set; }
        public string eta { get; set; }
        public string codAmt { get; set; }
        public string sizeCode { get; set; }
        public List<Item> item { get; set; }
        public string lastStatusId { get; set; }
        public string lastStatusDescription { get; set; }
        public string lastStatusDate { get; set; }
        public string lastStatusTime { get; set; }
        public string customerMobile { get; set; }
        public string customerEmail { get; set; }
    }
    
}