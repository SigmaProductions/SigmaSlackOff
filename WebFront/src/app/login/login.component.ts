import { Component, OnInit } from '@angular/core';
import { User } from './user';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userNickname="";
  userPassword="";
  login(e){ 
    console.log("dziala");
  }

  user:User;
  constructor() { 

  }


  ngOnInit() {
  }

}
