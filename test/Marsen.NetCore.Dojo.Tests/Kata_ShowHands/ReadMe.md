#

## ShowHands

### 需求

兩位玩家，可以各自**設定名稱**，各有 5 張牌，  
A 表示 1，J 表示 11，Q 表示 12 ，K 表示 13 ，其它以數字顯示，  
花色有黑桃 (♠Spade) 以 S 表示、紅心 (♥Heart) 以 H 表示，  
梅花 (♣Club) 以 C 表示，方塊(♦Diamond) 以 D 表示。  
請參考規則條目，開發一個軟體，輸入兩位玩家的牌組，並判斷輸贏，  

純以牌型決勝負
Ex:
Tom : S3,SK,S8,SJ,S10
Lee : S8,C8,D8,SK,HK

Lee Win, Because Full house

牌型相同以點數決勝負
Ex:
Tom : S3,SK,S8,SJ,S10
Lee : C8,C3,CJ,CA,CK

Lee Win, Because Flush, Key Card A

牌型相同以點數相同
Ex:
Tom : S3,SK,S8,SJ,S10
Lee : C8,C3,CJ,S10,CK

Push, Because Flush, Key Card K

### 特殊需求

- 先不比花色
- A 代表 1 也代表 14
- 順子的大小 10 J Q K A　> A 2 3 4 5 > 9 10 J Q K >...>2 3 4 5 6
- 10 是所有牌中以 2 個字符表示的數字
- 兩個人各用一副牌，所以牌可以重複

### 分析

- 輸入 輸出
- 設定玩家名
- 字串轉換成手牌
- 判斷牌型
  - 同花規則
  - 順子規則
  - 分群規則
    - 四條
    - 葫蘆
    - 三條
    - 兩對
    - 一對
- 比較牌型
- 比較點數

#### ShowHand 類別

- 輸入(input)
- 設定玩家名(Player Name)
- Deul方法，輸出勝負結果

#### HandCard 類別

- 字串轉成手牌
  - 牌型 (Deck)
  - 牌 (Card)
    - 點數處理(Rank)
    - 花色處理(Suit)

#### Deck 類別

- 判斷牌型

#### Comparer 類別

- 比較牌型
- 比較點數(Key Card)
- ~~比較花色~~

### 心法

1. 先分析再開發
2. 使用 TDD 用測試逼出情境
3. 完成第一個測試後，就要開始重構到完成 End To End 的測試，
過程中可能會產生其它的類別與測試案例。
4. 完成 End To End 就要消除所有的 Hard Code

### 測試案例

#### case 1. 四條 > 三條 

(開發目的:逼出輸入、輸出、設定玩家名稱、字串轉成手牌、判斷牌型-分群規則-四對、比較牌型)
Tom : S4,C4,D4,H4,S7
Lee : S4,C4,D4,S7,H8
Tom Win, Because Four of a Kind

#### case 2. 二對 > 三條 

(開發目的:逼出判斷玩家勝負、~~判斷牌型-分群規則-二對與三條~~、比較牌型)
Tom : S4,C4,D5,H5,S7
Lee : S4,C4,D4,S7,H8
Lee Win, Because Three of a Kind

#### case 3. 三條 vs 三條 

(開發目的:逼出同牌型時，比較 Key Card)
Tom : S4,C4,D5,H5,S5
Lee : S4,C4,D6,S6,H6
Lee Win, Because Three of a Kind, Key Card is 6

#### case 4. 三條 vs 三條 

(開發目的:逼出平手)
Tom : S4,C4,D5,H5,S5
Lee : S4,C4,D5,H5,S5
End in a tie


> 這個時間點我想重構了，if 的判斷式很噁心

```
  if (firstPlayerHandCard.Category - secondPlayerHandCard.Category > 0)
  {
      //// Do Something    
  }

  if (firstPlayerHandCard.Category - secondPlayerHandCard.Category == 0)
  {
      //// Do Something
      
  }

  if (firstPlayerHandCard.Category - secondPlayerHandCard.Category < 0)
  {
      //// Do Something
  }
```

> 第一階段的重構只消除了暫存變數，看起來好一些了，
> 但是 if 仍然在，這個時候我發現 Key Card 平手時的測試案例不太夠。

#### case 5. 二條 vs 二條 ，關鍵牌為 9 

(開發目的:逼出同牌型時，比較 Key Card)
Tom : S4,C4,D5,H5,C7
Lee : S4,C4,D5,S5,S9
Lee Win, Because Two Pair , Key Card 9

#### case 6. 二條 vs 二條

(開發目的:逼出同牌型時，比較 Key Card)
Tom : S4,C4,D5,H5,C7
Lee : S4,C4,D5,S5,S7
End in a tie

> 事實証明原本的測試就已經足夠了，但是逼出了 Two Pair 的 Lookup
> 測試案例多多益善，就無需刻意刪除了

~~ 下一階段我仍打算處理 if ，這裡有兩個區段 ~~
~~ 一個是牌型的 if 一個是 Key Card 的 if ~~

