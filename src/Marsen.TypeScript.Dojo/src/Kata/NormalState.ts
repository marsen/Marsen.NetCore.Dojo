import { WinState } from "./WinState";
import { State } from "./State";
import { SameState } from "./SameState";
import { DeuceState } from "./DeuceState";

export class NormalState extends State {
    ChangeState() {

        if (this.IsSame()) {

            if(this.Context.ServerPoint<3){
                this.Context.State = new SameState();
            }else{
                this.Context.State = new DeuceState();
            }
        }

        if (this.Context.ServerPoint > 3 || this.Context.ReceiverPoint > 3) {
            this.Context.State = new WinState();
        }
    }


    Score(): string {
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} ${this.ScoreLookup.get(this.Context.ReceiverPoint)}`;
    }
}
