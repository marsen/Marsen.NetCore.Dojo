
## 非同步的單元測試

參考 [Microsoft](https://docs.microsoft.com/en-us/archive/msdn-magazine/2014/november/async-programming-unit-testing-asynchronous-code) 文章，並使用 Xunit 進行非同步的單元測試。  
我寫了一個簡單的計算器程式來作範例。  
一般的單元測試需要加上 `async Task` 與 `await` 的關鍵字。  
如果是 Exception 的單元測試，記得使用 `Func<Task>` 變數來呼叫方法。  



## 參考

- [Async Programming : Unit Testing Asynchronous Code](https://docs.microsoft.com/en-us/archive/msdn-magazine/2014/november/async-programming-unit-testing-asynchronous-code)