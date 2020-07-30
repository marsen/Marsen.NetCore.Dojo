import { NormalState } from "./NormalState";
import { State } from "./State";

export class SameState extends State {
    ChangeState() {
        this.Context.state = new NormalState();
    }
    Score(): string {
        return `${this.ScoreLookup.get(this.Context.ServerPoint)} All`;
    }
}
