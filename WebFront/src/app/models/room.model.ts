import { empty } from 'rxjs';

export class Room{
    id: number;
    date: string;
    game: string;
    numPl:number;
    constructor(hid:number, hdate:Date, hgame:string )
    {
        this.id= hid;
        this.date= hdate.toString();
        
        this.numPl= Math.random();

        if (this.date == ""){
            this.date = new Date(Date.now() + Math.random() ).toString()
        }
        console.log(this.date);
    }
}