
export default class beforeShowDay {
    static IsShow(date: Date):Array<Boolean> {
        var day = date.getDay();
        var now = this.GetToday();
        const _MS_PER_DAY = 1000 * 60 * 60 * 24;
        if(day==0){
            return [false];
        }
        
        if(now.getHours() >= 12){
            console.log('date'+date.getDate()+' now '+now.getDate());
            if(now.getDay() == 5 ){
                var fourDay =new Date(now.toDateString()).valueOf() + 4 * _MS_PER_DAY;
                return [date.valueOf()-fourDay>=0];
            }

            var twoDay = new Date(now.toDateString()).valueOf() + 2 * _MS_PER_DAY;
            return [date.valueOf()-twoDay>=0];
        }    
        return [true]  ;
    }

    private static GetToday(){
        var ms = Date.now();
        return new Date(ms);
    }
}