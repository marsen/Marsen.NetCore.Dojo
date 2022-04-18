using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity;
using Marsen.NetCore.Dojo.Kata.PickupService.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Kata.PickupService
{
    public class PickupServiceTests
    {
        private readonly IConfigService _configService;
        private Dojo.Kata.PickupService.Services.PickupService _target;
        private const long TestStoreId = 1;
        private readonly List<string> _testWaybillNo = new() {"TEST2002181800010"};
        private const string UrlMockDone = "http://www.mocky.io/v2/5e4e56832f0000f55116a60b";
        private const string UrlMockShipping = "http://www.mocky.io/v2/5e5284962d0000f622357b3f";
        private const string UrlMockFail = "http://www.mocky.io/v2/5e5290812d0000261d357b5c";
        private const string UrlMockExpiry = "http://www.mocky.io/v2/5e5292462d00004c00357b5e";
        private const string UrlMockArrived = "http://www.mocky.io/v2/5e5293ff2d0000dd36357b61";
        private const string UrlMockResultError = "http://www.mocky.io/v2/5e5bb89b3000004c00f9f29f";
        private const string UrlMockContentError = "http://www.mocky.io/v2/5e5c83cd3200006d0043c197";
        private const string UrlMockException = "https://www.mocky.io/v2/5e5cad1b320000530043c260";
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
            actual.Should().Be(Status.Finish);
        }

        [Fact]
        public void Case2_Query_Shipping_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockShipping);
            actual.Should().Be(Status.Processing);
        }


        [Fact]
        public void Case3_Query_FAIL_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockFail);
            actual.Should().Be(Status.Abnormal);
        }


        [Fact]
        public void Case4_Query_Expiry_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockExpiry);
            actual.Should().Be(Status.Abnormal);
        }

        [Fact]
        public void Case5_Query_Arrived_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockArrived);
            actual.Should().Be(Status.Arrived);
        }


        [Fact]
        public void Case6_Query_Error_Result()
        {
            GetPickupServiceWith(UrlMockResultError);
            Action act = () => _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(default(string));
        }


        [Fact]
        public void Case7_Query_Error_Content()
        {
            GetPickupServiceWith(UrlMockContentError);
            var actual = _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            actual.Should().BeEmpty();
        }

        [Fact]
        public void Case8_Query_Exception()
        {
            GetPickupServiceWith(UrlMockException);
            Action act = () => _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(default(string));
        }

        private void GetPickupServiceWith(string url)
        {
            _configService.GetAppSetting("pickup.service.url")
                .Returns(url);
            _storeSettingService.GetValue(TestStoreId, "pickup.service", "loginId").Returns("testId");
            _storeSettingService.GetValue(TestStoreId, "pickup.service", "auth").Returns("testAuth");
            _target = new Dojo.Kata.PickupService.Services.PickupService(_configService, _storeSettingService, _logger);
        }


        private Status? QueryWaybillNoWith(string url)
        {
            GetPickupServiceWith(url);
            return _target.GetUpdateStatus(TestStoreId, _testWaybillNo).FirstOrDefault().Status;
        }
    }
}