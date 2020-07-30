import { SameState } from "./SameState";
import { State } from "./State";

export default class Tennis {
    state!: State;
    ReceiverPoint: number = 0;
    ServerPoint: number = 0;
    ServerName: string;
    ReceiverName: string;
    /**
     *
     */
    constructor(serverName:string,receiverName:string) {
        this.ServerName = serverName;
        this.ReceiverName = receiverName;
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