> 暫時無法處理 if ，看一下 HandCard 類別，
> 我想把 GetCatogory 改成 public 而不使用 field 取得 Category


#### case 7. 二條 vs 一條

(開發目的:逼出一條)
Tom : S4,C4,D5,H5,C7
Lee : S4,C4,D5,S6,S7
Tom Win, Becasue Two Pair

#### case 8. 一條 vs 雜牌

(開發目的:逼出高牌)
Tom : S2,C4,D5,H9,C7
Lee : S4,C4,D5,S6,S7
Lee Win, Becasue One Pair

#### case 9. 三條 vs 順子

(開發目的:逼出順子)
Tom : S2,C4,D9,H9,C9
Lee : S8,C4,D5,S6,S7
Lee Win, Becasue Straight

#### case 10. 順子 vs 同花

(開發目的:逼出同花、花色)
Tom : S8,C4,D5,S6,S7
Lee : S2,S4,S9,S6,S5
Lee Win, Becasue Flush

#### 考慮重構 HandCard 的 if
發現少了 HandCard 類別的測試，
思考我的工序哪裡錯了 ?

#### case 11 四條的測試

考慮是否有必要性 ?
決定暫時不補牌型的測試，現況的步驟並沒有逼出這些測試，故先略過

#### 重構的思維

我的目標是消除這些 if 。
因為 IsXXX 相關的方法都是相同傳入與回傳值, 

> 這裡有一個 pattern ，
> 如果有一群相同的方法簽章與回傳值 ，
> 我們可以透過一個 List 將這些規則 Rule 作分類(放到不同的類別)
> 並使用 Loop 處理不同的規則 ，這是我在 FizzBuzz 的 Kata 學到的技巧。
> 我先給它一個名字 `if rule to loop` 好了。

要進一步作這樣的重構之前
發現所有的方法都對 this._cardList 有相依。

```csharp
protected virtual bool IsFourOfAKind()
{
    return this._cardList....
}
```

所以我要透過參數傳遞消除這樣的相依。

**應該傳入 cardlist 回傳 Category**

完成重構之後,發現沒有同花順與葫蘆的 Rule
立馬加上測試

#### case 12 同花順的測試
#### case 13 葫蘆的測試

過程發現之前與三條相關的測試有問題。
所以補上所有牌型測試。

#### case 14 三條的測試
#### case 15 兩對的測試
#### case 16 一對的測試
#### case 17 同花的測試
#### case 18 順子的測試

看一下覆蓋率，有兩個地方未覆蓋到，
1. 平手比較 KeyCard 贏家為第一玩家的情境
2. 不是平手也沒有勝負的情境

明顯 2 不合理，進行重構。

#### case 19 同花順 vs 同花順

(開發目的:逼出 Ace ，同牌型時第一位玩家 Key Card 勝利, Tom 的 Ace 被視作 14，而 Lee 的 Ace 視作 1)
Tom : SA,SK,S10,SJ,SQ
Lee : SA,S2,D3,D4,D5
Tom Win, Becasue Straight Flush , Key Card K

試著讓測試變綠燈，首先遇到 Ace 被當作 1 或 14 的問題，
第一版的解法在 CardParser 作判斷，如果是 A 2 3 4 5 就視 A 作 1，
10 J Q K A 就視作 14 。不過在 Compare 的階段，兩張 A 會被視作不同的牌導致測試失敗。

調整思路，整副牌應該 2 最小 Ace 最大，所以 Ace 應該是 14 才對， 
反而應該在 Straight Flush 的規則中作變異，把 2,3,4,5,14 視作順子。

####  case 20 同花順 vs 同花順 Key Card K
####  case 21 同花順 vs 同花順 Key Card Q
####  case 22 同花順 vs 同花順 Key Card J

開發目的，逼出非數字的 Rank 判斷，出現大量 if 的 Pattern
我使用查表法(Dictionary Lookup)重構這一段邏輯。

接下來作了對檔案稍微分類了一下(依功能使用檔案路徑分類，並調整 namespace)
並且作了一些比較小的重構。

#### 改善建議
1. 使用 Enumerator 處理相同 category 的 keyCard 逐步比較
2. 使用 IComparer<HandCard> 減少 Duel() 的職責

#### 改善結果
1. 使用 Zip 這個擴充方法處理兩個集合
成功的讓 Deul 的方法可讀性提高了，不過 GetKeyCardCompareResult 本身不好理解，
Zip 的寫法我覺得很單純, 但是在 Tuple.Create 產生的 ItemN 我個人本身不太喜歡，覺得會降低可讀性，
但是暫時想不到更好的寫法，也可能單純只是我個人的感覺問題。

