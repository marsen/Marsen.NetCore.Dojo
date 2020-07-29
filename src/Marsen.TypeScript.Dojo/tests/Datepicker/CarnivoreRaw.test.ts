import { expect } from 'chai';
import D from '../../src/DatePicker/CarnivoreRaw';

describe('今天是 2019/3/30 號星期六 12:05', function() {

  beforeEach(function () {
      mockDate('2019-3-30 12:05');
  });

  it('日曆上 2019/4/02 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-4-02'))[0];
    expect(result).equal(true,'可以選');
  });

  it('日曆上 2019/4/02 星期二 設定為國定假日, 出貨 不可以選', function() {
    D.blockDateList.push("2019-4-2");
    let result = D.IsShow(new Date('2019-4-02'))[0];
    expect(result).equal(false,'不可以選');
  });

  afterEach(function () {
      D.blockDateList=[];
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/24 號星期日 12:05', function() {

  beforeEach(function () {
      mockDate('2019-3-24 11:55');
  });

  it('日曆上 2019/3/25 星期一 出貨 不可以選', function() {
    let result = D.IsShow(new Date('2019-3-25'))[0];
    expect(result).equal(false,'不可以選');
  });

  it('日曆上 2019/3/26 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-26'))[0];
    expect(result).equal(true,'可以選');
  });

  afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/23 號星期六 12:05', function() {

  beforeEach(function () {
      mockDate('2019-3-23 12:05');
  });

  it('日曆上 2019/3/25 星期一 出貨 不可以選', function() {
    let result = D.IsShow(new Date('2019-3-25'))[0];
    expect(result).equal(false,'不可以選');
  });

  it('日曆上 2019/3/26 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-26'))[0];
    expect(result).equal(true,'可以選');
  });

  afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/22 號星期五 23:05', function() {

  beforeEach(function () {
      mockDate('2019-3-22 23:05');
  });

  it('日曆上 2019/3/25 星期一 出貨 不可以選', function() {
    let result = D.IsShow(new Date('2019-3-25'))[0];
    expect(result).equal(false,'不可以選');
  });

  it('日曆上 2019/3/26 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-26'))[0];
    expect(result).equal(true,'可以選');
  });

    afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/21 號星期四 01:30', function() {

  beforeEach(function () {
      mockDate('2019-3-21 01:30');
  });

  it('日曆上 2019/3/21 星期四 出貨 不可以選', function() {
    let result = D.IsShow(new Date('2019-3-21'))[0];
    expect(result).equal(false,'不可以選');
  });

  it('日曆上 2019/3/22 星期五 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-22'))[0];
    expect(result).equal(true,'可以選');
  });
  
  afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/22 號星期五 23:05', function() {

  beforeEach(function () {
      mockDate('2019-3-22 23:05');
  });

  it('日曆上 2019/3/25 星期一 出貨 不可以選', function() {
    let result = D.IsShow(new Date('2019-3-25'))[0];
    expect(result).equal(false,'不可以選');
  });

  it('日曆上 2019/3/26 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-26'))[0];
    expect(result).equal(true,'可以選');
  });

    afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/19 號星期二 23:05', function() {

  beforeEach(function () {
      mockDate('2019-3-19 23:05');
  });

  it('日曆上 2019/3/21 星期四 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-21'))[0];
    expect(result).equal(true,'可以選');
  });

    afterEach(function () {
      Date.now = originalDateNow;
  });
});

describe('今天是 2019/3/22 號星期五 12:59', function() {

  beforeEach(function () {
      mockDate('2019-3-22 12:59');
  });

  it('日曆上 2019/3/22 星期五 出貨 不能選,因為現在時間超過 12 點', function() {
    let result = D.IsShow(new Date('2019-3-22'))[0];
    expect(result).equal(false,'不能選,因為現在超過12點');
  });

  it('日曆上 2019/3/25 星期一 出貨 不能選,因為現在時間超過 12 點', function() {
    let result = D.IsShow(new Date('2019-3-25'))[0];
    expect(result).equal(false,'不能選,因為現在超過12點');
  });

  it('日曆上 2019/3/26 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-26'))[0];
    expect(result).equal(true,'可以選');
  });

  it('日曆上 2019/4/1 星期一 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-4-1'))[0];
    expect(result).equal(true,'可以選');
  });

  it('日曆上 2019/3/23 星期六 出貨 不能選,因為現在時間超過 12 點', function() {
    let result = D.IsShow(new Date('2019-3-23'))[0];
    expect(result).equal(false,'不能選,因為現在超過12點');
  });

  afterEach(function () {
      Date.now = originalDateNow;
  });
  
});

describe('今天是 2019/3/21 號星期四 23:59', function() {

  beforeEach(function () {
      mockDate('2019-3-21 23:59')
  });

  it('日曆上 2019/3/21 星期四 出貨 不能選,因為現在時間超過 12 點', function() {
    let result = D.IsShow(new Date('2019-3-21'))[0];
    expect(result).equal(false,'不能選,因為現在是12點');
  });

  afterEach(function () {
      Date.now = originalDateNow;
  });
  
});

describe('今天是 2019/3/18 號星期一12:00', function() {
  
  beforeEach(function () {
    mockDate('2019-3-18 12:00');
  });
  
  it('日曆上 2019/3/18 星期一 出貨 不能選,因為現在是12點', function() {
    let result = D.IsShow(new Date('2019-3-18'))[0];
    expect(result).equal(false,'不能選,因為現在是12點');
  });
  
  it('日曆上 2019/3/19 星期二 出貨 不能選,因為現在是12點', function() {
    let result = D.IsShow(new Date('2019-3-19'))[0];
    expect(result).equal(false,'不能選,因為現在是12點');
  });
  
  it('日曆上 2019/3/20 星期三 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-20'))[0];
    expect(result).equal(true,'可以選');
  });
  
  it('日曆上 2019/3/21 星期四 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-21'))[0];
    expect(result).equal(true,'可以選');
  });
  
  afterEach(function () {
    Date.now = originalDateNow;
  });
  
});

describe('今天是 2019/3/18 號星期一10:00', function() {

  beforeEach(function () {
    mockDate('2019-3-18 10:00');
  });  

  it('日曆上 2019/3/24 星期日 出貨;不能選,因為週日都不能選', function() {
    let result = D.IsShow(new Date('2019-3-24'))[0];
    expect(result).equal(false,'不能選,因為週日都不能選');
  },);
  
  it('日曆上 2019/3/18 星期一 出貨 不可以選,因為當天不能選', function() {
    let result = D.IsShow(new Date('2019-3-18'))[0];
    expect(result).equal(false,'不可以選');
  },)
  
  it('日曆上 2019/3/19 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-19'))[0];
    expect(result).equal(true,'可以選');
  },)
  
  it('日曆上 2019/3/20 星期三 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-20'))[0];
    expect(result).equal(true,'可以選');
  },)
  
  afterEach(function () {
    Date.now = originalDateNow;
  });
});

const originalDateNow = Date.now;

function mockDate(input:string){
  
  Date.now = function(){
        return new Date(input).valueOf();
      };
}