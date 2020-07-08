

## Test Case

| Joey     | Tom | Expceted |
| -------- | -------- | -------- |
| 0     | 0     | Love All     |
| 1     | 0     | Fifteen Love     |
| 2     | 0     | Thirty Love     |
| 3     | 0     | Forty Love     |
| 0     | 1     | Love Fifteen    |
| 0     | 2     | Love Thirty    |
| 0     | 3     | Love Forty    |
| 1     | 1     | Fifteen All     |
| 2     | 2     | Thirty All     |
| 3     | 3     | Deuce        |
| 4     | 4     | Deuce        |
| 4     | 3     | Joey Adv     |
| 5     | 3     | Joey Win     |
| 3     | 4     | Tom Adv     |
| 3     | 5     | Tom Win     |

## State Pattern

因為 91 大上課的一句話，「有人使用狀態機」完成這個 Kata ，  
所以我也想來試一下。  
這僅僅是設計理念上的不同，所以我依然要用 TDD 來趨動。 
步驟如下：
- 了解 State Pattern 
- 分析 Tennis Kata 的 State
- 設計 Test Cases
- TDD

### What State Pattern ?
   
State is a behavioral design pattern that lets an object alter its behavior when its internal state changes. 
It appears as if the object changed its class.
--- [State](https://refactoring.guru/design-patterns/state)

#### State Patten 的應用場景與思路:

當你的狀態會影響你的行為，  
而且你的狀態多到你的 if else 與 switch case 大量的散布在不同的行為判斷之中。

舉例說明 : 

想像你正在操作 ATM (自動櫃員機)，
有以下幾種狀態:

- 待機
- 卡片讀取
- 交易處理
- 等待輸入
- more…

而 ATM 介面提供幾種行為(按鍵)

- 數字 0~9
- 取消 (Cancel)
- 更正 (Change)
- 輸入 (Enter)

我們代碼可能會寫成這樣，以「更正」為例

```c#
public void Change(string state)
{
    switch(state)
    {
        case "Waiting":
            /// DO SOMETHING
        case "Reading":
            /// DO SOMETHING
        case "InTransacion":
            /// DO SOMETHING
        case "Inputting":
        default: 
            /// DO SOMETHING
            break;    
    }
}
```

**這裡發揮一下想像力**，每一個行為(按鍵)所對應的方法裡面，  
都是這堆狀態判斷的邏輯分支…唔，是不是有點討厭呢?  

另外一個提示是，這些行為都會與狀態耦合在一起，是一個顯而易見的壞味道。  

 
這樣說來 State Patten 是適合透過重構邁進的解決方案。  
不過這一次我們先考慮 TDD 由無到有吧。  
我的思路首先會替行為與狀態進行分類，分類的過程理應可以看到狀態與行為的耦合。  
這個時候建立一個介面或抽像類別(哪一個比較好 ? 歡迎說說你的想法喔。)  
讓介面定義好行為(方法)了，不同的狀態分別建立一個類別去實作它。

接下來狀態應該透過介面相依與某個實體之上，  
為此，我們應該替這個實體建立類別，而且真正的使用者(Client 或 Test)應該透過這個類別呼叫。  
這裡我們稱作 Context

![](https://imgur.com/vHLzkjB.png)

下面我們直接用 Tennis Kata 作示範。

### 分析 Tennis Kata 

#### 行為

- First Player 得分
- Second Player 得分

#### 狀態

- 同分
    - 小於 3 分 ， All
        - Love All
        - Fifteen All
        - Thirty All
    - 大於等於 3 分 ， Deuce        
- 不同分
    - 雙方都小於等於 3 分， Normal
        - 0-15
        - 0-30
        - 0-40 
        - 15-0
        - 15-30
        - 15-40
        - 30-0
        - 30-15
        - 30-40
        - 40-0
        - 40-15
        - 40-30
    - 有一方大於 3 分
        - 分差等於 1 分 領先者的 Adv
            - First Player Adv
            - Second Player Adv
        - 分差等於 2 分 領先者 Win, 遊戲結束。
            - First Player Win
            - Second Player Win
            
#### 思考           

應該怎麼選擇狀態呢 ? 如 Deuce 或 Adv , 還是選擇 15-40 這樣明確的記分作為狀態 ? 
直覺上應該選用前者，以此為基點將狀態設計如下
- All : 小於 3 分的平手狀態
- Deuce : 大於等於 3 分的平手狀態
- Normal : 雙方都小於 3 分，且不是 All 的狀態
- Advantage : 領先方得分大於 3 分，且只領先 1 分的狀態
- Win : 領先方得分大於 3 分，且領先 2 分的狀態

![](https://imgur.com/jDUiYE8.jpg)
<hidden value='https://i.imgur.com/YNx92Hp.jpg' />

隨手畫了上圖的狀態機，  
想一下要怎產生測試案例。

#### Test Cases

設計模式提供我們指引與目標，  
TDD 則透過案例將代碼逐一產生出來。
State Pattern 將會是我們的目標，
Tennis Game 進行中應該會有一個實體記錄著狀態，並且會回報我們現在的賽況。

##### Case Fifteen_Love
產生 GameContext 與方法介面。
由 Domain Know How 我可以了解
GameContext 應該具備 SeverScore(發球方得分)/ReceiverScore(接發方得分) 兩個方法(行為)來改變 GameContext 的狀態。  
第一個案例，我想產生 SeverScore 的方法介面。

第一個案例通過後，我打算先重構並朝 State Pattern 邁進。
首先 GameContext 應該存在某一種 State, 以上圖的分析，
應該是屬於 Normal , 所以我會建立 Normal Class 並產生方法回傳比分結果。

##### Case Love_Fifteen 
- 產生 ReceiverScore 的方法簽章
- 通過測試
- 重構

##### Case Fifteen_All
- 產生第二種 State All
- Context 要先改變 State 
- 紅燈 

這個時候我發現當狀態在 Normal 時得分的話 需要改變狀態為 All
因為得分有兩種情境 ReceiverScore 或 ServerScore 所以我會重新命名測試案例
Fifteen_All_After_ReceiverScored
- 紅燈
NormalState 看不到 GameContext 必須將 GameContext 作為 State 的欄位。
且 GameContext 應該提供 ChangeState 方法來改變本身的 State， 
最後 NormalState 才有可能呼叫本身 GameContext 來進行欄位的切換。

先用最小的代價讓測試通過 (AllState 繼承 NormalState)
有改 A 壞 B 的問題要先修正
加上 score 當同分時才需要切換 state

##### Case Fifteen_All_After_ServerScored
