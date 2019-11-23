
export class Room{
    id: number;
    date: string;
    game: string;
    constructor(hid:number, hdate:Date, hgame:string )
    {
        this.id= hid;
        this.date= hdate.toString();
        this.game=hgame;
    }
}