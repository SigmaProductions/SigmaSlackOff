import { Injectable } from '@angular/core';
import { range } from 'rxjs';
import { Lobby } from './lobby.model';
import { DxRangeSliderComponent } from 'devextreme-angular';

@Injectable()
export class DataService{
    createRandom(){
        let randoms: Lobby[];
        randoms=[];
        for(var i=0; i<10; i++){
            var lobb= new Lobby();
            lobb.game="dfd";
            lobb.name="daD";
            randoms.push(lobb);
        }
        return randoms;
    }

    getData(){
        return this.createRandom();
    }
}