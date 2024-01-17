import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from '../../Models/Account';
import { AccountService } from '../../services/account.service';
import { TransactionService } from '../../services/transaction.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Transaction } from '../../Models/Transaction';
@Component({
  selector: 'app-account-summary',
  templateUrl: './account-summary.component.html',
  styleUrls: ['./account-summary.component.css']
})
export class AccountSummaryComponent implements OnInit {
Account? : Account
  constructor(private _as : AccountService, private route : Router, private _Ts : TransactionService) { }
  data? : Transaction[]
  ngOnInit(): void {
    
    const ObservableAccount : Observable<Account> = this._as.getAccountbyId(this.Account?.customerId)
    ObservableAccount.subscribe(
      (Accounts : Account) => {this.Account = Accounts; console.log(Accounts); })
      
      this._Ts.getAllTransaction().subscribe(
  
        {
         next: (data: Transaction[]) => this.data = data 
          
   
         ,
         error: (errresp: HttpErrorResponse) => {
   
          console.log(errresp);
          
         },
         complete: () => {}
       })
      
  }

  navigateverify(id : number){
    this.route.navigateByUrl(`user/transaction/verification/${id}`)
  }

}
