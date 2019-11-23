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
  user: User;

  login(e){ 
    this.httpClient.get("https://localhost:5001/api/User/login"+ "?username=" + this.userNickname+ '&pw='
      + this.userPassword).subscribe((us)=> {
        this.user= us;
        this.router.navigateByUrl('/test');
      }, 
      (err)=>{ console.log(err) });
    
  }
  constructor(private router:Router, private httpClient: HttpClient) { 

  }


  ngOnInit() {
  }

}
