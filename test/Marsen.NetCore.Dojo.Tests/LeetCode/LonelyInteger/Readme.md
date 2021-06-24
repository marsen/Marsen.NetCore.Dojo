# 題目

https://www.hackerrank.com/challenges/lonely-integer/problem

You will be given an array of integers. All of the integers except one occur twice. That one is unique in the array.

Given an array of integers, find and print the unique element.

For example, a = [1,2,3,4,3,2,1] , the unique element is 4.

Function Description

Complete the lonelyinteger function in the editor below. It should return the integer which occurs only once in the
input array.

lonelyinteger has the following parameter(s):

a: an array of integers

Input Format

The first line contains a single integer, n , denoting the number of integers in the array. The second line contains n
space-separated integers describing the values in .

Constraints

- 1 <= n < 100
- It is guaranteed that n is an odd number and that there is one unique element.
- 0<= a[i] <= 100, where 0 <= i < n.

## Test Cases

### arr = [1]

should return 1 , 目的 : 產生方法介面

### arr = [2]

should return 2 , 目的 : 自 array 中取值

### arr = [2,3,2]

should return 3 目的 : Group array 取值

### arr = [1,2,3,4,3,2,1]

should return 3 目的 : match require document sample

(fin)
