using System;
using System.Collections.Generic;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_PickupService
{
    public class PickupServiceTests
    {
        [Fact]
        public void GetUpdateStatusTest()
        {
            ILogger logger = Substitute.For<ILogger>();
            IStoreSettingService storeSettingService = Substitute.For<IStoreSettingService>();
            storeSettingService.GetValue(Arg.Any<long>(), "pickup.service", "auth").Returns("FakeAuth");
            IConfigService configService = Substitute.For<IConfigService>();
            configService.GetAppSetting("pickup.service.url").Returns("https://test.com/");

            var target = new PickupService(configService, storeSettingService, logger);

            var actual = target.GetUpdateStatus(2, new List<string> {"TestWayBillNo"});
            actual.Should().BeEquivalentTo(new List<ShippingOrderUpdateEntity>
            {
                new ShippingOrderUpdateEntity
                {
                    AcceptTime = new DateTime(2020, 03, 03, 17, 51, 20),
                    OuterCode = "TestWayBillNo",
                    Status = StatusEnum.Finish
                }
            });
        }
    }
}