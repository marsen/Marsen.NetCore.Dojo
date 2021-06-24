#  

## 手機玩遊戲

### 兩種過度繼承

手機品牌(HandsetBrand)
![手機品牌](https://imgur.com/CQhPeok.jpg)

### 重構

覺察到 HandsetNokia 與 HandsetMotorola 兩個繼承了 HandsetBrand 的 Class 中 方法 Run 並沒有實際上的邏輯存在。 這是不是就是「過度繼承」的壞味道呢 ?

首先實作 Run 方法，`Nokia` 與 `Motorola` 應該擁有品牌(brand)的邏輯， 而真正 Run 的是 Game 或 AddressBook 所以實作的部份我們修改如下:

```csharp=
   public void Run()
   {
        Console.WriteLine($"Run {_band} Game");
   }
```

實作 HandsetGame 與 HandsetAddressBook 後， 可以發現重複的地方。這個味道可以指引我們抽出抽像類別。 當我們開始使用 abstract class 組合 production code 時可以發現一個壞味道，
_band 應該屬於 abstract 而不需透過 production 傳入才對。

---

手機軟件(HandsetSoftware)
![手機軟件](https://imgur.com/LAsrHMn.jpg)




