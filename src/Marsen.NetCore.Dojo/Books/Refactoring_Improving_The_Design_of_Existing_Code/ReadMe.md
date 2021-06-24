# Refactoring: Improving The Design of Existing Code

## 重構--改善即有程式的設計(第二版)

### 目的

1. 學習重構
2. 將書上範例改寫成 C#
3. 使用 .Net Code
4. 引入變異測試工具 `stryker-mutator`

### Tools

- ReSharper Ultimate
- dotCover
- https://stryker-mutator.io/

#### Install

To install Stryker.NET on your *test project* add the following lines to the root of your `.csproj` file. on your *test*
project.

``` XML
<ItemGroup>
    <DotNetCliToolReference Include="StrykerMutator.DotNetCoreCli" Version="*" />
    <PackageReference Include="StrykerMutator.DotNetCoreCli" Version="*" />
</ItemGroup>
```

After adding the references, install the packages by executing `dotnet restore` inside the project folder.

#### Usage

Stryker.NET can be used by executing the `dotnet stryker` command inside your test project folder, using the Stryker.CLI
package.

For the full documentation on how to use Stryker.NET, see the [Stryker.CLI readme](/src/Stryker.CLI/README.md).

#### Compatibility

Only compatible with .NET Core version 1.1+

Dotnet core runtime 2.1 needs to be available on your system to run dotnet stryker
