import { Component, OnInit } from '@angular/core';
import { Lobby } from './lobby.model';
import { DataService } from './data.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-lobbies',
  templateUrl: './lobbies.component.html',
  styleUrls: ['./lobbies.component.css']
})
export class LobbiesComponent implements OnInit {
  data: Lobby[];
  selectedItem: Lobby;

  constructor(private dataService: DataService, private router:Router) { 
    this.data=this.dataService.getData();
  }
  joinClick(e){ 
    this.router.navigateByUrl('/cool');
  }
  ngOnInit() {
  }

}
