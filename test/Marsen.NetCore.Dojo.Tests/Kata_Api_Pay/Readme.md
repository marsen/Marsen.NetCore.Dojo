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

## 參考

- <https://chrissainty.com/unit-testing-with-httpclient/>
- <https://dotblogs.com.tw/jakeuj/2019/01/25/httpclient>
- <https://blog.darkthread.net/blog/httpclient-sigleton/>

(fin)
