import { expect } from 'chai';
import D from '../src/beforeShowDay';
import mockDate from '../src/helper/dateHelper';


describe('今天是 2019/3/18 號星期一上午12:00', function() {
  const originalDateNow = Date.now;

  beforeEach(function () {
      Date.now = function(){
        return new Date('2019-3-18 12:00').valueOf();
      };
  });

  it('卡尼想選 2019/3/18 星期一 出貨 不能選,因為現在是上午12點', function() {
    let result = D.IsShow(new Date('2019-3-18'))[0];
    expect(result).equal(false,'不能選,因為現在是上午12點');
  });
  
  it('卡尼想選 2019/3/19 星期二 出貨 不能選,因為現在是上午12點', function() {
    let result = D.IsShow(new Date('2019-3-19'))[0];
    expect(result).equal(false,'不能選,因為現在是上午12點');
  });
  
  it('卡尼想選 2019/3/20 星期三 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-20'))[0];
    expect(result).equal(true,'可以選');
  });
  
  it('卡尼想選 2019/3/21 星期四 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-21'))[0];
    expect(result).equal(true,'可以選');
  });
  
  afterEach(function () {
      Date.now = originalDateNow;
  });
  
});

describe('今天是 2019/3/18 號星期一上午10:00 不能選,因為週日都不能選', function() {
  it('卡尼想選 2019/3/24 星期日 出貨', function() {
    let result = D.IsShow(new Date('2019-3-24'))[0];
    expect(result).equal(false,'不能選,因為週日都不能選');
  },);

  it('卡尼想選 2019/3/18 星期一 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-18'))[0];
    expect(result).equal(true,'可以選');
  },)
  
  it('卡尼想選 2019/3/19 星期二 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-19'))[0];
    expect(result).equal(true,'可以選');
  },)
  it('卡尼想選 2019/3/20 星期三 出貨 可以選', function() {
    let result = D.IsShow(new Date('2019-3-20'))[0];
    expect(result).equal(true,'可以選');
  },)
});