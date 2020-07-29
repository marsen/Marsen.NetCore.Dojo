export default class Tennis {
    state!: State;
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

abstract class State{
    Context!: Tennis;
    SetContext(context: Tennis) {
        this.Context = context;
    }  
    abstract Score()  :string
}

class SameState extends State{
    
    Score(): string{        
        if(this.Context.ServerPoint == 1){
            return "Fifteen All";
        }
        return "Love All";
    }
}

class NormalState extends State {
        
    Score(): string{
        return "Love Fifteen";
    }    
}