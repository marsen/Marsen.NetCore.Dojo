export default class Tennis {
    state!: IState;
    ReceiverPoint!: number;
    ServerPoint: number = 0;
    /**
     *
     */
    constructor() {
        this.state = new SameState();        
        this.state.SetContext(this);
    }
    
    ServerScore() {
        this.ServerPoint++;
        this.state = new SameState();
        this.state.SetContext(this);
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
  SetContext(context: Tennis):void
  Score()  :string
}

class SameState implements IState{
    Context!: Tennis;
    SetContext(context: Tennis) {
        this.Context = context;
    }
    Score(): string{        
        if(this.Context.ServerPoint == 1){
            return "Fifteen All";
        }
        return "Love All";
    }
}

class NormalState implements IState {
    Context!: Tennis;
    SetContext(context: Tennis) {
        this.Context = context;
    }
    
    Score(): string{
        return "Love Fifteen";
    }    
}