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
3. 回傳的狀態有異常，記錄回傳的異常狀態，拋出 Exception


##

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





