import { SameState } from "./SameState";
import { State } from "./State";

export default class Tennis {
    State!: State;
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
        this.State = new SameState();        
        this.State.SetContext(this);
    }
    
    ServerScore() {
        this.ServerPoint++;
        this.State.ChangeState();
        this.State.SetContext(this);
    }

    ReceiverScore() {
        this.ReceiverPoint++;
        this.State.ChangeState();
        this.State.SetContext(this);
    }

    Score(): string{
        return this.State.Score();
    }
} 
