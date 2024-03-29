﻿#  Marsen way TDD Kata - PickupService I
## 前情提要

作完金流作物流，這次在開發的過程中首次全程用 TDD 進行，  
因為某些因素，測試沒有進版控，所以稍微記錄一下心路歷程。  
至於那個 T 是什麼? 就請各位看下去了…

## 需求說明 

出貨流程為:
1. 訂單成立
2. 透過物流服務配號
3. 出貨
4. 透過物流服務查詢物流狀態
5. 狀態正確，通知消費者取貨
6. 狀態不正確，通知商家，人工處理。

這次 TDD 進行的部份為流程上的第 4 步，
再看看怎麼進行 ? 

整體流程如下

## 流程 

Step0 . 這次不是從無到有，而是在遺留代碼之中建立測試，
所以我會準備一些「遺留代碼」來呈現我面臨的狀況。

Step1 . 這次 TDD 先不是 Test 而 TODO，   
直接對 Production Code 寫下 Todo List，   
這個 TODO 的過程其實就是一種分析，一種需求拆分。

這裡我先簡單拆成兩步，
1. 打 API 問狀態
2. 將問到的資料轉換成回傳資料

Step 2 . 隨著過程把 TODO 拆的更細
1. 打 API 問狀態
   1. 建立 HttpClient
   2. 建立 auth
   3. 準備 HttpContent 資料
   4. 指定 API URL 
   5. 呼叫
...

一般這個時候，我就會進開發了，  
這次我不打算刻意改變我的開發習慣，  
但是我會多作一件事，寫測試。  
這個測試會直接呼叫我即將開發的方法，  
而我的方法會真的去打 API 存取 DB 讀 Config Files 諸如此類的事情。

## 測試 

### Case 1 

我目前對測試案例沒有任何的想法(這是個壞味道)， 
但是我打算直接呼叫我的 Production Code 

```csharp
[Fact]
public void Case1_Just_Run()
{
    var target = new PickupService();
    long storeId = 0;
    List<string> waybillNo = new List<string>();
    target.GetUpdateStatus(storeId, waybillNo);
}
```

因為沒有想法，所以沒有 `Assert`
但是我得到一個小工具可以隨時呼叫我的 Production Code

### Do Todo 建立 HttpClient

這裡依造我以前的開發習慣，直接開幹，  
把 HttpClient new 出來，刪除 Todo Comment  
Committed 然後發 Pull Request

```csharp
-            //// TODO 1.建立 HttpClient
+            var httpClient = new HttpClient();
```

### Do Todo 建立 auth

通常在串接第三方服務的過程中，  
第三方會提供沙盒(SandBox)作開發人員測試使用  
這裡我加了一點遮罩，但實務上如果是沙盒的 auth 資訊  
我可能會直接 Commit 進去(壞味道)。

注意!! 這時候還是 Production Code 喔  
我可以在測試加個 TODO ，  
未來這段應該被 Mock 而不是 Hard Code 寫死。


```csharp
-           //// TODO 2.建立 auth
+           //// TODO login id 抽參數
+           httpClient.DefaultRequestHeaders.Add("login_id", "testId");
+           //// TODO authorization 抽參數
+           httpClient.DefaultRequestHeaders.Add("authorization", "testAuth");
```

### Do Todo 準備 HttpContent 資料

準備 HttpContent 有很多種方式，  
這裡我選擇 StringContent 來實作。  
所以要包含物件轉換成 Json String 的行為，  
需要參考 JsonSerializer 。   
如果是不太熟悉的開發人員可能會另開 TODO，  
但是我這裡就一次性的作掉了 。 

```csharp
-           //// TODO 3.準備 HttpContent 資料
            
+           var requestContent = JsonSerializer.Serialize(new { Type = "DeliveryOrder", waybillNo });
+           var httpContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
```

### Take a break

稍微休息一下，這裡我的開發流程基本上沒有改變，
除了多寫一個(整合)測試，而且每次都會稍微跑一下測試，
這個測試其實沒有 Assert ，唯一的幫助只能驗証執行方法時沒有 Exception

### 重構

