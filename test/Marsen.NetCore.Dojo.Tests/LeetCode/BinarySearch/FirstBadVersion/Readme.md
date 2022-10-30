You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.



Example 1:
```
Input: n = 5, bad = 4
Output: 4
```
Explanation:
call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true
Then 4 is the first bad version.
Example 2:
```
Input: n = 1, bad = 1
Output: 1
```


Constraints:
```
1 <= bad <= n <= 231 - 1
```

Overflow Issue:

There are 2 int a, b and b > a ;
If we want find mid number between a and b ;
we should do this :
mid = (a+b)/2

but in programming this would be an issue with overflow
if a and b are big int number both
so what should we do ?
```
2mid = a+b
=>
2mid = b-a+2a
mid = (b-a)/2+a
```
and why this is safety with overflow
because a and b should be safe ,
and b > a so (b-a)/2+a should be safety too
we can not control the size of a+b (mean it's unsafe)
but we can control b-a




