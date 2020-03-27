## 異常處理的 Todo 項目

異常處理有幾種狀況，
一種是回傳的狀態有異常，
一種是回傳的資料有異常，
最後一種是超乎預期的異常，
比如說 Http 通訊上本身有問題。

再進一步分析這三種狀況，
我會寫下以下幾種情境

1. 回傳的狀態有異常，記錄回傳的異常狀態，拋出 Exception
2. 回傳的資料有異常，記錄回傳的異常資料，回傳空資料
3. 超乎預期的異常，記錄異常資料, 拋出 Exception

## 測試案例 回傳的狀態有異常，記錄回傳的異常狀態，拋出 Exception


新增測試案例
這裡複製之前的測試案例，
再透過 inline Method 還原 arrange 部份的代碼，
再修改成我們想要的測試案例。

這裡我們先驗証拋出 Exception

```csharp
    [Fact]
    public void Case6_Query_Error_Result()
    {
        _configService.GetAppSetting("pickup.service.url")
            .Returns(UrlMockResultError);
        _storeSettingService.GetValue(_testStoreId, "pickup.service", "loginId").Returns("testId");
        _storeSettingService.GetValue(_testStoreId, "pickup.service", "auth").Returns("testAuth");
        target = new PickupService(_configService, _storeSettingService);

        Action act = () => target.GetUpdateStatus(_testStoreId, _testWaybillNo);
        act.Should().Throw<Exception>();
    }
```


Production Code 就單純很多了

```csharp
    if (obj.result == "error")
    {
        throw new Exception();
    }
```

下一步我要驗証記錄 Log 的行為
出錯的時候應該呼叫 LogError 的方法

原本想直接驗証 LogError 有沒有被呼叫

```csharp 
    [Fact]
    public void Case7_Query_Error_Result_Should_LogError()
    {
        GetPickupServiceWith(UrlMockResultError);
        target.GetUpdateStatus(_testStoreId, _testWaybillNo);        
        _logger.Received().LogError(Arg.Any<string>());
    }

```

因為這裡會拋出 Exception ，
所以無法直接呼叫  GetUpdateStatus 
要修改前一個測試

```csharp
    [Fact]
    public void Case6_Query_Error_Result()
    {
        GetPickupServiceWith(UrlMockResultError);
        Action act = () => target.GetUpdateStatus(_testStoreId, _testWaybillNo);
        act.Should().Throw<Exception>();
        _logger.ReceivedWithAnyArgs().LogError(default(string));
    }
```

而 Produciton Code 很單純的加上 Logger 並調整建構子

```csharp
-   public PickupService(IConfigService configService, IStoreSettingService storeSettingService)        
+   public PickupService(IConfigService configService, IStoreSettingService storeSettingService, ILogger logger)
    {
        this._configService = configService;
        this._storeSettingService = storeSettingService;
+       this._logger = logger;
    }

    if (obj.result == "error")
    {
+       this._logger.LogError(obj.result);
        throw new Exception();
    }
```

## 回傳的資料有異常，記錄回傳的異常資料，回傳空資料

測試案例

```csharp
   [Fact]
   public void Case7_Query_Error_Content()
   {
        GetPickupServiceWith(UrlMockContentError);
        var actual = target.GetUpdateStatus(_testStoreId, _testWaybillNo);
        actual.Should().BeEmpty();
   }
```

調整代碼以通過測試

```csharp
+    if (string.IsNullOrEmpty(c.ErrorCode))
+    {
        switch (c.Status)
        {
            ////略…
        }
+    }
```

## 超乎預期的異常，記錄異常資料, 拋出 Exception

測試

```csharp
    [Fact]
    public void Case8_Query_Exception()
    {
        GetPickupServiceWith(UrlMockException);
        Action act = () => target.GetUpdateStatus(_testStoreId, _testWaybillNo);
        act.Should().Throw<Exception>();
        _logger.ReceivedWithAnyArgs().LogError(default(string));
    }
```

Production Code 就直接整個用 try Catch 包起來再記 Log

## 實務上的案例

