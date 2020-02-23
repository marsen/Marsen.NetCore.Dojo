﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_PickupService
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PickupServiceTests" /> class.
        /// </summary>
        public PickupServiceTests()
        {
            _configService = Substitute.For<IConfigService>();
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


        private StatusEnum? QueryWaybillNoWith(string url)
        {
            _configService.GetAppSetting("pickup.service.url")
                .Returns(url);
            target = new PickupService(_configService);
            return target.GetUpdateStatus(_testStoreId, _testWaybillNo).FirstOrDefault().Status;
        }
    }
}