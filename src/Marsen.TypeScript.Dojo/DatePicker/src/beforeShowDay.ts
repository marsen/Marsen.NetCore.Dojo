
export default class beforeShowDay {
    static IsShow(date: Date):Array<Boolean> {
        var day = date.getDay();
        var today = this.GetToday();
        
        if(today.getHours() >= 12){
            console.log('date'+date.getDate()+' today '+today.getDate());
            if(today.getDay() == 5 && this.DiffDate(date,today)< 4){
                return [false];
            } 

            if(this.DiffDate(date,today) < 2){
                console.log(date);
                console.log(today);
                console.log(this.DiffDate(date,today));
                return [false];
            }
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

    private static DiffDate(date1:Date,date2:Date):number{
        //// 台灣 UTC+8
        const _TIMEZONE_BUFFER = 1000 * 60  * 60 * 8;
        const _MS_PER_DAY = 1000 * 60 * 60 * 24;
        var diffMilliseconds =date1.valueOf() - date2.valueOf() + _TIMEZONE_BUFFER + _TIMEZONE_BUFFER;
        return Math.floor(diffMilliseconds / _MS_PER_DAY);
    }
    
}