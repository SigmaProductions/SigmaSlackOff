import { Component, OnInit } from '@angular/core';
import { User } from './user';
import {Router} from '@angular/router';


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
    this.router.navigateByUrl('/test');
    
  }

  user:User;
  constructor(private router:Router) { 

  }


  ngOnInit() {
  }

}
