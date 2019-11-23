import { Component, OnInit } from '@angular/core';
import { User } from './user';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userNickname="";
  userPassword="";
  login(e){ 
    this.httpClient.get("https://localhost:5001/api/User/login",
    {"id":this.userNickname, "pw": this.userPassword});
    this.router.navigateByUrl('/test');
    
  }

  user:User;
  constructor(private router:Router, private httpClient: HttpClient) { 

  }


  ngOnInit() {
  }

}
