﻿using System.Net.Http;
using System.Text.Json;
using Marsen.NetCore.Dojo.Kata.Api_Pay.Interface;

namespace Marsen.NetCore.Dojo.Kata.Api_Pay;

public class PaymentService
{
    private readonly IConfigure _configure;

    public PaymentService(IConfigure configure)
    {
        _configure = configure;
        httpClient = new HttpClient();
    }

    public HttpClient httpClient { get; set; }

    public void Pay(PayEntity payEntity)
    {
        var apiUrl = _configure.Setting("PayService.Url");
        var requestId = httpClient.GetAsync($"{apiUrl}requestId").Result.Content
            .ReadAsStringAsync().Result;
        payEntity.RequestId = requestId;
        HttpContent content = new StringContent(
            JsonSerializer.Serialize(payEntity));
        httpClient.PostAsync($"{apiUrl}pay/CreditCard", content);
    }
}