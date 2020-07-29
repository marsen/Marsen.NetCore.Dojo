export default class Tennis {
    state!: IState;
    ReceiverPoint!: number;
    /**
     *
     */
    constructor() {
       this.state = new SameState();
    }

    ReceiverScore() {
        this.state = new NormalState();
        this.ReceiverPoint++;
    }

    Score(): string{
        return this.state.Score();
    }
} 

interface IState{
  Score()  :string
}

class SameState implements IState{
    Score(): string{
        return "Love All";
    }
}

class NormalState implements IState {
    Score(): string{
        return "Love Fifteen";
    }    
}