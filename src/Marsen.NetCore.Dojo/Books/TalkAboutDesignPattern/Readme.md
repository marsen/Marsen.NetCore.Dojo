# 

## 手機玩遊戲

### 兩種過度繼承

手機品牌(HandsetBrand)
![手機品牌](https://imgur.com/CQhPeok.jpg)

### 重構

覺察到 HandsetNokia 與 HandsetMotorola 兩個繼承了 HandsetBrand 的 Class 中
方法 Run 並沒有實際上的邏輯存在。
這是不是就是「過度繼承」的壞味道呢 ?

首先實作 Run 方法，`Nokia` 與 `Motorola` 應該擁有品牌(brand)的邏輯，
而真正 Run 的是 Game 或 AddressBook 所以實作的部份我們修改如下:

```csharp=
   public void Run()
   {
        Console.WriteLine($"Run {_band} Game");
   }
```
---

手機軟件(HandsetSoftware)
![手機軟件](https://imgur.com/LAsrHMn.jpg)




