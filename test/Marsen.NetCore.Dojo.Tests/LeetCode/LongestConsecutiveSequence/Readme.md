# Longest Consecutive Sequence

Given an unsorted array of integers nums,  

return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

Example 1:

```text
Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
```

Example 2:

```text
Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9
```

Constraints:

- 0 <= nums.length <= 10^5
- -10^9 <= nums[i] <= 10^9

## ChatGPT Suggestions

要使用測試趨動開發（Test Driven Development，TDD）的方式解決這個問題，可以根據問題描述和約束條件，設計一些測試案例，然後根據這些測試案例進行開發。

以下是一些可能的測試案例：

測試空數組的情況：輸入為 []，預期輸出為 0。
測試僅包含一個元素的數組的情況：輸入為 [5]，預期輸出為 1。
測試數組中所有元素都重複的情況：輸入為 [3, 3, 3, 3, 3]，預期輸出為 1。
測試數組中所有元素都不相鄰的情況：輸入為 [5, 2, 8, 1, 7]，預期輸出為 1。
測試數組中有多個連續序列的情況：輸入為 [100, 4, 200, 1, 3, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]，預期輸出為 11。
測試數組中有負數的情況：輸入為 [-3, -2, -1, 0, 1, 2, 3]，預期輸出為 7。
根據這些測試案例，可以開發相應的功能。在開發過程中，需要先撰寫測試案例，確保這些測試案例都能通過，然後再進行相應的代碼實現。這樣可以確保代碼的正確性和穩定性。

你的測試案例應該涵蓋了許多情況，但還是可以再加強。以下是幾個可以考慮的測試案例：

測試當數列中有重複的數字時，是否會計算重複的數字。例如 [1, 2, 2, 3, 4]，預期結果為 4。
測試當數列中有負數時，是否會計算負數。例如 [-3, -2, -1, 0, 1, 2, 3]，預期結果為 7。
測試當數列中有遞增但不是連續的序列時，是否會判斷錯誤。例如 [1, 2, 4, 5, 7]，預期結果為 2。
測試當數列中有極端值時，例如 [0, 1, 1000000000, -1000000000, 2, 3]，預期結果為 4。
測試當數列中有非連續的序列時，例如 [1, 2, 4, 5, 7]，預期結果為 2。

希望這些測試案例能對你有所幫助！