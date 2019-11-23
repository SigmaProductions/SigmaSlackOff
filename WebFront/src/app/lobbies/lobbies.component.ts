import { Component, OnInit, ViewChild } from '@angular/core';
import { Room } from '../models/room.model';
import { DataService } from './data.service';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../login/login.component';
import { DxListComponent } from 'devextreme-angular';
<<<<<<< HEAD

=======
>>>>>>> 51422d44b3dd73b7f54fab68f6fd3c0df47a1088

@Component({
  selector: 'app-lobbies',
  templateUrl: './lobbies.component.html',
  styleUrls: ['./lobbies.component.css']
})
export class LobbiesComponent implements OnInit {
  data: Array<Room>;

  constructor(private dataService: DataService, private router:Router, private httpClient: HttpClient) { 
    this.dataService.getData().toPromise().then((val)=>{this.data= val});
  }
  joinClick(e){ 
    var id=""
    this.httpClient.put("https://localhost:5001/api/Room/assignUser"+ "?roomId="+ id.toString()+ 
      "&userId=" + LoginComponent.user.id.toString(), null);
    this.router.navigateByUrl('/cool');
  }

  onSelectionChanged(c){
    console.log(c)
  }

  ngOnInit() {
  }

}
