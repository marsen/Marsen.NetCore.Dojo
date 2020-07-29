import Tennis from '../../src/Kata/Tennis';
import { expect } from 'chai';

let tennis = new Tennis();

describe('SameSate', function() {
  it('0-0 Should Be Love All', ()=>{
    ScoreShouldBe("Love All")
  });

  it('1-1 Should Be Fifteen All', ()=>{
    GivenReceiverScore(1)
    tennis.ServerScore();
    ScoreShouldBe("Fifteen All")
  });

});

describe('NormalSate', function() {
  beforeEach(()=>{
    tennis = new Tennis();
  });

  it('0-1 Should Be Love Fifteen', ()=>{
    GivenReceiverScore(1)
    ScoreShouldBe("Love Fifteen");
  });

  it('0-2 Should Be Love Thirty', ()=>{
    GivenReceiverScore(2);
    ScoreShouldBe("Love Thirty");    
  });
  
  it('0-3 Should Be Love Forty', ()=>{
    GivenReceiverScore(3);
    ScoreShouldBe("Love Forty");    
  });

  it('1-0 Should Be Fifteen Love', ()=>{
    tennis.ServerScore();
    ScoreShouldBe("Fifteen Love");    
  });

  it('2-0 Should Be Thirty Love', ()=>{
    tennis.ServerScore();
    tennis.ServerScore();
    ScoreShouldBe("Thirty Love");    
  });
});

function ScoreShouldBe(expected:string) {
  expect(expected).equal(tennis.Score());
}

function GivenReceiverScore(times:number) {
  for (let i = 0; i < times; i++) {
    tennis.ReceiverScore();
  }
}
