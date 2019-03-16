import DateHelper from '../src/helper/dateHelper'

export default class beforeShowDay {
    static IsShow(date: Date):Array<Boolean> {
        var day = date.getDay();
        var today = this.GetToday();
        console.log('today is '+today);
        
        if(today.getDay()==5){
            return [false];
        }
        if(today.getHours() >= 12 &&  date.getDate() - today.getDate() < 2 ){
            return [false];
        }

        if(day==0){
            return [false];
        }
        return [true]  ;
    }

    private static GetToday(){
        var ms = Date.now();
        return new Date(ms);
    }
    
  }