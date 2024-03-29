﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity;
using Marsen.NetCore.Dojo.Kata.PickupService.Entity.PickupService;
using Marsen.NetCore.Dojo.Kata.PickupService.Interface;
using Marsen.NetCore.TestingToolkit;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;
using Status = Marsen.NetCore.Dojo.Kata.PickupService.Entity.Status;

namespace Marsen.NetCore.Dojo.Tests.Kata.PickupService.Services
{
    public class PickupServiceTests
    {
        private readonly Dojo.Kata.PickupService.Services.PickupService _target;

        public PickupServiceTests()
        {
            _target = GetPickupService();
        }

        [Fact]
        public void OneDoneDataShouldBeFinish()
        {
            var actual = SingleResponse("DONE");
            actual.Should().BeEquivalentTo(SingleEntity(Status.Finish));
        }

        [Fact]
        public void OneShippingDataShouldBeProcessing()
        {
            var actual = SingleResponse("Shipping");
            actual.Should().BeEquivalentTo(SingleEntity(Status.Processing));
        }

        [Fact]
        public void OneFAILDataShouldBeAbnormal()
        {
            var actual = SingleResponse("FAIL");
            actual.Should().BeEquivalentTo(SingleEntity(Status.Abnormal));
        }

        [Fact]
        public void OneExpiryDataShouldBeAbnormal()
        {
            var actual = SingleResponse("Expiry");
            actual.Should().BeEquivalentTo(SingleEntity(Status.Abnormal));
        }

        [Fact]
        public void OneArrivedDataShouldBeArrived()
        {
            var actual = SingleResponse("Arrived");
            actual.Should().BeEquivalentTo(SingleEntity(Status.Arrived));
        }

        [Fact]
        public void OneUnKnowDataShouldThrowException()
        {
            Action act = () => UnKnowResponse("Un Know Status");
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void OneErrorDataShouldThrowException()
        {
            Action act = ErrorResponse;
            act.Should().Throw<Exception>();
        }

        private void ErrorResponse()
        {
            _target.HttpClient = new HttpClient(
                new MockHttpMessageHandler(
                    "{\"result\":\"error\"}", HttpStatusCode.OK));
            _target.GetUpdateStatus(2, new List<string> { "TestWayBillNo" });
        }

        private void UnKnowResponse(string unKnowStatus)
        {
            _target.HttpClient = new HttpClient(new MockHttpMessageHandler("{\"result\":null," +
                                                                           "\"content\":" +
                                                                           "[{\"merchantId\":null," +
                                                                           "\"merchantRef\":null," +
                                                                           "\"waybillNo\":null," +
                                                                           "\"locationId\":null," +
                                                                           "\"pudoRef\":null," +
                                                                           "\"pudoVerifyCode\":null," +
                                                                           "\"senderId\":null," +
                                                                           "\"consigneeId\":null," +
                                                                           "\"customerName\":null," +
                                                                           "\"customerAddress1\":null," +
                                                                           "\"customerAddress2\":null," +
                                                                           "\"customerAddress3\":null," +
                                                                           "\"customerAddress4\":null," +
                                                                           "\"feedbackURL\":null," +
                                                                           "\"eta\":null," +
                                                                           "\"codAmt\":null," +
                                                                           "\"sizeCode\":null," +
                                                                           "\"item\":null," +
                                                                           $"\"lastStatusId\":\"{{{unKnowStatus}}}\"," +
                                                                           "\"lastStatusDescription\":null," +
                                                                           "\"lastStatusDate\":null," +
                                                                           "\"lastStatusTime\":null," +
                                                                           "\"customerMobile\":null," +
                                                                           "\"customerEmail\":null," +
                                                                           "\"errorCode\":\"\"}]}",
                HttpStatusCode.OK));
            _target.GetUpdateStatus(2, new List<string> { "TestWayBillNo" });
        }

        private static List<ShippingOrderUpdateEntity> SingleEntity(Status status)
        {
            return new List<ShippingOrderUpdateEntity>
            {
                new()
                {
                    AcceptTime = new DateTime(2020, 03, 03, 17, 51, 20),
                    OuterCode = "TestWayBillNo",
                    Status = status
                }
            };
        }

        private List<ShippingOrderUpdateEntity> SingleResponse(string status)
        {
            _target.HttpClient =
                new HttpClient(
                    new MockHttpMessageHandler(JsonSerializer.Serialize(
                            new ResponseEntity
                            {
                                Result = "",
                                Content = new List<Content>
                                {
                                    new()
                                    {
                                        ErrorCode = string.Empty,
                                        Status = (Dojo.Kata.PickupService.Entity.PickupService.Status)Enum.Parse(
                                            typeof(Dojo.Kata.PickupService.Entity.PickupService.Status), status),
                                        LastStatusDate = "2020-03-03",
                                        LastStatusTime = "17:51:20",
                                        WaybillNo = "TestWayBillNo"
                                    }
                                }
                            }),
                        HttpStatusCode.OK));
            var actual = _target.GetUpdateStatus(2, new List<string> { "TestWayBillNo" });
            return actual;
        }

        private Dojo.Kata.PickupService.Services.PickupService GetPickupService()
        {
            var logger = Substitute.For<ILogger>();
            var storeSettingService = Substitute.For<IStoreSettingService>();
            storeSettingService.GetValue(Arg.Any<long>(), Arg.Is("pickup.service"), Arg.Is("loginId"))
                .Returns("FakeLoginId");
            storeSettingService.GetValue(Arg.Any<long>(), Arg.Is("pickup.service"), Arg.Is("auth")).Returns("FakeAuth");
            var configService = Substitute.For<IConfigService>();
            configService.GetAppSetting("pickup.service.url").Returns("https://test.com/");

            var target = new Dojo.Kata.PickupService.Services.PickupService(configService, storeSettingService, logger);
            return target;
        }
    }
}