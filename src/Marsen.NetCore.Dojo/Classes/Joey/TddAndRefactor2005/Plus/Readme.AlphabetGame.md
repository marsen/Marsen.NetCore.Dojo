# 202005 演化式設計：測試驅動開發與持續重構 追加題目

## 題目

- A → A
- ab → A-Bb
- abc → A-Bb-Ccc
- a → A
- a3 → A-33

### 分析

- 轉大寫 OR 轉小寫
- 加 `-` 字符
- 印出 Bb
    - 第 n 個字元就印出長度為 n 的字串
    - 字串首字元必須為大寫，其他為小寫

### Case Order

- A → A
- a → A
- ab → A-Bb
- abc → A-Bb-Ccc
- a3 → A-33

想法，先處理大小寫，再處理第幾個字元要印幾次。

## 第一次實作心得

卡最久就是 ab 應該為 A-Bb 這個測試案例， 作完之後，剩下的測試也都 pass 了，感覺不夠 baby step

(fin)
 
