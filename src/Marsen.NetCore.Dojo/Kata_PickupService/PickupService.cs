﻿using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity.PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        private readonly IConfigService _configService;
        private readonly IStoreSettingService _storeSettingService;
        private const string DeliveryOrder = "DeliveryOrder";

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupService" /> class.
        /// </summary>
        public PickupService(IConfigService configService, IStoreSettingService storeSettingService)
        {
            this._configService = configService;
            this._storeSettingService = storeSettingService;
        }

        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            var result = new List<ShippingOrderUpdateEntity>();
            //// TODO Call API
            var httpClient = new HttpClient();

            var loginId = this._storeSettingService.GetValue(storeId,"pickup.service","loginId");
            httpClient.DefaultRequestHeaders.Add("login_id", loginId);
            
            var auth = this._storeSettingService.GetValue(storeId,"pickup.service","auth");
            httpClient.DefaultRequestHeaders.Add("authorization", auth);
            var httpContent = new StringContent(
                JsonSerializer.Serialize(new { Type = DeliveryOrder, waybillNo }),
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