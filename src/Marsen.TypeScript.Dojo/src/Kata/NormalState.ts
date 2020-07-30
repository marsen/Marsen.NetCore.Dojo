import { WinState } from "./WinState";
import { State } from "./State";
import { SameState } from "./SameState";
import { DeuceState } from "./DeuceState";

export class NormalState extends State {
    ChangeState() {
        if (this.IsSame()) {
            this.Context.State = this.Context.ServerPoint < 3 ? new SameState() : new DeuceState();        
        }

        if (this.IsWin()) {
            this.Context.State = new WinState();
        }
    }

    private IsWin() {
        return this.Context.ServerPoint > 3 || this.Context.ReceiverPoint > 3;
    }

    Score(): string {
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} ${this.ScoreLookup.get(this.Context.ReceiverPoint)}`;
    }
}
