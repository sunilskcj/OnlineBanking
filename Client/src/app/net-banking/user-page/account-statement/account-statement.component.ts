
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from '../../Models/Account';

import { AccountService } from '../../services/account.service';


@Component({
  selector: 'app-account-statement',
  templateUrl: './account-statement.component.html',
  styleUrls: ['./account-statement.component.css']
})
export class AccountStatementComponent implements OnInit {

  Account? : Account
  
  constructor(private _as : AccountService, private route : ActivatedRoute) { }

  ngOnInit(): void {
   
    const ObservableAccount : Observable<Account> = this._as.getAccountbyId(this.Account?.customerId)
    ObservableAccount.subscribe(
      (Accounts : Account) => this.Account = Accounts )
     
  }

}
