using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity.PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;
using Microsoft.Extensions.Logging;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class PickupService : IQueryStatus
    {
        private readonly IConfigService _configService;
        private readonly IStoreSettingService _storeSettingService;
        private readonly ILogger _logger;
        internal HttpClient HttpClient;
        private const string DeliveryOrder = "DeliveryOrder";

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupService" /> class.
        /// </summary>
        public PickupService(IConfigService configService, IStoreSettingService storeSettingService, ILogger logger)
        {
            this._configService = configService;
            this._storeSettingService = storeSettingService;
            this._logger = logger;
            this.HttpClient = new HttpClient();
        }

        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            try
            {
                var result = new List<ShippingOrderUpdateEntity>();

                var loginId = this._storeSettingService.GetValue(storeId, "pickup.service", "loginId");
                this.HttpClient.DefaultRequestHeaders.Add("login_id", loginId);

                var auth = this._storeSettingService.GetValue(storeId, "pickup.service", "auth");
                this.HttpClient.DefaultRequestHeaders.Add("authorization", auth);
                var httpContent = new StringContent(
                    JsonSerializer.Serialize(new {Type = DeliveryOrder, waybillNo}),
                    Encoding.UTF8, "application/json");
                var url = this._configService.GetAppSetting("pickup.service.url");
                var responseMessage = HttpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
                var obj = JsonSerializer.Deserialize<ResponseEntity>(responseMessage);
                if (obj.Result == "error")
                {
                    this._logger.LogError(obj.Result);
                    throw new Exception();
                }

                foreach (var c in obj.Content.Where(c => string.IsNullOrEmpty(c.ErrorCode)))
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
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                this._logger.LogError(e, "發生未預期的錯誤");
                throw;
            }
        }
    }
}