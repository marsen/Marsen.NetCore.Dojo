import { State } from "./State";
export class WinState extends State {
    Score(): string {
        if (this.Context.ServerPoint > this.Context.ReceiverPoint)
            return `${this.Context.ServerName} Win`;
        return `${this.Context.ReceiverName} Win`;
    }

    ChangeState(): void {
        throw new Error("Method not implemented.");
    }
}
