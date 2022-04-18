using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Castle.Core.Internal;
using Marsen.NetCore.Dojo.Common;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity.PickupService;
using Marsen.NetCore.Dojo.Kata.PickupService.Interface;
using Microsoft.Extensions.Logging;
using Status = Marsen.NetCore.Dojo.Kata.PickupService.Entity.PickupService.Status;

[assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Tests")]

namespace Marsen.NetCore.Dojo.Kata.PickupService.Services
{
    public class PickupService : IQueryStatus
    {
        private const string DeliveryOrder = "DeliveryOrder";
        private readonly IConfigService _configService;
        private readonly ILogger _logger;
        private readonly IStoreSettingService _storeSettingService;
        internal HttpClient HttpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PickupService" /> class.
        /// </summary>
        public PickupService(IConfigService configService, IStoreSettingService storeSettingService, ILogger logger)
        {
            _configService = configService;
            _storeSettingService = storeSettingService;
            _logger = logger;
            HttpClient = new HttpClient();
        }

        public List<ShippingOrderUpdateEntity> GetUpdateStatus(long storeId, List<string> waybillNo)
        {
            try
            {
                var result = new List<ShippingOrderUpdateEntity>();

                var loginId = _storeSettingService.GetValue(storeId, "pickup.service", "loginId");
                if (loginId.IsNullOrEmpty()) throw new DojoException("error login Id");

                HttpClient.DefaultRequestHeaders.Add("login_id", loginId);

                var auth = _storeSettingService.GetValue(storeId, "pickup.service", "auth");
                HttpClient.DefaultRequestHeaders.Add("authorization", auth);
                var httpContent = new StringContent(
                    JsonSerializer.Serialize(new { Type = DeliveryOrder, waybillNo }),
                    Encoding.UTF8, "application/json");
                var url = _configService.GetAppSetting("pickup.service.url");
                var responseMessage = HttpClient.PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
                var obj = JsonSerializer.Deserialize<ResponseEntity>(responseMessage);
                if (obj?.Result == "error") throw new DojoException($"response is:{obj}");

                foreach (var c in obj!.Content.Where(c => string.IsNullOrEmpty(c.ErrorCode)))
                {
                    var shippingOrderUpdateEntity = new ShippingOrderUpdateEntity
                    {
                        OuterCode = c.WaybillNo,
                        AcceptTime = GetAcceptTime(c.LastStatusDate, c.LastStatusTime)
                    };
                    switch (c.Status)
                    {
                        case Status.DONE:
                            shippingOrderUpdateEntity.Status = Entity.Status.Finish;
                            break;

                        case Status.Shipping:
                            shippingOrderUpdateEntity.Status = Entity.Status.Processing;
                            break;

                        case Status.FAIL:
                        case Status.Expiry:
                            shippingOrderUpdateEntity.Status = Entity.Status.Abnormal;
                            break;

                        case Status.Arrived:
                            shippingOrderUpdateEntity.Status = Entity.Status.Arrived;
                            break;
                    }

                    result.Add(shippingOrderUpdateEntity);
                }

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "發生未預期的錯誤");
                throw;
            }
        }

        private DateTime GetAcceptTime(string date, string time)
        {
            return DateTime.Parse($"{date} {time}");
        }
    }
}