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
執行 Parse 方法之後

### Assert

回傳一個 PersonEntity ，裡面的資料應該要是
```csharp
new PersonEntity {
    Name = "Tian Tank"
    Age = 30
}
```

### 工序

#### Step1.
 
第一個案例，我會只驗証 Name 的組合邏輯  


```csharp
[Fact]
public void CovertName()
{
    ////Arrange

    ////Act
    var actual = _target.Parse(testJson).Name;
    ////Assert
    actual.Should().BeEquivalentTo("Tian Tank");
}
```

Production Code 簡單寫可以這樣,   
這個可以說是極致的 Baby Step 吧 ?

```csharp
public PersonaEntity Parse(string json)
{    
    return new PersonaEntity
    {        
        Name = "Tian Tank"
    };
}
```

不過這個階段可以透過 IDE 工具長出合適的 Entity

```csharp
public class PersonaEntity
{
    public string Name { get; set; }        
}
```

#### Step1.1

但是通常分析過需求，我們應該可以理解到 PersonaEntity.Name  
其實是 FirstName 與 LastName 的組合，  
所以我的步伐會大步一點，如下

```csharp
public PersonaEntity Parse(string json)
{    
    return new PersonaEntity
    {        
        Name = "Tian" + "Tank"
    };
}
```

#### Step1.2

Oops 我會拿到一個紅燈，因為我忘了**空白**，  
修改 Production Code 如下，得到綠燈

```csharp
public PersonaEntity Parse(string json)
{    
    return new PersonaEntity
    {        
        Name = "Tian" +" "+ "Tank"
    };
}
```

#### Step1.3

開始重構，這樣的 Baby Step 會不會真的太小步了 ?

```csharp
public PersonaEntity Parse(string json)
{    
    var firstName = "Tian";
    var lastName = "Tank";
    return new PersonaEntity
    {
        Name = firstName + " " + lastName
    };
}
```

#### Step1.4

長出新的 Entity

```csharp
public PersonaEntity Parse(string json)
{    
    var firstName = "Tian";
    var lastName = "Tank";
    var originEntity = new PersonaOriginEntity
    {
        FirstName = firstName,
        LastName = lastName
    };
    return new PersonaEntity
    {
        Name = $"{originEntity.FirstName} {originEntity.LastName}"
    };
}
```

```csharp
public class PersonaOriginEntity
{
    public string LastName { get; set; }
    public string FirstName { get; set; }    
}
```

#### Step1.5

重構

```csharp
public PersonaEntity Parse(string json)
{
    var originEntity = new PersonaOriginEntity
    {
        FirstName = "Tian",
        LastName = "Tank"
    };
    return new PersonaEntity     
    {
        Name = $"{originEntity.FirstName} {originEntity.LastName}"
    };
}
```

#### Step1.6

改用 JSON Parser

```csharp
public PersonaEntity Parse(string json)
{
   //var originEntity = new PersonaOriginEntity
   //{
   //    FirstName = "Tian",
   //    LastName = "Tank"
   //};
   var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json);

   return new PersonaEntity
   {
       Name = $"{originEntity.FirstName} {originEntity.LastName}"
   };
}
```

#### Step1.7

移除無用代碼

```csharp
public PersonaEntity Parse(string json)
{
   //var originEntity = new PersonaOriginEntity
   //{
   //    FirstName = "Tian",
   //    LastName = "Tank"
   //};
   var originEntity = JsonSerializer.Deserialize<PersonaOriginEntity>(json);

   return new PersonaEntity
   {
       Name = $"{originEntity.FirstName} {originEntity.LastName}"
   };
}
```


#### Step2.


第二個案例，我會驗証 Age 的計算邏輯  

#### Case 2. Age 是現在時間減去生日的年份差
   
首先，要如何處理 **現在時間**  ??  
一般的 Production Code 會用 `DateTime.Now`  




### 其它

如果未來有多新的欄位再逐步加上測試。  
但在實務上我極有可能會同時驗証大量的欄位 