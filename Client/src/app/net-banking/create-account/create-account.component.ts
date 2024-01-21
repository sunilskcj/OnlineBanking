import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { LengthValidator } from '../customvalidators/length-validators';
import { passwordValidator } from '../customvalidators/password-validators';
import { Account } from '../Models/Account';
import { ResponseModel } from '../Models/ResponseModel';
import { AccountService } from '../services/account.service';

@Component(
  {
    selector: 'app-create-account',
    templateUrl: './create-account.component.html',
    styleUrls: ['./create-account.component.css']
  })

export class CreateAccountComponent implements OnInit {

  Response?: ResponseModel


  Accountinfo: FormGroup = this._ai.group({
   
    title: ['', [Validators.required]],
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    middleName: [''],
    mobileno: ['', [Validators.required,
    passwordValidator(10, 12)]],
    emailId: ['', [Validators.required,
    Validators.email]],
    aadhaarCardNumber: ['', [Validators.required
   ]],
    dob: [''],
    residentialAddressLine1: [''],
    residentialAddressLine2: [''],
    residentialLandmark: [''],
    residentialState: ['', [Validators.required]],
    residentialCity: ['', [Validators.required]],
    residentialPincode: ['', [Validators.required]],
    permanentAddressLine1: [''],
    permanentAddressLine2: [''],
    permanentLandmark: [''],
    permanentState: ['', [Validators.required]],
    permanentCity: ['', [Validators.required]],
    permanentPincode: ['', [Validators.required]],
    occupationdetails: ['', [Validators.required]],
    occupationType: ['', [Validators.required]],
    sourceofincome: ['', [Validators.required]],
    grossAnnualIncome: ['', [Validators.required]],
    Netcheckbox:['']
   


  })
  errorMessage?: string;
  constructor(private _ai: FormBuilder, private _as: AccountService, private route : Router) { }
  ngOnInit(): void {

  }
  submitData() {
    
    let accdata = <Account>this.Accountinfo.value
    
    

    const ObservableAccount: Observable<ResponseModel> = this._as.addAccount(accdata)

    const observerObj: Observer<ResponseModel> = {
      next: (data: ResponseModel) => {
        console.log(data)

      },
      error: (errresp: HttpErrorResponse) => {

        this.errorMessage = errresp.message
      },
      complete: () => { this.route.navigateByUrl('CreateAccount/success')}
    };
    ObservableAccount.subscribe(observerObj)

  }


}
