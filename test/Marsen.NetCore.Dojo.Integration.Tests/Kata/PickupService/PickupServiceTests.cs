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
        private const string MockDone = "https://run.mocky.io/v3/78b1a1a1-73df-438f-bdc2-a9dc44eb831d";
        private const string MockShipping = "https://run.mocky.io/v3/9b45256d-9a97-4c1b-a47d-02d48936f430";
        private const string MockFail = "https://run.mocky.io/v3/08f3a00d-422c-4857-8013-461aa83e6fe5";
        private const string MockExpiry = "https://run.mocky.io/v3/eebd3428-ba81-446b-aa12-50b0911025c7";
        private const string MockArrived = "https://run.mocky.io/v3/d573611f-f313-463f-b1f9-962ff997de6c";
        private const string MockResultError = "https://run.mocky.io/v3/e5d70d4a-952e-44cd-872a-83d67df0f27c";
        private const string MockContentError = "https://run.mocky.io/v3/92e7d9d4-9890-417a-9d02-ddf373a4a3c2";
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