import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from '../../Models/Account';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-requested-account',
  templateUrl: './requested-account.component.html',
  styleUrls: ['./requested-account.component.css']
})
export class RequestedAccountComponent implements OnInit {

  Accounts? : Account[]  
 

  getAccountDetail(id : number){
  
      this.route.navigateByUrl(`/admin/reqaccount/${id}`)
  }
  constructor(private _as : AccountService , private route : Router) { }
  
  ngOnInit(): void {

    const ObservableAccount : Observable<Account[]> = this._as.getAccountbystatus("Requested")
    ObservableAccount.subscribe(
      (Accounts : Account[]) => this.Accounts = Accounts
    )

  }

}
