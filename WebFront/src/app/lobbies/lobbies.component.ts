import { Component, OnInit, ViewChild } from '@angular/core';
import { Room } from '../models/room.model';
import { DataService } from './data.service';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../login/login.component';
import { DxListComponent } from 'devextreme-angular';
import { userInfo } from 'os';

@Component({
  selector: 'app-lobbies',
  templateUrl: './lobbies.component.html',
  styleUrls: ['./lobbies.component.css']
})
export class LobbiesComponent implements OnInit {
  data: Array<Room>;
  selectedItems: any[]=[];

  constructor(private dataService: DataService, private router:Router, private httpClient: HttpClient) { 
    this.dataService.getData().toPromise().then((val)=>{this.data= val});
  }
  joinClick(e){ 
    var id= (this.selectedItems[0] as Room).id;

    console.log(id);
    this.httpClient.put("https://localhost:5001/api/Room/assignUser"+ "?roomId="+ id.toString()+ 
      "&userId=" + LoginComponent.user.id.toString(), null);
    this.router.navigateByUrl('/cool');
  }
  ngOnInit() {
  }

}
