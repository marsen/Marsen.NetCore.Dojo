

## Test Case

| Joey     | Tom | Expceted |
| -------- | -------- | -------- |
| 0     | 0     | Love All     |
| 1     | 0     | Fifteen Love     |
| 2     | 0     | Thirty Love     |
| 3     | 0     | Forty Love     |
| 0     | 1     | Love Fifteen    |
| 0     | 2     | Love Thirty    |
| 0     | 3     | Love Forty    |
| 1     | 1     | Fifteen All     |
| 2     | 2     | Thirty All     |
| 3     | 3     | Deuce        |
| 4     | 4     | Deuce        |
| 4     | 3     | Joey Adv     |
| 5     | 3     | Joey Win     |
| 3     | 4     | Tom Adv     |
| 3     | 5     | Tom Win     |

## State Pattern

因為 91 大上課的一句話，「有人使用狀態機」完成這個 Kata ，  
所以我也想來試一下。  
這僅僅是設計理念上的不同，所以我依然要用 TDD 來趨動。 
步驟如下：
- 了解 State Pattern 
- 分析 Tennis Kata 的 State
- 設計 Test Cases
- TDD

### 什麼是 State Pattern ?