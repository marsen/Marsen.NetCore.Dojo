using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        private readonly IConfigService _configService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupService" /> class.
        /// </summary>
        public PickupService(IConfigService configService)
        {
            this._configService = configService;
        }

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
            var url = this._configService.GetAppSetting("pickup.service.url");
            var responseMessage = httpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            var obj = JsonSerializer.Deserialize<ResponseEntity>(responseMessage);
            foreach (var c in obj.Content)
            {
                switch (c.Status)
                {
                    case Status.DONE:
                        result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Finish});
                        break;
                    case Status.Shipping:
                        result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Processing});
                        break;
                    case Status.FAIL:
                    case Status.Expiry:
                        result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Abnormal});
                        break;
                    case Status.Arrived:
                        result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Arrived});
                        break;
                }
            }

            return result;
        }
    }
}