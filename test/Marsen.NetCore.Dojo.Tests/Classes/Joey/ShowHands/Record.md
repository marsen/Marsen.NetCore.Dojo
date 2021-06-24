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

```csharp
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

~~下一階段我仍打算處理 if ，這裡有兩個區段~~  
~~一個是牌型的 if 一個是 Key Card 的 if~~

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
**思考我的工序哪裡錯了 ?**

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

#### case 20 同花順 vs 同花順 Key Card K

#### case 21 同花順 vs 同花順 Key Card Q

#### case 22 同花順 vs 同花順 Key Card J

開發目的，逼出非數字的 Rank 判斷，出現大量 if 的 Pattern 我使用查表法(Dictionary Lookup)重構這一段邏輯。

接下來作了對檔案稍微分類了一下(依功能使用檔案路徑分類，並調整 namespace)
並且作了一些比較小的重構。

#### 改善建議

1. 使用 Enumerator 處理相同 category 的 keyCard 逐步比較
2. 使用 IComparer\<HandCard\> 減少 Duel() 的職責

#### 改善結果

1. 使用 Zip 這個擴充方法處理兩個集合

   成功的讓 Deul 的方法可讀性提高了，  
   不過 GetKeyCardCompareResult 本身不好理解，  
   Zip 的寫法我覺得很單純,  
   但是在 Tuple.Create 產生的 ItemN 我個人本身不太喜歡，  
   覺得會降低可讀性，但是暫時想不到更好的寫法，  
   也可能單純只是我個人的感覺問題。

2. 使用 IComparer\<HandCard\> 減少 Duel() 的職責
    1. 建立一個 Compare 方法，將 Category 比較邏輯抽換到 Compare 方法之中  
       思考: Compare 是實作 IComparer\<T\> 的方法，但是我會很自然的比較 Category 而非 HandCard，  
       但是 ShowHand 實作 IComparer\<Category\> 很奇怪，直覺上這不是它的職責。  
       於是我決定把 IComparer\<Category\> 的邏輯搬進 HandCard
    2. 實作 HandCardComparer 這個時候 KeyCard 的比較邏輯還在留在 ShowHand 就很奇怪了，  
       應該被搬進 HandCardComparer 這時候 KeyCard 的比較就會發現與回傳值有耦合，  
       應該把比較與回傳值(OutPut)作分離。  
       回傳值進一步分析，會有 KeyCard 的值與贏家姓名兩個變數，同時又與比較邏輯相依。  
       這個時候，我覺得 KeyCard 的值，應該給 Comparer 判斷，  
       但贏家的值應該還是由主程式(ShowHand) 處理

整個作完覺得有點走火入魔 ?? 不太確定這樣的重構是否能增加可讀性或好維護。

下一步我想把 Category 放到 Comparer 裡，原因是 KeyCard 作為比較條件已經被放入 Comparer 了。 同樣的比較條件應該被放在相同的類別之中。

#### 參考

- ([.NET]快快樂樂學LINQ系列－Zip() 簡介)[https://dotblogs.com.tw/hatelove/2014/06/06/linq-enumerable-zip-introduction]

(fin)
