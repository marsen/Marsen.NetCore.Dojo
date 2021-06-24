# 重構步驟

1. 解除繼承
2. 實作 HandsetGame 與 HandsetAddressBook 先不管品牌，全部以 N 牌實作
3. Create HandsetNokia , Client 組合執行 HandsetGame 與 HandsetAddressBook
4. Create HandsetMotorola , Client 組合執行發現相異點
5. HandsetGame 修改 HandsetSoft Run 方法簽章
6. 抽取 Brand 作為可變動的參數
7. HandsetAddressGame 相同處理
8. 抽取介面
9. 讓 Brand 在建構子中賦值
