import { State } from "./State";
import { AdvState } from "./AdvState";

export class DeuceState extends State {
    Score(): string {
        return "Deuce";
    }
    ChangeState(): void {
        this.Context.State = new AdvState();

    }
}
