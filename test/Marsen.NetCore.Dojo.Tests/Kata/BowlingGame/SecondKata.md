# 第二次 Kata

## 第一次失敗後重塑的認知與規則

1. 總分是Frame 的分數的加總
2. Frame 的分數由兩次 try 與 bonus 作計算
3. 兩次 try 的加總等於 10 才有 bonus
4. 有 bonus 的話必須計算完 bonus 才有分數

## TODO List

- [ ] Frame 的分數是 2 次 try 的加總加上 bonus
    - [x] 一個 Frame 未 try 過 2 次的是 null
    - [x] Try 的分數計算方式是加法
    - [x] Bonus 的計算方式
        - [x] Spare 的計算方式
        - [x] Strike 的計算方式
        - [x] Bonus 職責移到 Frames 之中
    - [x] 正確的 Frame 數量
    - [x] 有 Bonus 但是還未計算的分數為 null
    - [x] 連續 3 次 Strike
- [ ] Game 的總分是 Frame 的分數的加總
- [ ] Refactor
    - [ ] 消除重複
    - [ ] 使用 Enum 處理 BonusType
    - [x] Spare 邏輯歸 Frame
    - [x] Strike 邏輯歸 Frame

(fin)
