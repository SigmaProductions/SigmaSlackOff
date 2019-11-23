import { Injectable } from '@angular/core';
import { range } from 'rxjs';
import { DxRangeSliderComponent } from 'devextreme-angular';
import { HttpClient } from "@angular/common/http"
import { Room } from '../models/room.model';

@Injectable()
export class DataService{
    constructor(private httpClient: HttpClient){}

    getData(){
        return this.httpClient.get<Array<Room>>("https://localhost:5001/api/Room/getrooms");
        
    }
}