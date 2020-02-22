using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_PickupService;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_PickupService
{
    public class PickupServiceTests
    {
        [Fact]
        public void Case1_Query_Done_waybillNo()
        {
            var configService = Substitute.For<IConfigService>();
            configService.GetAppSetting("pickup.service.url")
                .Returns("http://www.mocky.io/v2/5e4e56832f0000f55116a60b");
            var target = new PickupService(configService);
            long storeId = 1;
            var waybillNo = new List<string> {"TEST2002181800010"};
            var actual = target.GetUpdateStatus(storeId, waybillNo).FirstOrDefault().Status;
            actual.Should().Be(StatusEnum.Finish);
        }
    }
}