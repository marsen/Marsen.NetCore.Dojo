

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
![](https://refactoring.guru/images/patterns/diagrams/state/structure-en.png)

下面我們直接用 Tennis Kata 作示範。

### 分析 Tennis Kata 

#### 行為(Method)
- First Player 得分
- Second Player 得分

#### 狀態

![](https://imgur.com/FPw0joi.jpg)

#### 程式規劃

##### Tennis Game Context

- 應該具備 State 屬性
- 建構子應傳傳初始狀態，邏輯上為 LoveAll 
- 應該具備與 State 相同的公開方法

##### State 介面與類別

- 應該考慮介面或抽象類別
- 應該先產生類別再重構出介面或抽像類別

#### 測試案例

Love All:產生 Score 方法與介面


(fin)
