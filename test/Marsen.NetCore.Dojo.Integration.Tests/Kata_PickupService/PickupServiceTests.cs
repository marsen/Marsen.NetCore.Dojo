using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Kata_PickupService
{
    public class PickupServiceTests
    {
        private readonly IConfigService _configService;
        private PickupService target;
        private readonly long _testStoreId = 1;
        private readonly List<string> _testWaybillNo = new List<string> {"TEST2002181800010"};
        private string UrlMockDone = "http://www.mocky.io/v2/5e4e56832f0000f55116a60b";
        private string UrlMockShipping = "http://www.mocky.io/v2/5e5284962d0000f622357b3f";
        private string UrlMockFAIL = "http://www.mocky.io/v2/5e5290812d0000261d357b5c";
        private string UrlMockExpiry = "http://www.mocky.io/v2/5e5292462d00004c00357b5e";
        private string UrlMockArrived = "http://www.mocky.io/v2/5e5293ff2d0000dd36357b61";
        private string UrlMockResultError = "http://www.mocky.io/v2/5e5bb89b3000004c00f9f29f";
        private string UrlMockContentError = "http://www.mocky.io/v2/5e5c83cd3200006d0043c197";
        private string UrlMockException = "https://www.mocky.io/v2/5e5cad1b320000530043c260";
        private readonly IStoreSettingService _storeSettingService;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupServiceTests" /> class.
        /// </summary>
        public PickupServiceTests()
        {
            _logger = Substitute.For<ILogger>();
            _configService = Substitute.For<IConfigService>();
            _storeSettingService = Substitute.For<IStoreSettingService>();
        }

        [Fact]
        public void Case1_Query_Done_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockDone);
            actual.Should().Be(StatusEnum.Finish);
        }

        [Fact]
        public void Case2_Query_Shipping_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockShipping);
            actual.Should().Be(StatusEnum.Processing);
        }


        [Fact]
        public void Case3_Query_FAIL_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockFAIL);
            actual.Should().Be(StatusEnum.Abnormal);
        }


        [Fact]
        public void Case4_Query_Expiry_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockExpiry);
            actual.Should().Be(StatusEnum.Abnormal);
        }

        [Fact]
        public void Case5_Query_Arrived_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockArrived);
            actual.Should().Be(StatusEnum.Arrived);
        }


        [Fact]
        public void Case6_Query_Error_Result()
        {
            GetPickupServiceWith(UrlMockResultError);
            Action act = () => target.GetUpdateStatus(_testStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(default(string));
        }


        [Fact]
        public void Case7_Query_Error_Content()
        {
            GetPickupServiceWith(UrlMockContentError);
            var actual = target.GetUpdateStatus(_testStoreId, _testWaybillNo);
            actual.Should().BeEmpty();
        }

        [Fact]
        public void Case8_Query_Exception()
        {
            GetPickupServiceWith(UrlMockException);
            Action act = () => target.GetUpdateStatus(_testStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(default(string));
        }

        private void GetPickupServiceWith(string url)
        {
            _configService.GetAppSetting("pickup.service.url")
                .Returns(url);
            _storeSettingService.GetValue(_testStoreId, "pickup.service", "loginId").Returns("testId");
            _storeSettingService.GetValue(_testStoreId, "pickup.service", "auth").Returns("testAuth");
            target = new PickupService(_configService, _storeSettingService, _logger);
        }


        private StatusEnum? QueryWaybillNoWith(string url)
        {
            GetPickupServiceWith(url);
            return target.GetUpdateStatus(_testStoreId, _testWaybillNo).FirstOrDefault().Status;
        }
    }
}