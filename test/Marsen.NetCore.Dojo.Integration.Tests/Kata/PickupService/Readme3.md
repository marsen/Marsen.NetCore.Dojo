#  Marsen way TDD Kata - PickupService III

## 前情提要

2023 年 11 月，很高興迎來了 .Net 8.0 的版本，
趕緊得來將 TDD Dojo 的練習題目升級一下。
單元測試沒什麼問題，整合測試就壞掉了，
太久沒有運行專案，原本提供給測試的 API 服務已經關閉了，
必須來進行修正。

上一次用遺留代碼來開發，這次沒有代碼了，只剩遺留的測試。
有趣! 讓我來試試看吧

## Mock API

### Test case DONE

```json
{
  "result": "success",
  "content": [
    {
      "merchantId": "123",
      "merchantRef": "ABC123",
      "waybillNo": "W123456",
      "locationId": "456",
      "pudoRef": "PUDO789",
      "pudoVerifyCode": "1234",
      "senderId": "Sender123",
      "consigneeId": "Consignee456",
      "customerName": "John Doe",
      "customerAddress1": "123 Main St",
      "customerAddress2": "Apt 456",
      "customerAddress3": "Suburb",
      "customerAddress4": "City",
      "feedbackURL": "https://example.com/feedback",
      "eta": "2023-01-01",
      "codAmt": "50.00",
      "sizeCode": "L",
      "lastStatusId": "DONE",
      "lastStatusDescription": "Delivered to Customer",
      "lastStatusDate": "2023-01-01",
      "lastStatusTime": "12:34:56",
      "customerMobile": "1234567890",
      "customerEmail": "john.doe@example.com",
      "errorCode": null
    }
  ]
}

```

### Test case Shipping

```json
{
  "result": "success",
  "content": [
    {
      "merchantId": "123",
      "merchantRef": "ABC123",
      "waybillNo": "W123456",
      "locationId": "456",
      "pudoRef": "PUDO789",
      "pudoVerifyCode": "1234",
      "senderId": "Sender123",
      "consigneeId": "Consignee456",
      "customerName": "John Doe",
      "customerAddress1": "123 Main St",
      "customerAddress2": "Apt 456",
      "customerAddress3": "Suburb",
      "customerAddress4": "City",
      "feedbackURL": "https://example.com/feedback",
      "eta": "2023-01-01",
      "codAmt": "50.00",
      "sizeCode": "L",
      "lastStatusId": "Shipping",
      "lastStatusDescription": "Delivered to Customer",
      "lastStatusDate": "2023-01-01",
      "lastStatusTime": "12:34:56",
      "customerMobile": "1234567890",
      "customerEmail": "john.doe@example.com",
      "errorCode": null
    }
  ]
}
```

### Test case FAIL

```json
{
  "result": "success",
  "content": [
    {
      "merchantId": "123",
      "merchantRef": "ABC123",
      "waybillNo": "W123456",
      "locationId": "456",
      "pudoRef": "PUDO789",
      "pudoVerifyCode": "1234",
      "senderId": "Sender123",
      "consigneeId": "Consignee456",
      "customerName": "John Doe",
      "customerAddress1": "123 Main St",
      "customerAddress2": "Apt 456",
      "customerAddress3": "Suburb",
      "customerAddress4": "City",
      "feedbackURL": "https://example.com/feedback",
      "eta": "2023-01-01",
      "codAmt": "50.00",
      "sizeCode": "L",
      "lastStatusId": "FAIL",
      "lastStatusDescription": "Delivered to Customer",
      "lastStatusDate": "2023-01-01",
      "lastStatusTime": "12:34:56",
      "customerMobile": "1234567890",
      "customerEmail": "john.doe@example.com",
      "errorCode": null
    }
  ]
}
```

### Test Case Expiry

```json
{
  "result": "success",
  "content": [
    {
      "merchantId": "123",
      "merchantRef": "ABC123",
      "waybillNo": "W123456",
      "locationId": "456",
      "pudoRef": "PUDO789",
      "pudoVerifyCode": "1234",
      "senderId": "Sender123",
      "consigneeId": "Consignee456",
      "customerName": "John Doe",
      "customerAddress1": "123 Main St",
      "customerAddress2": "Apt 456",
      "customerAddress3": "Suburb",
      "customerAddress4": "City",
      "feedbackURL": "https://example.com/feedback",
      "eta": "2023-01-01",
      "codAmt": "50.00",
      "sizeCode": "L",
      "lastStatusId": "Expiry",
      "lastStatusDescription": "Delivered to Customer",
      "lastStatusDate": "2023-01-01",
      "lastStatusTime": "12:34:56",
      "customerMobile": "1234567890",
      "customerEmail": "john.doe@example.com",
      "errorCode": null
    }
  ]
}
```

### Test Case Arrived

```json
{
  "result": "success",
  "content": [
    {
      "merchantId": "123",
      "merchantRef": "ABC123",
      "waybillNo": "W123456",
      "locationId": "456",
      "pudoRef": "PUDO789",
      "pudoVerifyCode": "1234",
      "senderId": "Sender123",
      "consigneeId": "Consignee456",
      "customerName": "John Doe",
      "customerAddress1": "123 Main St",
      "customerAddress2": "Apt 456",
      "customerAddress3": "Suburb",
      "customerAddress4": "City",
      "feedbackURL": "https://example.com/feedback",
      "eta": "2023-01-01",
      "codAmt": "50.00",
      "sizeCode": "L",
      "lastStatusId": "Arrived",
      "lastStatusDescription": "Delivered to Customer",
      "lastStatusDate": "2023-01-01",
      "lastStatusTime": "12:34:56",
      "customerMobile": "1234567890",
      "customerEmail": "john.doe@example.com",
      "errorCode": null
    }
  ]
}
```



### Test Case Error
```json
{
  "result": "error",
  "content": []
}
```
### Test Case Error Content

```json
{
  "result": "success",
  "content": []
}
```

### Test Case Exception

```json
Something Wrong

```

(fin)
