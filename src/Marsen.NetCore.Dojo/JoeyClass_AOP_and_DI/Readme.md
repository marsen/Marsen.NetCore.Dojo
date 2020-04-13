## 

這個是為了複習 2020 年初 91 大課程所作的筆記。

因為中間經歷工作更換，農曆年與中國武漢肺炎(COVID-19)疫情所影響。
所以未能即時整理當初上課筆記。


## 起程 : 從一份小型遺留代碼開始 
我們的 AuthenticationService 類別有一個 Verify 方法，  
它要作的事情很簡單，就是驗証登入的身份。

1. 驗証使用者登入的帳號與密碼是否正確 ?
2. 驗証使用者輸入的 OTP 是否正確 ?

[![](https://i.imgur.com/dsQtRIK.jpg)](https://github.com/marsen/Marsen.NetCore.Dojo/commit/640e640cc960fd82ad58fd3ad2f9657770b2f8e1)  

## 增胖 : 功能追加

1. 驗證失敗，用 Slack 通知
2. 驗證失敗超過 3 次，鎖帳號
   - 記錄驗證失敗次數
   - 驗證成功 Reset 失敗次數 
3. 確認帳號沒有被鎖才進行驗證

一般來說，實務上我們會看到這樣的代碼。
有點胖(職責不分)，但是段落清楚，也有寫註解。
雖然東西有點多，但是認真看仍然可以了解其意圖。

## 重構 : Extract Method

[-](https://github.com/marsen/Marsen.NetCore.Dojo/commit/fce3a350b71c48ac3a70c44b7d67ffa82e4124d2)

重構的一個大原則，如果你可以分段落寫註解，  
那麼你就一定可以抽成對應的方法。  

如果你可以抽出方法，那麼我們就可以進行下一步，分類。  


## 分類 

分類的原則，依職責分類

| Method | Response | Class |
| -------- | -------- | -------- |
| PasswordFromDb    | 取 DB 資料     | DAO     |
| IsLocked    | 檢查帳號是否鎖定     | Account     |
| HashedPassword    | 加密密碼    | Hash     |
| CurrentOtp    | 取 OTP     | OTP     |
| ResetFailedCounter    | 重設失敗次數     | Account     |
| AddFailedCounter    | 增加失敗次數     | Account     |
| FailedCount    | 取得失敗次數     | Account     |
| Notification    | 通知     | Account     |
| LogFailedCount   | 記錄失敗次數     | ???     |

這裡我寫得很簡略，但是這裡大家可以想一想，  
LogFailedCount 應該屬於什麼 Class 呢 ?
隨著過程，後面將會解答。  
但我認為這個思考過程是重要的，可以思考一下再往下一步進行。

產生類別(Extract Class)的小技巧，  
Resharpe 可以在編輯畫面上按下 `Alt+Enter` 再輸入 `EC`  
就可以呼叫 Extract Class 的重構指令。

順代一提，在 Extract Method 的步驟中，  
我們抽出來的方法都是 private static ，  
而在 Extract Class 的步驟前，  
就是要將這些方法改 public non-static 的方法。
依照重構順序的不同，你可能會發現 `LogFailedCount`對於 FailedCount 存取權限不足。
對我來說這是個訊號，明示了 Log 的行為與 FailedCount 的相依，  
應該提早拆開成為兩個不同的步驟。 1. 取失敗次數 2.記錄


