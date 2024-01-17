import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { ConfirmedValidator } from '../customvalidators/confirm-password';
import { passwordValidator } from '../customvalidators/password-validators';
import { AccCredential } from '../Models/AccCredential';
import { Account } from '../Models/Account';
import { ResponseModel } from '../Models/ResponseModel';
import { AccCredentialService } from '../services/credential.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private fb : FormBuilder, private route : Router, private _cs : AccCredentialService) { }

  registration:FormGroup= this.fb.group({
    AccountNumber : ['',[Validators.required]],
    SetLoginPassword:['',[Validators.required,
                          passwordValidator(6,10)]],
    ConfirmLoginPassword:['',[Validators.required,passwordValidator(6,10)]],
    SetTransactionPassword:['',[Validators.required,
                                passwordValidator(6,10)]],
    ConfirmTransactionPassword:['',[Validators.required,ConfirmedValidator,passwordValidator(6,10)]]                            
  })


  ngOnInit(): void {
  }
  submitData() {
    
    
    
    const cred = <AccCredential>(this.registration.value)

    const ObservableAccount: Observable<ResponseModel> = this._cs.updateAccount(cred);

    const observerObj: Observer<ResponseModel> = {
      next: (data: ResponseModel) => {
        console.log(data)

      },
      error: (errresp: HttpErrorResponse) => {

       console.log(errresp)
      },
      complete: () => { this.route.navigateByUrl('login')}
    };
    ObservableAccount.subscribe(observerObj)

  }
}
