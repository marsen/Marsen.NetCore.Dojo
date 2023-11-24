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
        private const string MockDone = "https://demo3287250.mockable.io/DONE";
        private const string MockShipping = "https://demo3287250.mockable.io/Shipping";
        private const string MockFail = "https://demo3287250.mockable.io/FAIL";
        private const string MockExpiry = "https://demo3287250.mockable.io/Expiry";
        private const string MockArrived = "https://demo3287250.mockable.io/Arrived";
        private const string MockResultError = "https://demo3287250.mockable.io/Error";
        private const string MockContentError = "https://demo3287250.mockable.io/ContentError";
        private const string MockException = "https://demo3287250.mockable.io/Exception";
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
            _logger.ReceivedWithAnyArgs().LogError(default);
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
            _logger.ReceivedWithAnyArgs().LogError(default);
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