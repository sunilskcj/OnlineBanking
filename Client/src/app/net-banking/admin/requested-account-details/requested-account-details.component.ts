import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { Account } from '../../Models/Account';
import { ResponseModel } from '../../Models/ResponseModel';
import { AccountService } from '../../services/account.service';
import { AccCredentialService } from '../../services/credential.service';

@Component({
  selector: 'app-requested-account-details',
  templateUrl: './requested-account-details.component.html',
  styleUrls: ['./requested-account-details.component.css']
})
export class RequestedAccountDetailsComponent implements OnInit {

  constructor(private _as : AccountService,private _cs : AccCredentialService, private route : ActivatedRoute ) { }
  Account? : Account
  
  ngOnInit(): void {

    let fromRoute =  this.route.snapshot.params['customerId'];
    
  console.log(fromRoute);
  
  this._as.getAccountbyIdAdmin(fromRoute).subscribe(
    (Accounts : Account) => this.Account = Accounts )
  }

approve(){
  const ObservableAccount: Observable<ResponseModel> = this._cs.addAccountCred(this.Account?.customerId)

  const observerObj: Observer<ResponseModel> = {
    next: (data: ResponseModel) => {
      console.log(data)

    },
    error: (errresp: HttpErrorResponse) => {

      console.log( errresp.message);
      
    },
    complete: () => { }
  };
  ObservableAccount.subscribe(observerObj)

}

deny(){
  const ObservableDeleteAccount: Observable<ResponseModel> = this._as.deleteAccount(this.Account?.customerId)

  const observerObj: Observer<ResponseModel> = {
    next: (data: ResponseModel) => {
      console.log(data)

    },
    error: (errresp: HttpErrorResponse) => {

      console.log( errresp.message);
      
    },
    complete: () => { }
  };
  ObservableDeleteAccount.subscribe(observerObj)
}


}