重構應該落在開發之中，我看到兩個小問題
1. 我會 inline 掉多餘的參數 requestContent
2. Type = "DeliveryOrder" 對我來說是個 magic variable ，我會加 TODO 預計未來抽成常數(壞味道，Why not now ?)


### Do TODO 4.指定 API URL & TODO 5.呼叫

修改代碼如下，拿到第一個紅燈
因為我沒有指定 url

```
            //// TODO 4.指定 API URL
            string url=string.Empty;
            var responseMessage = httpClient.PostAsync(url, httpContent).Result;
```

為了修正這個紅燈我會指定 url，  
實務上我會使用沙盒的 url ，  
這裡我先用 mock api 取代 ，  
mock api 的服務為 [mocky](https://www.mocky.io/)，  
類似的服務很多，也不是本篇的重點，就不贅述了。

這次一次處理掉兩個 TODO ，  
表示當初我 TODO Task 切的過小，  
下次可以切大一些。

不算壞味道，就當學個經驗。

### 第一次 TODO 作完之後

當初規劃的 TODO Task 都作完了，  
但是其實工作並沒有完成。 

我會再作進一步的分析，  
可以看到原本的 TODO 產生了更多的 TODO ，  
另外打完 API 後的處理也是個問題。

這邊要用到 [walking skeleton](https://blog.marsen.me/2018/12/27/2018/csm/to_sum_up_scrum/) 的概念，　　

前面產生的 TODO 項目並不是「最」重要的，  
我應該先處理回傳的資料。  
開立 TODO 如下

```csharp
+           //// TODO Parse Response Entity
+           //// TODO Switch Status
+           //// TODO Return ShippingOrderUpdateEntity List 
```  

可以得知，我最終會回傳一包 List，  
這個時候我可以 Assert 了

### 修改 Case1  

這個階段我開始撥雲見日，我要很明確的寫下第一個測試案例，  
第一個案例我會直接作 Happy Case ，  
也就是目前的呼叫的 API
只打一筆，回傳 Done 的資料。

這裡進一步作需求分析，
呼叫完 API 我會收到一大包 JSON 資料，  
需要轉成我可以處理的物件，  
其中最重要的欄位 lastStatusId 會回傳各種狀態， 

- DONE
- FAIL
- Arrived
- Shipping
- SMS
- Expiry

我只處理

- 已取貨(DONE) 系統狀態為 Finish        
- 失敗(FAIL、Expiry) 系統狀態為 Abnormal
- 貨到待取(Arrived) 系統狀態為 Arrived
- 出貨中(Shipping) 系統狀態為 Processing

分析後，我的測項將會是向 API 循問一筆資料  
且回傳一筆為 Done 的 ShippingOrderUpdateEntity 給我。


```csharp
[Fact]
public void Case1_Query_Done_waybillNo()
{
    var target = new PickupService();
    long storeId = 1;
    List<string> waybillNo = new List<string> {"TEST2002181800010"};
    var actual = target.GetUpdateStatus(storeId, waybillNo).FirstOrDefault().Status;
    actual.Should().Be(StatusEnum.Finish);
}
```

### 拿到紅燈 ，Do TODO Parse Response Entity

如果是 Test Driven 我可能會速解再加案例，  
但是我現在是 Todo Driven 所以造著 Todo 作事，  
透過 json2csharp 快速產生 Entity 來轉置 JSON 資料。

### 如何從 T(odo)DD 到 T(est)DD

寫到這裡我已經開始感覺 Todo 的挶限性了，   
由於這個方法職責不分，所以要測試是困難的，   
但是 Todo 的作法是無法趨動改變的。

現在開始，試著把每個 Todo Task 改變成 Test Case

### 第二個測試案例開始之前

再次說明一下商務需求，我可以提供 waybillNo 向 API 循問物流的狀態。  
理想上我會擁有一堆不同貨態的 waybillNo ，剛好可以作我測試的案例  
但是在實務上，我拿不到這些案例， 我折衷的作法是透過 Dummy API 來偽裝回傳值。  
這仍是整合測試的一種，雖然我可以 Mock API 的回傳值，  
但在網路狀況異常下，測試仍會紅燈

在作 Dummy API 的前提下，要能抽換 URL 
所以我會先作 TODO url 抽參數 

重構如下:

Production Code

```csharp
-        //// TODO url 抽參數
-        //// string url= "http://www.mocky.io/v2/********";
-        string url = "http://www.mocky.io/v2/********";
+        string url = this._configService.GetAppSetting("pickup.service.url");
```

Test Mock Return Value

```csharp
        var configService = Substitute.For<IConfigService>();
        configService.GetAppSetting("pickup.service.url")
                .Returns("http://www.mocky.io/v2/********");
        var target = new PickupService(configService);
```


### 進一步增新測試的可讀性

可讀性真的是一個很抽象的觀念，之後有機會再深入探討  
我的修改如下，主要的想法是「讓測試案例可以像對話般被閱讀」

```csharp
        [Fact]
        public void Case1_Query_Done_waybillNo()
        {
            var actual = QueryWithDoneWaybillNo();
            actual.Should().Be(StatusEnum.Finish);
        }
```


### 第二個測試案例 - 出貨中(Shipping)

這裡就是用簡單的 Test Case 趨動 Production Code 的代碼生成

Test Code

```csharp
        [Fact]
        public void Case2_Query_Shipping_waybillNo()
        {
            var actual = QueryWithShippingWaybillNo();
            actual.Should().Be(StatusEnum.Processing);
        }
```

Production Code (部份)

```
-           //// TODO Switch Status
-           //// TODO Return ShippingOrderUpdateEntity List 
-           result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Finish});
+           foreach (var c in obj.content)
+           {
+               switch (c.lastStatusId)
+               {
+                   case "DONE":
+                       result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Finish});
+                       break;
+                   case "Shipping":
+                       result.Add(new ShippingOrderUpdateEntity {Status = StatusEnum.Processing});
+                       break;
+               }
+           }

```

順手再重構了一下測試，
希望能提高可讀性

```csharp
        [Fact]
        public void Case2_Query_Shipping_waybillNo()
        {
            var actual = QueryWaybillNoWith(UrlMockShipping);
            actual.Should().Be(StatusEnum.Processing);
        }
```

### 剩下的測試案例

- 失敗(FAIL) 系統狀態為 Abnormal
- 失敗(Expiry) 系統狀態為 Abnormal
- 貨到待取(Arrived) 系統狀態為 Arrived


### 剩下的 TODO 項目

這個時候基本的功能都好了，來收拾一下剩下的 TODO 項目吧  
主要都是取得設定值的功能，實務上這些設定值可能來自不同的服務  
Database、Config Service 或 Setting API 等…  
我在這裡先簡化成 `IStoreSettingService` 取值就好。

```csharp
-           //// TODO login id 抽參數
-           httpClient.DefaultRequestHeaders.Add("login_id", "testId");

+           var loginId = this._storeSettingService.GetValue(storeId,"pickup.service","loginId");
+           httpClient.DefaultRequestHeaders.Add("login_id", loginId);
```

同時測試代碼也要修改，  
注意這裡的 testId 其實是 Pickup Service 提供給我們的測試 Id  
在 Production 你需要整合進你的 Database、Config Service 或 Setting API 裡  
在整合測試可以直接 mock 它


```csharp
            _storeSettingService.GetValue(_testStoreId, "pickup.service", "loginId").Returns("testId");
```

Auth 也是相同的處理

```csharp
-           //// TODO authorization 抽參數
-           httpClient.DefaultRequestHeaders.Add("authorization", "testAuth");
+           var auth = this._storeSettingService.GetValue(storeId,"pickup.service","auth");
+           httpClient.DefaultRequestHeaders.Add("authorization", auth);
```

Testing Mock 

```
            _storeSettingService.GetValue(_testStoreId, "pickup.service", "auth").Returns("testAuth");
```

## 心得小結

- TDD 不一定要用單元測試
- 從 T(Todo) Driven Development 到 T(Test) Driven Development
- 整合測試有異常怎麼辦 ? 加一個測試案例。

(fin)

