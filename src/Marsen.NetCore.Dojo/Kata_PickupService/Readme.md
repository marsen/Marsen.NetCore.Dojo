# 
## 前情提要

作完金流作物流，這次在開發的過程中首次全程用 TDD 進行， 
雖然因為某些因素測試沒有進版控，但是稍微記錄一下心路歷程。

## 需求說明 

出貨流程為:
1. 訂單成立
2. 透過物流服務配號
3. 出貨
4. 透過物流服務查詢物流狀態
5. 狀態正確，通知消費者取貨，不正確通知商家人工處理。

這次 TDD 進行的部份為流程上的第 4 步，
再看看怎麼進行 ? 

整體流程如下

## 流程 

Step0 . 這次不是從無到有，而是在遺留代碼之中建立測試，
所以我會準備一些「遺留代碼」來呈現我面臨的狀況。

Step1 . 這次 TDD 先不是 Test 而 TODO，
直接對 Production Code 寫下 Todo List, 
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

我目前對測試案例有任何的想法(這是個壞味道)， 
但是我打算直接呼叫我的 Prodction Code 

```
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
但是我得到一個小工具可以隨時呼叫我的 Prodcution Code



## 心得小結

- TDD 不一定要用單元測試
- 從 T(Todo) Driven Development 到 T(Test) Driven Development
- 整合測試有異常怎麼辦 ? 加一個測試案例。

(fin)