這裡補充一些實務上的情境，
1. 呼叫狀態查詢時，對方的 API 只允許同查詢 100 筆 WayBillNo
2. 呼叫 API 後多了幾種文件外的狀態需要處理
   - D → Finish
   - F → Finish
   - E → Abnormal 

## 單元測試現身
現在我已經有一些整合測試作保護了，
但是想要修改或重構仍然很麻煩，
原因是我每次有新的情境就需要準備新的 Mock API(實務上我需要準備符合情境的 WayBillNo)，
透過 Todo 與整合測試，已經讓我們的代碼有了雛型。
在一切太晚之前，我們需撰寫單元測試。


### Do TODO 建立單元測試

這裡小小提個 Visual Studio 2019 的小問題 ，  
預設只會安裝 MSTest 的 Generator ，  
這裡我要安裝 [XUnit 的 Generator](https://marketplace.visualstudio.com/items?itemName=YowkoTsai.xUnitnetTestGenerator) ，  
安裝完成後再透過 Code Generator 產生第一個測試，紅燈。

當然這種 Generator 產生的 Code 不是實際要的測試案例
調整一下測試案例

```csharp
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
```
### Legacy Code 相依 HttpClient

大部份的功能我都可以透過 DI 的手段隔離，
但是之前的 Test Driven Develop 的方法並沒有將 HttpClient 轉換成可以隔離的物件。
另外一部份代碼是透過 Copy Paste 手法產生的代碼，所以也有可能會有 Legacy Code。
這裡我優先處理 HttpClient 。

首先我要重構一小段代碼，所幸之前的整合測試可以保護我這段重構

```csharp
+       internal HttpClient HttpClient;
        private const string DeliveryOrder = "DeliveryOrder";

        try
        {
            var result = new List<ShippingOrderUpdateEntity>();
-           var httpClient = new HttpClient();
+           this.HttpClient?? = new HttpClient();
```



在測試的保護下，我要逐步修改我的 HttpClient ，
好讓我的單元測能夠通過。
其實我目前的單元測試還未完成，所以可以先 Skip 掉，
等 HttpClient 隔離完成後再回頭完成單元測試。

### 隔離 HttpClient

這裡我要回顧一下，之前在作 [Kata_Api_Pay]() 的時候，
我在 Production Code 建立了 `IHttpClient` 的介面，
用於隔離 `HttpClient` 。
我可以延用 HttpClient 但是因為我未實作 `DefaultRequestHeaders` 欄位，
這會導致一些錯誤; 
雖然我可以一併調整但是這樣我要同時面對兩份遺留代碼，
我認為這樣的風險太大，而且使用 `IHttpClient` 目前看起來出現一些問題。

1. 雖然抽出介面，但依賴在 `HttpClient` 之上，未來有功能不足或未實作 HttpClient 的功能就仍需要調整。
2. 最初的目的其實是為了隔離，而隔離的目的是為了好測試，這些代碼卻放在 Production Code 上實在很奇怪。

基於以上種種理由，我要重新作一次隔離。
要達到幾個目地。

1. 真正的與 `HttpClient` 解耦，未來再有用到 HttpClient 的任何方法/欄位皆不影響即有代碼。
2. 將這類的工具放到正確專案 `TestingToolkit` 之下，不再影響 Production Code


首先允許測試專案存取 Production Code 的 Internal 欄位
```csharp
+       [assembly: InternalsVisibleTo("Marsen.NetCore.Dojo.Tests")]
        namespace Marsen.NetCore.Dojo.Kata_PickupService
```

下一步，偽造 HttpClient 的回傳值，  
我們可以透過 HttpClient 的建構子作到這件事。  
參考這篇[文章](https://dev.to/n_develop/mocking-the-httpclient-in-net-core-with-nsubstitute-k4j)


```csharp
    target.HttpClient =
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
                    Status = Status.DONE,
                    lastStatusDate = "2020-03-03",
                    lastStatusTime = "17:51:20"
                }
            }
        }), 
    HttpStatusCode.OK));
```


### 參考

- https://dev.to/n_develop/mocking-the-httpclient-in-net-core-with-nsubstitute-k4j
