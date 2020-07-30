import { WinState } from "./WinState";
import { State } from "./State";
import { SameState } from "./SameState";
export class NormalState extends State {
    ChangeState() {

        if (this.Context.ServerPoint == this.Context.ReceiverPoint) {

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
class DeuceState extends  State{
    Score(): string {
        return "Deuce";
    }
    ChangeState(): void {
        throw new Error("Method not implemented.");
    }
}