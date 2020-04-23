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

## 單元測試

### 第一個測試，拋出例外

紅燈，開始重構。
修改 Production Code 只能使用 IDE 自動建 CODE 是這個挑戰的限制。

1. Extract Method `UserSession.GetInstance().GetLoggedUser();` 成為 private 方法 `GetLoggedUser`
2. 將 `GetLoggedUser` 方法改為 protected (Make method protected) 
3. 將 `GetLoggedUser` 方法改為 virtual (To Virtual) 
4. 修改測試，建立 Mock 類別 StubTripService
5. StubTripService 提供 `SetLoggedUser` 方法
6. 實作 `SetLoggedUser`
7. overide `GetLoggedUser` 方法
8. 跑測試
 

### 第二個測試，User Friend 清單為空，回傳空的 Trip 清單

1. mock 階段應注入有實體的 new User()
2. 跑測試

### 第三個測試，User Friend 清單不包含 Logged User，回傳空的 Trip 清單

1. 建立 StubUser
2. mock `GetFriends` 方法
3. 將 `GetStubUser` 方法改為 virtual (To Virtual)
4. StubUser

### 第四個測試，User Friend 清單包含 Logged User，回傳空的 Trip 清單

1. Extract Mathod `TripDao.FindTripsByUser(user);` 為 `GetTripsList`
2. overide `GetTripsList` 方法
3. 注入 TripList

## 重構

上面的測試，我使用了 Stub 的技法墊開了原始類別，達到最小化的改動，
接下來就可以重構了。

1. [將 foreach 改為 LINQ.Expression](https://github.com/marsen/Marsen.NetCore.Dojo/commit/f00119155ad418e43428995cd9a27891c85a404c)
2. [消除暫存變數 loggedUser](https://github.com/marsen/Marsen.NetCore.Dojo/commit/3d3ca3e437e988f6c72266a020863697b70337e5)
3. [移除多餘的條件邏輯](https://github.com/marsen/Marsen.NetCore.Dojo/commit/b20d4cc107fb4cfebaaa6b43cf1b5332667982f8)
4. [消除無用代碼](https://github.com/marsen/Marsen.NetCore.Dojo/commit/97e77cdce45c0dc897101c09d2be5c1af46c3c60)
5. [消除回傳值的暫存變數](https://github.com/marsen/Marsen.NetCore.Dojo/commit/374e4210aa6b6b9ea3bc231a8c415cd14f2905d9) 
6. [簡化 if else](https://github.com/marsen/Marsen.NetCore.Dojo/commit/18aee0c55a49e828a2155af0ce1b6d4add13d60e)
7. [Extract Method GetUserTripsList 與 IsUserFriendsContainsLoggedUser](https://github.com/marsen/Marsen.NetCore.Dojo/commit/86c15f69c45e1a261fe45e85b2f7a7182b4dd8aa)
8. ~~正向表示 if 判斷式~~
9. [Extract Method IsLogin](https://github.com/marsen/Marsen.NetCore.Dojo/commit/05815341b7d73b313529e70de991234b3bfc6c49)
10. [消除 if](https://github.com/marsen/Marsen.NetCore.Dojo/commit/a2db909ff80ad33bdf1f5942e1d1ef25b9312255)




(fin)

