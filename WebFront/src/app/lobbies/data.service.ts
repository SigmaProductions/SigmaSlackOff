import { Injectable } from '@angular/core';
import { range } from 'rxjs';
import { DxRangeSliderComponent } from 'devextreme-angular';
import { HttpClient } from "@angular/common/http"
import { Room } from '../models/room.model';

@Injectable()
export class DataService{
    constructor(private httpClient: HttpClient){}

    createRandom(){
        let randoms: Room[];
        randoms=[];
        for(var i=0; i<10; i++){
            var lobb= new Room();
            lobb.game="dfd";
            randoms.push(lobb);
        }
        return randoms;
    }

    getData(){
        return this.httpClient.get<Array<Room>>("https://localhost:5001/api/Room/getrooms");
        
    }
}