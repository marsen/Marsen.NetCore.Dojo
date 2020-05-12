## 需求說明

舉例
input → output
A → A
ab → A-Bb
abc → A-Bb-Ccc

口頭補充:
1. 輸入可以是數字
2. 只有字母需要轉大小寫
3. 傳入空字串要拋 Exception

## 原則
1. 傳入的參數越少越好
2. 回傳越簡單越好
3. 互動次數越少越好
- 滿足需求
- 呈現意圖
- 避免重複
- 最少元素



## 分析與排序測試案例   

1. 依據輸入字元的 index ，決定輸出字串的長度
2. 首字一定要大寫
3. 中間用 `-` 分隔

### 計劃

A → A : 決定方法的簽章
b → B : 決定首字大寫
bb → B-Bb : 決定中間用`-`串接
ab → A-Bb : 用 loop 輪循字元
abc → A-Bb-Ccc : 用 loop 輪循字元

### 後記補充

A → A : 決定方法的簽章
b → B : ToUpper
*bb → Bb : 用 loop 輪循字元
這個測試一開始寫錯，後來改成 bb → B-Bb，也逼出中間用`-`串接
ab → A-Bb : 決定中間用`-`串接
因為前一個測試我一開始想錯，所以其實它沒有逼出任何新東西

abc → A-Bb-Ccc : 這裡我想逼出小寫字母重複的邏輯

一開始我先用比較粗暴的寫法通過測試，
但是也製造出 `substring.ToLower()` 的重複
EX:
```csharp
	if (i > 1)
	{
		result += "-" + substring.ToUpper() + substring.ToLower()+substring.ToLower();
	}
	else
	{
		result += "-" + substring.ToUpper() + substring.ToLower();
	}
```	
之後就是重構，
然後一開始我忘記了 A1→A-11 與空字串的案例，
所以這兩個是最後補的

(fin)
