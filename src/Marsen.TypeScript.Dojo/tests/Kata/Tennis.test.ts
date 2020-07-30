import Tennis from '../../src/Kata/Tennis';
import { expect } from 'chai';

let tennis:Tennis;

describe('SameSate', function() {
  beforeEach(()=>{
    InitialTennisGame();
  })
  it('0-0 Should Be Love All', ()=>{
    ScoreShouldBe("Love All")
  });

  it('1-1 Should Be Fifteen All', ()=>{
    GivenReceiverScore(1)
    GivenServerScore(1);
    ScoreShouldBe("Fifteen All")
  });

  it('2-2 Should Be Thirty All', ()=>{
    GivenReceiverScore(2)
    GivenServerScore(2);
    ScoreShouldBe("Thirty All")
  });

});

describe('NormalSate', function() {
  beforeEach(()=>{
    InitialTennisGame();
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
    GivenServerScore(1);
    ScoreShouldBe("Fifteen Love");    
  });

  it('2-0 Should Be Thirty Love', ()=>{
    GivenServerScore(2);
    ScoreShouldBe("Thirty Love");    
  });

  it('3-0 Should Be Forty Love', ()=>{
    GivenServerScore(3);
    ScoreShouldBe("Forty Love");    
  });
});

describe('WinState', function() {
  beforeEach(()=>{
    InitialTennisGame();
  });

  it('4-0 Should Be Jon Win', ()=>{
    GivenServerScore(4);
    ScoreShouldBe("Jon Win");    
  });

  it('0-4 Should Be Neo Win', ()=>{
    GivenReceiverScore(4)
    ScoreShouldBe("Neo Win");    
  });
});

function InitialTennisGame() {
  tennis = new Tennis("Jon","Neo");
}

function GivenServerScore(times:number) {
  for (let i = 0; i < times; i++) {
    tennis.ServerScore();
  }
}

function ScoreShouldBe(expected:string) {
  expect(expected).equal(tennis.Score());
}

function GivenReceiverScore(times:number) {
  for (let i = 0; i < times; i++) {
    tennis.ReceiverScore();
  }
}
