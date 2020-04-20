# Working Effectively with Legacy Code 讀書會

這是 «Working Effectively with Legacy Code» 讀書會的練習題目，  
題目[來源](https://github.com/sandromancuso/trip-service-kata)。


## 分析

受測對像 : TripService 受測方法 : GetTripsByUser。
傳入的資料 : User (用戶資料)
回傳的資料 : Trip 的清單(旅行記錄)
例外 : 使用者未登入
分析後分為 3 個情境。

1. 傳入的 User 資料與目前登入 User 相符(在 friend 清單之中)，回傳 User 的 Trip 清單
2. 傳入的 User 資料與目前登入 User 不相符(不在 friend 清單之中)，回傳空的 Trip 清單
3. 目前未登入，拋出例外。

如果是 TDD 的流程，我或許會依 1 2 3 的順序寫測試。
不過這裡是模擬遺留代碼的重構(只使用 IDE)過程，所以我先從拋出例外開始

## 第一個測試，拋出例外

紅燈，開始重構。
修改 Production Code 只能使用 IDE 自動建 CODE 是這個挑戰的限制。

1. Extract Method `UserSession.GetInstance().GetLoggedUser();` 成為 private 方法 `GetLoggedUser`
2. 將 `GetLoggedUser` 方法改為 protected (Make method protected) 
3. 將 `GetLoggedUser` 方法改為 virtual (To Virtual) 
4. 修改測試，建立 Mock 類別, overide `GetLoggedUser` 方法
5.  
