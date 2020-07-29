export default class Tennis {
    Score(): string{
        var state = new SameState();
        return state.Score();
    }
} 

class SameState{
    Score(): string{
        return "Love All";
    }

}