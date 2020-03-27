using FluentAssertions;
using Marsen.NetCore.Dojo.Kata_PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity;
using Marsen.NetCore.Dojo.Kata_PickupService.Entity.PickupService;
using Marsen.NetCore.Dojo.Kata_PickupService.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_PickupService
{
    public class PickupServiceTests
    {
        private readonly PickupService _target;

        public PickupServiceTests()
        {
            _target = GetPickupService();
        }

        [Fact]
        public void OneDoneDataShouldBeFinish()
        {
            var actual = SingleResponse(Status.DONE);
            actual.Should().BeEquivalentTo(SingleEntity(StatusEnum.Finish));
        }

        [Fact]
        public void OneShippingDataShouldBeProcessing()
        {
            var actual = SingleResponse(Status.Shipping);
            actual.Should().BeEquivalentTo(SingleEntity(StatusEnum.Processing));
        }


        [Fact]
        public void OneFAILDataShouldBeAbnormal()
        {
            var actual = SingleResponse(Status.FAIL);
            actual.Should().BeEquivalentTo(SingleEntity(StatusEnum.Abnormal));
        }


        [Fact]
        public void OneExpiryDataShouldBeAbnormal()
        {
            var actual = SingleResponse(Status.Expiry);
            actual.Should().BeEquivalentTo(SingleEntity(StatusEnum.Abnormal));
        }


        [Fact]
        public void OneArrivedDataShouldBeArrived()
        {
            var actual = SingleResponse(Status.Arrived);
            actual.Should().BeEquivalentTo(SingleEntity(StatusEnum.Arrived));
        }


        private static List<ShippingOrderUpdateEntity> SingleEntity(StatusEnum status)
        {
            return new List<ShippingOrderUpdateEntity>
            {
                new ShippingOrderUpdateEntity
                {
                    AcceptTime = new DateTime(2020, 03, 03, 17, 51, 20),
                    OuterCode = "TestWayBillNo",
                    Status = status
                }
            };
        }

        private List<ShippingOrderUpdateEntity> SingleResponse(Status status)
        {
            _target.HttpClient =
                new HttpClient(
                    new MockHttpMessageHandler(JsonSerializer.Serialize(
                            new ResponseEntity
                            {
                                Result = "",
                                Content = new List<Content>
                                {
                                    new Content
                                    {
                                        ErrorCode = string.Empty,
                                        Status = status,
                                        LastStatusDate = "2020-03-03",
                                        LastStatusTime = "17:51:20",
                                        WaybillNo = "TestWayBillNo"
                                    }
                                }
                            }),
                        HttpStatusCode.OK));
            var actual = _target.GetUpdateStatus(2, new List<string> {"TestWayBillNo"});
            return actual;
        }

        private static PickupService GetPickupService()
        {
            ILogger logger = Substitute.For<ILogger>();
            IStoreSettingService storeSettingService = Substitute.For<IStoreSettingService>();
            storeSettingService.GetValue(Arg.Any<long>(), "pickup.service", "auth").Returns("FakeAuth");
            IConfigService configService = Substitute.For<IConfigService>();
            configService.GetAppSetting("pickup.service.url").Returns("https://test.com/");

            var target = new PickupService(configService, storeSettingService, logger);
            return target;
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        public string Input { get; private set; }
        public int NumberOfCalls { get; private set; }

        public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            NumberOfCalls++;
            if (request.Content != null) // Could be a GET-request without a body
            {
                Input = await request.Content.ReadAsStringAsync();
            }

            return new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            };
        }
    }
}