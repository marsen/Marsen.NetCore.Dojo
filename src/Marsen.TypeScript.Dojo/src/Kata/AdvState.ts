import { WinState } from "./WinState";
import { State } from "./State";
import { DeuceState } from "./DeuceState";
export class AdvState extends State {
    Score(): string {
        return `${this.Winner()} Adv`;
    }

    ChangeState(): void {
        if (this.IsSame()) {
            this.Context.State = new DeuceState();
        }
        else {
            this.Context.State = new WinState();
        }
    }
}
