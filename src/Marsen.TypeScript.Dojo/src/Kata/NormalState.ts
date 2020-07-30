import { WinState } from "./WinState";
import { State } from "./State";
import { SameState } from "./SameState";
export class NormalState extends State {
    ChangeState() {

        if (this.Context.ServerPoint == this.Context.ReceiverPoint) {
            this.Context.State = new SameState();
        }

        if (this.Context.ServerPoint > 3 || this.Context.ReceiverPoint > 3) {
            this.Context.State = new WinState();
        }
    }

    Score(): string {
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} ${this.ScoreLookup.get(this.Context.ReceiverPoint)}`;
    }
}
