import { WinState } from "./WinState";
import { State } from "./State";
import { SameState } from "./SameState";
import { DeuceState } from "./DeuceState";

export class NormalState extends State {
    ChangeState() {
        this.Context.State = 
            this.IsWin() ? 
                new WinState() :
            this.IsDeuce() ? 
                new DeuceState() : 
            this.IsSame() ?
                new SameState(): 
                new NormalState();        
    }

    private IsDeuce() {
        return this.IsSame() && this.Context.ServerPoint >= 3;
    }

    private IsWin() {
        return this.Context.ServerPoint > 3 || this.Context.ReceiverPoint > 3;
    }

    Score(): string {
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} ${this.ScoreLookup.get(this.Context.ReceiverPoint)}`;
    }
}
