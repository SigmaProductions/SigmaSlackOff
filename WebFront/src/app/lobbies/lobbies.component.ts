import { Component, OnInit } from '@angular/core';
import { Lobby } from './lobby.model';
import { DataService } from './data.service';

@Component({
  selector: 'app-lobbies',
  templateUrl: './lobbies.component.html',
  styleUrls: ['./lobbies.component.css']
})
export class LobbiesComponent implements OnInit {
  data: Lobby[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.data=this.dataService.getData();
  }

}
