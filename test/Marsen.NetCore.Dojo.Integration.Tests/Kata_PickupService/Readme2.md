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
    [Fact]
    public void GetUpdateStatusTest()
    {
        ILogger logger = Substitute.For<ILogger>();
        IStoreSettingService storeSettingService = Substitute.For<IStoreSettingService>();
        IConfigService configService = Substitute.For<IConfigService>();
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
```

