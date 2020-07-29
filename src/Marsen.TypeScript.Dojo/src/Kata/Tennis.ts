export default class Tennis {
    state!: State;
    ReceiverPoint: number = 0;
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
        this.ReceiverPoint++;
        this.state = new NormalState();
        this.state.SetContext(this);
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
        console.log("normal state score",this.Context);
        if(this.Context.ReceiverPoint == 2){
            return "Love Thirty";
        }
        return "Love Fifteen";
    }    
}