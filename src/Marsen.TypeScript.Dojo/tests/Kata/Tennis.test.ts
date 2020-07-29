import Tennis from '../../src/Kata/Tennis';
import { expect } from 'chai';

let tennis = new Tennis();

describe('SameSate', function() {
  it('0-0 Should Be Love All', ()=>{
    var result = tennis.Score();
    expect(result).equal("Love All");    
  });

});