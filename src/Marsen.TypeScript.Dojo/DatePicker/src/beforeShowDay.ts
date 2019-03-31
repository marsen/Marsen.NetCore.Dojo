
export default class beforeShowDay {
    static blockDateList:string[] = [];
    static IsShow(date: Date):Array<Boolean> {
        var day = date.getDay();
        var now = this.GetToday();
        if(this.blockDateList.filter(x=>x==date.toLocaleDateString('zh-TW').replace(/\//g,'-')).length > 0){
            return [false];
        }

        if(day==0){
            return [false];
        }
        if(now.getDay()==6){
            return this.RestDays(date,now,3);
        }
        if(now.getDay()==0){
            return this.RestDays(date,now,2);;
        }
        
        if(now.getHours() >= 12){
            ///console.log('date'+date.getDate()+' now '+now.getDate());
            if(now.getDay() == 5 ){
                return this.RestDays(date,now,4);
            }
            return this.RestDays(date,now,2);
        }
        if(now.toDateString()==date.toDateString())   
        {
            return [false];
        }
        return [true]  ;
    }

    private static RestDays(date:Date,now:Date,Days:number){
        const _MS_PER_DAY = 1000 * 60 * 60 * 24;
        var twoDay = new Date(now.toDateString()).valueOf() + Days * _MS_PER_DAY;
        return [date.valueOf()-twoDay>=0];
    }

    private static GetToday(){
        var ms = Date.now();
        return new Date(ms);
    }
}