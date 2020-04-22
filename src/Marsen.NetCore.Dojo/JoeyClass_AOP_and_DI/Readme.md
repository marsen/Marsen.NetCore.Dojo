# 記錄

這個是為了複習 2020 年初 91 大課程所作的筆記。

因為中間經歷工作更換，農曆年與中國武漢肺炎(COVID-19)疫情所影響。
所以未能即時整理當初上課筆記。

## 起程 : 從一份小型遺留代碼開始

我們的 AuthenticationService 類別有一個 Verify 方法，  
它要作的事情很簡單，就是驗証登入的身份。

1. 驗証使用者登入的帳號與密碼是否正確 ?
2. 驗証使用者輸入的 OTP 是否正確 ?

[![auth](https://i.imgur.com/dsQtRIK.jpg)](https://github.com/marsen/Marsen.NetCore.Dojo/commit/640e640cc960fd82ad58fd3ad2f9657770b2f8e1)  

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

## 插曲 : 記錄與通知

這裡有一個小插曲，
因為太不合理，所以我提早優化。
記錄失敗次數與通知失敗，其實都是一個組合性的功能。
應該以「Something+記錄」或是「Something+通知」的角度來看這件事。

從小胖到現在已經作了相當大程度的重構了，雖然都是依賴 IDE 的功在操作，  
但並不表示不會出錯，很多 RD 會恐懼失敗(或是單純懶 ? )而不願不敢重構，
實務上我會結合一些手段來減少風險。

1. 使用工具(IDE)重構
2. 撰寫基本的整合測試
3. Pair Programming
4. 請同事 Code Review
5. 爭取 QA 資源協助測試(不論自動或是手動)  

不過我想特別說的一點是，我不會特別要求要「額外」的時間作「重構」，  
我一定會包在整個 Task 裡面，自我評估能帶來的效益與付出的代價是否划算。  
前兩項我可以自已控制，後兩項是包在整個開發流程之中，  
小量的改動比較容易讓 Code Review 通過，
或是找到關鍵的人快速的跟他 Pair 一下，讓代碼儘速可以測試。  
有自動化是最理想的，但大多情境我想是沒有吧:)  
如果會影響測試範圍就必須跟 QA 協調協助測試。  

如果胖子真的太胖的話，只能作抽脂手術，讓胖子先瘦一點再說。  
另外很重要的一點是，不要只有一個人作，要找到同伴;  
減緩輸入「脂肪」的速度，增加「代謝」的速率。  
讓重構成為團隊的習慣與呼吸。

## 制定合約 : 介面化

這裡的案例多會是使用 Interface 實務上也會使用 Abstract Class  
使用的時機，有機會再寫一篇吧。

首先必須建立一個空的建構子，
接下來將相依實體的類別建立成欄位，
將我們相依的實體在建構子中初始化。
依據類別建立出介面，將主要代碼的欄位改用介面介接，  
再建一個傳入介面的建構子，我們準備用來測試。

### 小技巧 : Generative Completion 
如果使用 JetBrain 系列的產品，例如 : ReSharpe、Rider,  
可以使用 `ctorf` 這個技巧，這是 JetBrain 的 Generative Completion 功能。
首先欄位不可以初始化，只有宣告就可以使用這個功能。

此外在介面化的過程之中，也不要忘記正確命名的重要性，  
適時的 rename 可以幫助程式理解。

## 單元測試

介面化後可以透過 mock framework 來隔離相依物件，
接下來就可以進行單元測試了
重點是如何決定第一個案例 ?
我的評估重點會在使用者最常發生的情境，

1. 正常登入
2. OTP 錯誤
3. 密碼錯誤
4. 錯誤達上限，帳戶被鎖定
5. 錯誤發通知
6. 錯誤記 log

## 重構 with Decorator Pattern

這裡我覺得是這堂課第一個亮點，
特別記錄一下步驟，

### Step 1. 對關鍵方法抽介面

本來我想說,[定義裝飾者行為, 撰寫裝飾者類別」但是實在太饒舌了。
想像一下你將出席一場活動，你會穿什麼衣服出門呢 ?
你的身體就是那個主體，而所有的「衣服」只是裝飾品而已。
而這個步驟就是找出代碼中「穿著衣服的身體」，然後一層一層的把衣服脫掉而已。  

觀察一下我們的方法，最主要的邏輯是密碼與OTP的比較，
帳號是否鎖定，重設失敗次數，記錄失敗次數，發通知與記錄，都只是「衣服」而已。

### Step 2. 對裝飾品抽成私有方法

我抽的順序為 Notification、Logger、AccountService

### Step 3. 將私有方法抽到 Decorator 類別

如果沒有就創建一個吧，這個 Decorator 類別有一些地方需要調整，  
首先是要繼承「身體」的介面，我會想像成「衣服」上為脖子、手、身體所留的洞。
再來是建構子的部份要留有參數讓「實作身體介面」的實體進來，  

```
想像一下人穿衣服，但是你也可以讓衣服穿著衣服，這樣的例子在服飾店很多;
店員會設計自已的穿搭在假人或衣架身上，T 恤加個背心再加個外套之類的。
```

再把需要的其它服務透過建構子注入，最後實作「介面」就完成了一個 Decorator 啦。

### 小技巧 Move Instance Method

如果使用 JetBrain 系列的產品，例如 : ReSharpe、Rider,  
可以使用 `Refactor > Move Instance Method` 這個技巧，  
將一個方法移動到別的類別。
但是要透過 IDE 的命令移動有一個大前提，就是需要在目前所在的類別位置，
可以存取到想要移動到的目標類別，所以要以方法簽章或是目前類別的欄位形式宣告變數，  
再對方法重構才能完成。

```
The list of potential target types includes types of the method  
parameters and types of fields in the current type.
```

手法我覺得點繞路，還不如剪下貼上的手段，  
當然剪下貼上也會有參考相依的問題。
但是我們在使用工具重構的時候，有兩個大目的，  
一個是讓步驟 SOP 化避免犯錯、提昇信心指數，  
一個加快開發的速度與效率。

就這個案例而言，我覺得剪下貼上的步驟反而單純而直覺。
所以我反而不會透過工具的命令來執行這次的重構。

## 點評 Decorator Pattern

優點，讓原始的邏輯變得單純，而不需要擔心在什麼時間點插入額外的邏輯。
甚至可以將代碼進一步針對可讀性重構，變得更簡潔與洗練。
缺點，呼叫端的組合順序將會大大影響你的代碼運行結果。
也就是說目前的單元測試都變成整合測試了。

改用 Autofac 注入，注入的順序就會決定代碼運行的結果，
更多參考　[RegisterDecorator](https://autofaccn.readthedocs.io/en/latest/advanced/interceptors.html#create-interceptors)

我們可以透過工廠方法作取得整合好的模組，但是在維運是有點困難的，  
不明白這裡套用了 Decorator Pattern 的維運人員在第一視角將看不出來，  
log、notify、甚至 islocked 從何而來 ?  
如果要調整順序要怎麼調整 ?  


## 重構 with Interceptor

類似於 Decorator 的概念，Interceptor 並不把整個類或方法包起來。
拿 Logger 記錄一下實作步驟

1. 引入 Castle.DynamicProxy 組件
2. 建立 LoggerInterceptor 實作 IInterceptor, 內容我們後面再填上
3. 建立 LogAttribute 繼承 Attribute
4. 透過以下語法檢查是否有掛載 `[Log]` Attribute
    (Attribute.GetCustomAttribute(invocation.Method, typeof(LogAttribute)) is LogAttribute logAttribute == false)
    另外 logAttribute 是個 C# 7.0 之後的語法糖，請[參考](https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/is#constant-pattern)
5. Nuget 安裝 Autofac.Extras.DynamicProxy 透過 Autofac 註冊欄截器
6. 將 `[Log]` Attribute 掛載在介面上


### 點評 Interceptor



## 後記


1. 什麼是 AOP ，什麼時候要導入 ? 
2. AOP的優缺點
3. Interceptor 跟 Decorator 的差別在哪裡
4. Autofac 兩種欄截器的差別
   - EnableInterfaceInterceptors
   - EnableClassInterceptors 
5. 

(fin)

