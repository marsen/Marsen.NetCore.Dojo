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
        // your can get mock response from readme3.md
        private readonly List<string> _testWaybillNo = ["TEST2002181800010"];
        private const string MockDone = "https://marsen.me/mocks/pickup-service/api/done.json"; //done
        private const string MockShipping = "https://marsen.me/mocks/pickup-service/api/shipping.json"; //shipping
        private const string MockFail = "https://marsen.me/mocks/pickup-service/api/fail.json"; //fail
        private const string MockExpiry = "https://marsen.me/mocks/pickup-service/api/expiry.json"; //expiry
        private const string MockArrived = "https://marsen.me/mocks/pickup-service/api/arrived.json"; //arrived
        private const string MockResultError = "https://blog.marsen.me/mocks/pickup-service/api/content-error.json"; //result error
        private const string MockContentError = "https://ed9776f44ac242e0ae4088579d0ee6b4.api.mockbin.io/"; //content error
        private const string MockException = "https://blog.marsen.me/mocks/pickup-service/api/exception.txt"; //exception
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
            var actual = QueryWaybillNoWith(MockDone);
            actual.Should().Be(Status.Finish);
        }

        [Fact]
        public void Case2_Query_Shipping_waybillNo()
        {
            var actual = QueryWaybillNoWith(MockShipping);
            actual.Should().Be(Status.Processing);
        }


        [Fact]
        public void Case3_Query_FAIL_waybillNo()
        {
            var actual = QueryWaybillNoWith(MockFail);
            actual.Should().Be(Status.Abnormal);
        }


        [Fact]
        public void Case4_Query_Expiry_waybillNo()
        {
            var actual = QueryWaybillNoWith(MockExpiry);
            actual.Should().Be(Status.Abnormal);
        }

        [Fact]
        public void Case5_Query_Arrived_waybillNo()
        {
            var actual = QueryWaybillNoWith(MockArrived);
            actual.Should().Be(Status.Arrived);
        }


        [Fact]
        public void Case6_Query_Error_Result()
        {
            GetPickupServiceWith(MockResultError);
            Action act = () => _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(message: null);
        }


        [Fact]
        public void Case7_Query_Error_Content()
        {
            GetPickupServiceWith(MockContentError);
            var actual = _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            actual.Should().BeEmpty();
        }

        [Fact]
        public void Case8_Query_Exception()
        {
            GetPickupServiceWith(MockException);
            Action act = () => _target.GetUpdateStatus(TestStoreId, _testWaybillNo);
            act.Should().Throw<Exception>();
            _logger.ReceivedWithAnyArgs().LogError(message: null);
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
            return _target.GetUpdateStatus(TestStoreId, _testWaybillNo).FirstOrDefault()?.Status;
        }
    }
}