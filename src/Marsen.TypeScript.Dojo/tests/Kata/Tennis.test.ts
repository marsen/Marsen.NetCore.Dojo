import Tennis from '../../src/Kata/Tennis';
import { expect } from 'chai';

let tennis = new Tennis();

describe('SameSate', function() {
  it('0-0 Should Be Love All', ()=>{
    expect("Love All").equal(tennis.Score());    
  });

  it('1-1 Should Be Fifteen All', ()=>{
    tennis.ReceiverScore();
    tennis.ServerScore();
    expect("Fifteen All").equal(tennis.Score());    
  });

});

describe('NormalSate', function() {
  beforeEach(()=>{
    tennis = new Tennis();
  });

  it('0-1 Should Be Love Fifteen', ()=>{
    tennis.ReceiverScore();
    expect("Love Fifteen").equal(tennis.Score());    
  });

  it('0-2 Should Be Love Thirty', ()=>{
    GivenReceiverScore(2);
    expect("Love Thirty").equal(tennis.Score());    
  });

});

function GivenReceiverScore(times:number) {
  for (let i = 0; i < times; i++) {
    tennis.ReceiverScore();
  }
}
