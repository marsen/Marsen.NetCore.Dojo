# Bowling Game

## Rules

- Each game, or “line” of bowling, includes ten turns, or “frames” for the bowler.
- In each frame, the bowler gets up to two tries to knock down all the pins. 
- If in two tries, he fails to knock them all down, 
  his score for that frame is the total number of pins knocked down in his two tries. 
- If in two tries he knocks them all down, this is called a “spare” 
  and his score for the frame is ten plus the number of pins knocked down on his next throw (in his next turn). 
- If on his first try in the frame he knocks down all the pins, this is called a “strike”. 
  His turn is over, and his score for the frame is ten plus the simple total of the pins knocked down in his next two rolls. 
- If he gets a spare or strike in the last (tenth) frame, the bowler gets to throw one or two more bonus balls, respectively. 
  These bonus throws are taken as part of the same turn. If the bonus throws knock down all the pins, 
  the process does not repeat: the bonus throws are only used to calculate the score of the final frame. 
- The game score is the total of all frame scores.

### 中文

- 一個玩家(bowler)，每場(line)有 10 個回合(frames)
- 每個回合玩家可以打兩次
- 如果兩次打完，沒有全倒，回合分數為擊倒的瓶子總數
- 如果兩次打完，全倒，簡稱 Spare，回合分數為 10 分加上下一次擊倒的瓶子分數
- 如果在第一次打完，全倒，簡稱 Strike，回合直接結束，回合分數為 10 分加上下二次擊倒的瓶子分數 
- 如果在第 10 回合，
  - 玩家擊出 Spare 可以有 1 次額外擊球機會
  - 玩家擊出 Strike 可以有 ２ 次額外擊球機會
  - 額外的擊球只是為了計算第 10 回合的分數
- 整場遊戲的分數是所有回合的加總

## TODO List
- [ ] 計算總分
- [ ] 計算回合分數
- [x] 一回合兩次擊球，沒有全倒
  - [ ] 前面有 Spare 或 Strike 的計算
- [ ] Spare，加上額外一擊的分數
- [ ] Strike，加上額外二擊的分數
- [x] API，給定一個數列，回傳一個分數
  - [x] 0 分不等於沒有分
  - [x] 初始分數是沒有分
  - [x] 第一球就洗溝，0分
  - [x] 第一球就打倒１瓶，1 分
-[ ] 最後一回合的計算 


## 參考
- https://www.bowlinggenius.com/
- https://kata-log.rocks/bowling-game-kata
- http://ronjeffries.com/xprog/articles/acsbowling/
- https://codingdojo.org/kata/Bowling/

(fin)