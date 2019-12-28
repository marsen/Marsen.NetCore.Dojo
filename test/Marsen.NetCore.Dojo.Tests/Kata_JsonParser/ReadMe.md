## 如何用 TDD 寫一個 Json Parser

情境，假設有一包 json 檔案如下

```json
{
  "FirstName": "Tian",
  "LastName": "Tank",
  "BirthDate": "1989/06/04"
}
```

我想轉換成 C# Entity ，
這個 Entity 裡面包含兩個商業邏輯
 
  1. 提供全名
  2. 提供年紀

ex:
```
Name = Tank Tian
Age = 35
```

如何透過 TDD 的工序達到這個目標 ?

## Step 1. 建立測試專案與方法
### Arrange 
傳入的字串如下
```json
{
  "FirstName": "Tian",
  "LastName": "Tank",
  "BirthDate": "1989/06/04"
}
```
### Act
執行一個 Parse 方法後

### Assert

回傳一個 PersonEntity ，裡面的資料應該要是
```csharp
new PersonEntity {
    Name = "Tian Tank"
    Age = 30
}
```

