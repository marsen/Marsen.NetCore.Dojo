# 
## 需求說明 

系統需要透過打 API 來進行付款，  
但是為了追蹤金流，在打 API 的過程中，  
我需要帶著 RequestId 。  
而 RequestId 也需要透過另一個 API 來提供。

整體流程如下:
1. 打 API 取得 RequestId
2. 組合付款資料與 RequestId
3. 打 API 完成付款