2. 使用 IComparer<HandCard> 減少 Duel() 的職責
    1. 建立一個 Compare 方法，將 Category 比較邏輯抽換到 Compare 方法之中
       思考: Compare 是實作 IComparer<T> 的方法，但是我會很自然的比較 Category 而非 HandCard，
       但是 ShowHand 實作 IComparer<Category> 很奇怪，直覺上這不是它的職責。
       於是我決定把 IComparer<Category> 的邏輯搬進 HandCard 
    2. 實作 HandCardComparer 這個時候 KeyCard 的比較邏輯還在留在 ShowHand 就很奇怪了，應該被搬進 HandCardComparer
       這時候 KeyCard 的比較就會發現與回傳值有耦合，應該把比較與回傳值(OutPut)作分離。
       回傳值進一步分析，會有 KeyCard 的值與贏家姓名兩個變數，同時又與比較邏輯相依。
       這個時候，我覺得 KeyCard 的值，應該給 Comparer 判斷，但贏家的值應該還是由主程式(ShowHand) 處理

整個作完覺得有點走火入魔 ?? 不太確定這樣的重構是否能增加可讀性或好維護。



#### 參考
- ([.NET]快快樂樂學LINQ系列－Zip() 簡介)[https://dotblogs.com.tw/hatelove/2014/06/06/linq-enumerable-zip-introduction]


### 變化

- 加入花色
- 加入鬼牌(可以當任意牌)

###

|牌型(別名)|英文名|說明|範例|
|---------|------|---|---|
|同花順|Straight Flush|五張同一花色且順連的牌。|10♠ J♠ Q♠ K♠ A♠|
|四條(鐵扇，鐵支)|Four of a Kind|有四張同一點數的牌。|4♠ 4♥ 4♣ 4♦ 9♥|
|葫蘆(夫佬)|Full house|三張同一點數的牌，加一對其他點數的牌。|8♠ 8♣ 8♦ K♠ K♥|
|同花(花)|Flush|五張同一花色的牌。|3♠ 4♠ 8♠ J♠ K♠|
|順子(蛇)|Straight|五張順連的牌。|A♣ 2♣ 3♥ 4♦ 5♠|
|三條|Three of a kind|有三張同一點數的牌。|7♠ 7♥ 7♦ 2♣ K♦|
|兩對(Two 啤，滔啤)|Two Pairs|有兩張相同點數的牌，加另外兩張相同點數的牌。|8♠ 8♦ A♥ A♣ Q♠|
|一對(啤)|One Pair|有兩張相同點數的牌。|9♠ 9♥ 4♣ J♠ A♥|
|散牌(高牌，烏龍)|High card|不能排成以上組合的牌，以點數決定大小。|3♠ 6♥ 9♦ K♠ A♣|

### 規則

先比牌型，再比點數，最後花色  
牌型 -> 點數 -> 花色  
牌型大小  
同花順> 四條> 葫蘆> 同花> 順子> 三條> 兩對> 一對> 散牌  

#### 點數

A> K> Q> J> 10> 9> 8> 7> 6> 5> 4> 3> 2  
但同花順和順子中A如果配上2345時當做1點，港澳地區則還是當做14點。  
四條、葫蘆、三條、兩對、一對先比同樣點數張數最多的牌，再比同樣點數張數少的牌。  
例如：葫蘆先比三條，再比對子；兩對先比點數較大的對子，再比點數較小的對子，最後才是比單張。  

(來源-WIKI)

#### 花色

正式：♠> ♥> ♣> ♦
台式：♠> ♥> ♦> ♣

一律比完所有點數才比花色，部分地區花色大小不同，或者是不比花色。  
四條、葫蘆、三條、兩對、一對先比同樣點數張數最多的牌。  
例如：當兩對點數完全一樣時比點數較大的對子花色；當一對點數完全一樣時比對子花色。  
牌的順序無關  
可以依照牌型、點數、花色而調整順序，因此就算順序亂七八糟也不影響牌的大小。  
牌面必定是五張。  
如果遊戲中出牌多過五張，只選其中五張作比較，餘下的牌不影響結果。  
順子比牌變種  
順子比法部分玩法(如德州撲克)當A和2345組成順子時當做1點，所以A2345是最小的順子；  
另有玩法依舊當14點，所以A2345為第二大的順子[1]。  
而大老二也有相同問題，非台灣華人區大老二順子比較方式大多數使用後者比較方法，  
所以A2345 > 23456 > 10JQKA > 910JQK > 8910JQ > 78910J > 678910 > 56789 > 45678 > 34567，  
沒有JQKA2、QKA23、KA234這三種順子；　
台灣則是非前者也非後者是特別比法，只比牌尾大小，2最大，5最小，  
JQKA2 > 10JQKA > 910JQK > 8910JQ > 78910J > 678910 > 56789 > 45678 > 34567 > 23456 > A2345，  
沒有QKA23、KA234這二種順子。  
同花比法因為部分玩法不比花色，當加入花色比法產生分歧，正式比法先比完所有點數才比花色；  
另有玩法是最大的牌一樣點數時比直接比花色，兩對、一對、散牌也如同同花的爭議。  

(來源-WIKI)

(fin) 
