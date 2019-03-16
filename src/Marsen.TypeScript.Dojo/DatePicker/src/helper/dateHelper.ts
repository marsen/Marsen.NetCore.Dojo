export default class DateHelper {

    private static _today : Date;

     static GetToday():Date{
        if(!this._today) 
            return new Date();
        return this._today;
    }

     static SetToday(date:Date){
        
    }    
} 