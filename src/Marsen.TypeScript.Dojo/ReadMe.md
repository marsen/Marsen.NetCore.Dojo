# DatePicker

## Context & User Stories  

## Test Cases  

## Tools

### 使用 Mocha 與 Chai

npm i -D chai mocha nyc ts-node typescript

#### 安裝 [TypeScript](https://www.typescriptlang.org)

安裝至專案

```shell
npm i -D typescript ts-node
```

安裝至全域

```shell
npm i -g typescript
```

建立專案 `tsconfig.json`

```shell
tsc --init
```

#### 安裝 [MochaJs](https://mochajs.org/)

```shell
npm i -D mocha @types/mocha
```

#### 安裝 [Chai](https://www.chaijs.com/)  

```shell
npm i -D Chai @types/chai
```

#### 設定測試

package.json\

```script
"scripts":{
    "test": "mocha -r ts-node/register tests/**/*.test.ts",
}
```

#### 寫測試

```script
import { expect } from 'chai';
import Calculator from '../src/calculate';

describe('calculate', function() {
  it('add', function() {
    let result = Calculator.Sum(5, 2);
    expect(result).equal(7);
  });
});
```

#### 實作代碼

```script
export default class calculator {
    static Sum(a: number, b: number): number {
  
    }
```

#### 執行測試

```shell
npm t
```

#### 修正代碼

```script
export default class calculator {
    static Sum(a: number, b: number): number {
        let c = a + b;
        eturn c;
    }
```

#### 測試結果

```shell
  calculate
    √ add


  1 passing (61ms)
```

## 測試覆蓋率

// TODO

## 參考

- <https://github.com/ChiragRupani/TSUnitTestsSetup>
- [Writing unit tests in TypeScript](https://medium.com/@RupaniChirag/writing-unit-tests-in-typescript-d4719b8a0a40)

## 20190608 補充

Github 回報有高風險的漏洞，
本機執行 `npm i` 進行確認

```shell
$ npm i
npm WARN marsen.typescript.dojo.datepicker@1.0.0 No repository field.

audited 1517 packages in 3.461s
found 3 vulnerabilities (1 moderate, 2 high)
  run `npm audit fix` to fix them, or `npm audit` for details
```

確認有漏洞，執行 `npm audit fix` 進行自動修複

```shell
$ npm audit fix
npm WARN marsen.typescript.dojo.datepicker@1.0.0 No repository field.

+ mocha@6.1.4
added 11 packages from 5 contributors, removed 126 packages, updated 16 packages and moved 4 packages in 9.188s
fixed 2 of 3 vulnerabilities in 1517 scanned packages
  1 package update for 1 vuln involved breaking changes
  (use `npm audit fix --force` to install breaking changes; or refer to `npm audit` for steps to fix these manually)
```
