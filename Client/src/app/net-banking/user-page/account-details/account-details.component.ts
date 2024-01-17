import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from '../../Models/Account';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {

  Account? : Account
  constructor(private router : Router ,private _as : AccountService, private route : ActivatedRoute ) { }

  ngOnInit(): void {
   
    const ObservableAccount : Observable<Account> = this._as.getAccountbyId(this.Account?.customerId)
    ObservableAccount.subscribe(
      (Accounts : Account) => this.Account = Accounts )
  }
  navigate(){
    
    this.router.navigateByUrl(`/user/editprofile`);
  }
}
