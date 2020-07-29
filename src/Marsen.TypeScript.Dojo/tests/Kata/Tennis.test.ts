import Tennis from '../../src/Kata/Tennis';
import { expect } from 'chai';

let tennis = new Tennis();

describe('SameSate', function() {
  it('0-0 Should Be Love All', ()=>{
    expect(tennis.Score()).equal("Love All");    
  });

});

describe('NormalSate', function() {
  it('0-1 Should Be Love Fifteen', ()=>{
    tennis.ReceiverScore();
    expect(tennis.Score()).equal("Love Fifteen");    
  });

});