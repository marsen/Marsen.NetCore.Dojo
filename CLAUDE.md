# CLAUDE.md

此文件為 Claude Code (claude.ai/code) 在此儲存庫中工作時提供指導。

## 專案結構

這是一個多語言的 dojo/kata 練習儲存庫，包含：

- **C# (.NET 9.0)**: 主要程式練習與實作專案
  - `src/Marsen.NetCore.Dojo/` - 主要 C# 專案，包含 kata、設計模式和重構練習
  - `src/Marsen.NetCore.TestingToolkit/` - 測試工具和輔助程式
  - `test/` - 單元測試、整合測試和 E2E 測試
- **TypeScript**: 位於 `src/Marsen.TypeScript.Dojo/`，使用 Mocha/Chai 測試框架
- **Python**: 位於 `src/Marsen.Python/`

## 開發指令

### C# (.NET Core)

```bash
# 建置解決方案
dotnet build "Marsen.NetCore.Dojo.Integration.Test.sln"

# 執行單元測試
dotnet test ./test/Marsen.NetCore.Dojo.Tests/Marsen.NetCore.Dojo.Tests.csproj

# 執行整合測試
dotnet test ./test/Marsen.NetCore.Dojo.Integration.Tests/Marsen.NetCore.Dojo.Integration.Tests.csproj

# 執行 E2E 測試
dotnet test ./test/Marsen.NetCore.Dojo.E2E.Tests/Marsen.NetCore.Dojo.E2E.Tests.csproj
```

### TypeScript

```bash
cd src/Marsen.TypeScript.Dojo/
npm test                # 使用 Mocha 執行測試
npm run cover          # 使用 nyc 執行測試覆蓋率分析
```

## 架構說明

- C# 專案使用 .NET 9.0，相依套件包括 Autofac (依賴注入)、Dapper (資料存取) 和 NLog (日誌記錄)
- 包含來自《修改程式的藝術》等書籍的實務練習
- 組織結構包含資料夾：Books、Classes、Common、Extend、Kata、LeetCode
- 使用 Stryker.NET 進行變異測試 (設定檔在 `stryker-config.json`)
- 整合 SonarCloud 進行程式碼品質分析

## CI/CD 整合

- GitHub Actions 工作流程處理 .NET Core、TypeScript、SonarCloud 分析和 Stryker 變異測試
- 透過 SonarCloud 強制執行程式碼品質檢查
- 變異測試徽章追蹤程式碼品質指標
