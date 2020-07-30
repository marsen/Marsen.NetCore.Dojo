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
        this.state.ChangeState();
        this.state.SetContext(this);
    }

    ReceiverScore() {
        this.ReceiverPoint++;
        this.state.ChangeState();
        this.state.SetContext(this);
    }

    Score(): string{
        return this.state.Score();
    }
} 

abstract class State{
    ChangeState() {}
    ScoreLookup: Map<number,string> = new Map([
        [0,"Love"],
        [1,"Fifteen"],
        [2,"Thirty"],
        [3,"Forty"]
    ]);

    Context!: Tennis;

    SetContext(context: Tennis) {
        this.Context = context;
    }  

    abstract Score()  :string
}

class SameState extends State{
    ChangeState() {
                  this.Context.state = new SameState();
        if (this.Context.ServerPoint != this.Context.ReceiverPoint) {
            this.Context.state = new NormalState();
        }
    }
    Score(): string{        
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} All`;
    }
}

class NormalState extends State {
    
    ChangeState() {
        this.Context.state = new NormalState();
        if (this.Context.ServerPoint == this.Context.ReceiverPoint) {
            this.Context.state = new SameState();
            //this.Context.state = new NormalState();
        }

    }
    Score(): string{
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} ${this.ScoreLookup.get(this.Context.ReceiverPoint)}`;
    }    
}