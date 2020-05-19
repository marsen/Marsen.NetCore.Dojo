## LeetCode 

You're given strings J representing the types of stones that are jewels,   
and S representing the stones you have.  Each character in S is a type of stone you have.    
You want to know how many of the stones you have are also jewels.

The letters in J are guaranteed distinct, and all characters in J and S are letters.   
Letters are case sensitive, so "a" is considered a different type of stone from "A".

Example 1:

Input: J = "aA", S = "aAAbbbb"
Output: 3
Example 2:

Input: J = "z", S = "ZZ"
Output: 0
Note:

S and J will consist of letters and have length at most 50.
The characters in J are distinct.

## 分析

方法簽章應該輸入 J 與 S 字串，回傳一個數字。  
應該要有一個計數器來計算所有珠寶的數量。  
簡單的想法就是輪循兩個字串中的每個字元，  
如果可以在 J 字串中的元素，在 S 字串中可以被找到，  
那麼計數器就加 1 最後回傳。


## 測試案例

### J = "a" , S = "b" , 回傳 0
建立方法簽章

### J = "a" , S = "a" , 回傳 1
建立計數器, 比較字串判斷計數器是否 +1

### J = "a" , S = "aBa" , 回傳 2
建立對 S 字串的迴圈比較

### J = "aB" , S = "aBa" , 回傳 3
建立對 J 字串的迴圈
