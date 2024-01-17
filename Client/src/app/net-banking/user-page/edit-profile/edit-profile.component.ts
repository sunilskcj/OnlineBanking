import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { Account } from '../../Models/Account';
import { ResponseModel } from '../../Models/ResponseModel';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  Editprofile:FormGroup=this._ep.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    middleName: [''],
    mobileno: ['', [Validators.required]],
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
    grossAnnualIncome: ['', [Validators.required]]
  })


  errorMessage?: string;
  succes: any;

  constructor(private _ep:FormBuilder, private _as : AccountService , private route : Router) { }

  ngOnInit(): void {
  }

  updatedata(){
  
    
      let accdata = <Account>this.Editprofile.value
      
      
  
      const ObservableAccount: Observable<ResponseModel> = this._as.updateAccount(accdata)
  
      const observerObj: Observer<ResponseModel> = {
        next: (data: ResponseModel) => {
          console.log(data)
          if (data.response = true) {this.succes = "Details updated Succesfully" }
  
        },
        error: (errresp: HttpErrorResponse) => {
  
          this.errorMessage = errresp.message
        },
        complete: () => {   }
      };
      ObservableAccount.subscribe(observerObj)
  

    
  }

  navigateProfile(){this.route.navigateByUrl("/user/profile")}
}
