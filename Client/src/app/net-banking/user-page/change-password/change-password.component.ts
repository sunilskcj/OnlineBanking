import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  ForgetUserID:FormGroup=this._fb.group({
    AccountNumber:[''],
    otp:['']
  })
  ForgetPassword:FormGroup=this._fb.group({
    userID:[''],
    otp:['']
  })
  NewPassword:FormGroup=this._fb.group({
    loginpassword:[''],
    confirmloginpassword:['']
  })
  TransPassword:FormGroup=this._fb.group({
    loginpassword:[''],
    confirmloginpassword:[''],
    transactionpassword:[''],
    confirmtransactionpassword:['']
  })

  constructor(private _fb :FormBuilder) { }
  submit(){}
  ngOnInit(): void {
  }

}
