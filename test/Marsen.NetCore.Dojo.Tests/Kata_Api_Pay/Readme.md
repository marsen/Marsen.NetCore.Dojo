# 
## 需求說明 

金流系統透過打 API 與第三方介接來進行付款，  
為了追蹤金流，在打 API 的過程中，業務單位要求要帶著 RequestId 。  
再進行付款。
而 RequestId 由另一個專門負責提供 RequestId 的 API 來提供。

整體流程如下:
1. 打 API 取得 RequestId

```bash
GET {{url}}/api/{{version}}/requestId
```

2. 組合付款資料與 RequestId
3. 打 API 完成付款

```bash
POST {{url}}/api/{{version}}/pay/CreditCard/{{transationId}}
```

## 第一個 Case，Pay 的時候應該呼叫 GET reguestId 1次

問題，我需要驗証 HttpClient 呼叫的 `url`與`次數`。

一開始會寫成這樣，


```csharp
 [Fact]
 public void pay_should_Get_requestId()
 {     
     var target = new PaymentService();
     target.Pay();
     httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
 }
```

我本來就預計使用 HttpClient 來呼叫 API,  
但是直接使用 HttpClient 我覺得會直接耦合，  
所以我建立一個介面來包裝它。

```csharp
 public interface IHttpClient
 {
     
 }
```

接著馬上建立類別 `HttpClientProxy` 實作 `IHttpClient`,   
這個時候我會知道我會使用 GetAsync 的方法， 
所以我會讓 `IHttpClient` 長出這個同名方法，
實作很單純，就是呼叫  HttpClient().GetAsync 方法。
```text
幾個想法，
這樣算是 Proxy Pattern 嗎 ? 我覺得算是:P
另一點，這個階段我會擔心 HttpClient 的問題,
不處理是對的嗎 ?
如果不刻意處理的話 HttpClientProxy 好像會長不出來 
```

```csharp
 public interface IHttpClient
 {
     Task<HttpResponseMessage> GetAsync(string requestUri);
 }
 public class HttpClientProxy : IHttpClient
 {
     public Task<HttpResponseMessage> GetAsync(string requestUri)
     {
         return new HttpClient().GetAsync(requestUri);
     }
 }
```

完成這階段的修改後，我才可以透過 Framework 來 Mock IHttpClient，  
寫好的測試如下，順利拿到第一個紅燈:


```csharp
 [Fact]
 public void pay_should_Get_requestId()
 {
     IHttpClient httpClient = Substitute.For<IHttpClient>();
     var target = new PaymentService(httpClient);
     target.Pay();
     httpClient.Received().GetAsync("https://testing.url/api/v1/requestId");
 }
```

馬上修改 Production Code ，拿到綠燈。

```csharp
public class PaymentService
{
    private readonly IHttpClient _httpClient;
    public PaymentService(IHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void Pay()
    {
        _httpClient.GetAsync("https://testing.url/api/v1/requestId");
    }
}
```

## 第二個 Case，Pay 的時候應該呼叫 POST Pay CreditCard 1 次

測試案例:

```csharp
[Fact]
public void pay_should_Post_Pay_CreditCard()
{
    IHttpClient httpClient = Substitute.For<IHttpClient>();
    var target = new PaymentService(httpClient);
    target.Pay();
    this._httpClient.Received().PostAsync("https://testing.url/api/v1/pay/CreditCard", Arg.Any<HttpContent>());
}
```

修改 Production Code

```csharp
public void Pay()
{
    var readAsStringAsync = this._httpClient.GetAsync("https://testing.url/api/v1/requestId");
                
    this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", null);
}
```

重構測試

```csharp
[Fact]
public void pay_should_Get_requestId()
{
    WhenPay();
    ShouldGetRequestId();    
}

[Fact]
public void pay_should_Post_Pay_CreditCard()
{
    WhenPay();
    ShouldPayByCreditCard();
}

private void WhenPay()
{
    var target = new PaymentService(_httpClient);
    target.Pay();
}

private void ShouldGetRequestId()
{
    this._httpClient.Received(1).GetAsync($"{_testingApiUrl}requestId");
}

private void ShouldPayByCreditCard()
{
    this._httpClient.Received(1).PostAsync($"{_testingApiUrl}pay/CreditCard",
        Arg.Any<HttpContent>()));
}
```

## 第三個 Case，Pay 的時候應該先呼叫 Get RequestId 再 POST Pay CreditCard

```
[Fact]
public void pay_should_Get_RequestId_Before_Post_Pay_CreditCard()
{
    WhenPay();
    Received.InOrder(() =>
    {
        ShouldGetRequestId();
        ShouldPayByCreditCard();
    });
}
```

想法，有了第三個案例，我還需要前面兩個案例嗎 ?

下一步，調整 ShouldPayByCreditCard 的 Assert 邏輯，
原因是實務上我必須將 RequestId 帶入 Post Pay 時的 HttpContent 裡面。

```csharp
private void ShouldPayByCreditCard()
{
    this._httpClient.Received(1).PostAsync($"{_testingApiUrl}pay/CreditCard",
    Arg.Is<HttpContent>(x => x.ReadAsStringAsync().Result.Contains(_testRequestId)));
}
```

Prodouction Code 因而長出 `PayEntity`

```csharp
public void Pay()
{
    var requestId = this._httpClient.GetAsync("https://testing.url/api/v1/requestId").Result.Content
        .ReadAsStringAsync().Result;
    HttpContent content = new StringContent(
    JsonSerializer.Serialize(
        new PayEntity
        {
            RequestId = requestId
        }));

    this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", content);
}

public class PayEntity
{
    public string RequestId { get; set; }
}
```

## Case4 組合資料邏輯

### 4.1 組合 PayEntity 的邏輯

這次我假設外部的元件已組合好 `PayEntity` 傳入 PaymentService.Pay 方法，  
唯一的組合邏輯就只剩 RequestId。  
至於外部的 PayEntity 組合邏輯如何用 TDD 長出 Production Code 可以參考[這篇](https://blog.marsen.me/2020/01/17/2020/tdd_with_parse_json/)。


```csharp
private void WhenPay()
{
    var target = new PaymentService(_httpClient);
    target.Pay(new PayEntity());
}

```
```csharp
public void Pay(PayEntity payEntity)
{
     var requestId = this._httpClient.GetAsync("https://testing.url/api/v1/requestId").Result.Content
         .ReadAsStringAsync().Result;
     HttpContent content = new StringContent(
         JsonSerializer.Serialize(
             payEntity.RequestId = requestId));
      this._httpClient.PostAsync("https://testing.url/api/v1/pay/CreditCard", content);
}
```

剩下只有一個，url 應該透過 config 注入

## 參考

- <https://chrissainty.com/unit-testing-with-httpclient/>
- <https://dotblogs.com.tw/jakeuj/2019/01/25/httpclient>
- <https://blog.darkthread.net/blog/httpclient-sigleton/>

(fin)
