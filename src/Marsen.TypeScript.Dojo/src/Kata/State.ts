import Tennis from "./Tennis";

export abstract class State {
    ScoreLookup: Map<number, string> = new Map([
        [0, "Love"],
        [1, "Fifteen"],
        [2, "Thirty"],
        [3, "Forty"]
    ]);

    Context!: Tennis;

    SetContext(context: Tennis) {
        this.Context = context;
    }


    abstract Score(): string;
    abstract ChangeState(): void;
}
