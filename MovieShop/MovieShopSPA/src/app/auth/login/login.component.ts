import { Component, OnInit } from '@angular/core';
import {Login} from'src/app/shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //2 way binding: angular js
  //1 way binding: 
  userLogin: Login={
    email:'',
    password:''
  };

  constructor() { }

  ngOnInit(): void {
  }
  login(){
    console.log('button was clicked');
  }
}
