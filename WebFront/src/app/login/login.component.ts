import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userNickname="";
  userPassword="";
  static user: User;

  login(e){ 
    this.httpClient.get("https://localhost:5001/api/User/login"+ "?username=" + this.userNickname+ '&pw='
      + this.userPassword).subscribe((us: User)=> {
        LoginComponent.user= us;
        this.router.navigateByUrl('/test');
      }, 
      (err)=>{ console.log(err) });
    
  }
  constructor(private router:Router, private httpClient: HttpClient) { 

  }


  ngOnInit() {
  }

}
