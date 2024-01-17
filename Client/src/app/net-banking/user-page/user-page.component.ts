import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from '../Models/Account';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  Account? : Account
  
  constructor(private _as : AccountService, private route : ActivatedRoute  ) { }

  ngOnInit(): void {

    
    
    const ObservableAccount : Observable<Account> = this._as.getAccountbyId(this.Account?.customerId)
    ObservableAccount.subscribe(
      (Accounts : Account) => this.Account = Accounts )
  }

}
