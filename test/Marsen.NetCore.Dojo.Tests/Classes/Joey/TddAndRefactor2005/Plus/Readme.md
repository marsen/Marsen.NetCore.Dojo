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

## 分析與排序測試案例   

1. 依據輸入字元的 index ，決定輸出字串的長度
2. 首字一定要大寫
3. 中間用 `-` 分隔

### 

A → A : 決定方法的簽章
b → B : 決定首字大寫
bb → B-Bb : 決定中間用`-`串接
Ab → A-Ab : 用 loop 輪循字元zgc
