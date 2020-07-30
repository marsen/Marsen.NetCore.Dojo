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
        this.ChangeState();
    }

    private ChangeState() {
        this.state = new SameState();
        if (this.ServerPoint != this.ReceiverPoint) {
            this.state = new NormalState();
        }
        this.state.SetContext(this);
    }

    ReceiverScore() {
        this.ReceiverPoint++;
        this.ChangeState();
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
        const scoreLookup: Map<number,string> = new Map([
            [0,"Love"],
            [1,"Fifteen"],
            [2,"Thirty"],
            [3,"Forty"]
        ]);
        if(this.Context.ServerPoint == 2){
            return `${scoreLookup.get(2)} All`;
            return "Forty All";
        }
        if(this.Context.ServerPoint == 1){
            return `${scoreLookup.get(1)} All`;
            return "Fifteen All";
        }
        return `${scoreLookup.get(0)} All`;
        return "Love All";
    }
}

class NormalState extends State {
        
    Score(): string{
        const scoreLookup: Map<number,string> = new Map([
            [0,"Love"],
            [1,"Fifteen"],
            [2,"Thirty"],
            [3,"Forty"]
        ]);
        
        return `${scoreLookup.get(this.Context.ServerPoint)} ${scoreLookup.get(this.Context.ReceiverPoint)}`;
    }    
}