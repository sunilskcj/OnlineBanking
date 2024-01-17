import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { passwordValidator } from '../customvalidators/password-validators';
import { LoginCredentials } from '../Models/loginCredentials';
import { TokenInfo } from '../Models/TokenInfo';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  Logininfo:FormGroup=this._Li.group({
    customerId:['',[Validators.required]],
    netBankingPassword:['',[Validators.required,
                   passwordValidator(6,15)]]
  })

  choice = 0
  constructor(private router: Router,private Route: ActivatedRoute,
    private _Li:FormBuilder, private _ls : LoginService) { }
  ngOnInit(): void {
  }
  saveSelection(choice: number) {
    this.choice = choice
  }

  
err = ""
  
  login() {
    switch (this.choice) {
      case 1:
        const Credentials = <LoginCredentials>this.Logininfo.value
        console.log(Credentials);
        
        this._ls.loginuser(Credentials)
        .subscribe({
          error : (err) => {this.err = err.statusText; console.log(err)}
          ,
          complete : () =>{
             if (this.Route.snapshot.queryParams['returnUrl']) {
            const returnUrl = this.Route.snapshot.queryParams['returnUrl']
            this.router.navigate([returnUrl])
          } else {
            this.router.navigate([`/user/dash/${Credentials.customerId}`])}
            sessionStorage.setItem("cred", Credentials.customerId.toString())
          }
       
        })
        break;

      case 2:
        const AdminCredentials = <LoginCredentials>this.Logininfo.value
        console.log(AdminCredentials);
        this._ls.loginadmin(AdminCredentials)
        .subscribe({
          next : (TokenInfo : TokenInfo) => sessionStorage.setItem("token", TokenInfo.token) ,
          error : (err) => {this.err = err.statusText; console.log(err);
          },
          complete : () =>{
             if (this.Route.snapshot.queryParams['returnUrl']) {
            const returnUrl = this.Route.snapshot.queryParams['returnUrl']
            this.router.navigate([returnUrl])
          } else {
            this.router.navigate(['/admin/reqaccounts'])}}
       
        })
           
       
        
        break;
    }
  }
}
