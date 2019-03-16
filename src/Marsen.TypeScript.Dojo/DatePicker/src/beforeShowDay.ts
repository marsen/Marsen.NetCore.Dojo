import DateHelper from '../src/helper/dateHelper'

export default class beforeShowDay {
    static IsShow(date: Date):Array<Boolean> {
        var day = date.getDay();
        var today = Date.now();
        console.log(today);
        if(day==0){
            return [false];
        }
        return [true]  ;
    }

    
  }