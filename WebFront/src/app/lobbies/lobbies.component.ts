import { Component, OnInit, ViewChild } from '@angular/core';
import { Room } from '../models/room.model';
import { DataService } from './data.service';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../login/login.component';
import { User } from '../login/user';
import { DxListComponent } from 'devextreme-angular';

@Component({
  selector: 'app-lobbies',
  templateUrl: './lobbies.component.html',
  styleUrls: ['./lobbies.component.css']
})
export class LobbiesComponent implements OnInit {
  data: Array<Room>;
  selectedItems: Room;

  constructor(private dataService: DataService, private router:Router, private httpClient: HttpClient) { 
    this.dataService.getData().toPromise().then((val)=>{this.data= val});
  }
  joinClick(e){ 
    this.httpClient.put("https://localhost:5001/api/Room/assignUser",
        {roomId: this.selectedItems.id, userId : User.Username});
    this.router.navigateByUrl('/cool');
  }
  ngOnInit() {
    this.selectedItems = new Room();
  }

}
