import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Observer } from 'rxjs';
import { Account } from '../../Models/Account';
import { ResponseModel } from '../../Models/ResponseModel';
import { AccountService } from '../../services/account.service';
import { PayeeService } from '../../services/payee.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Payee } from '../../Models/Payee';
import { AccCredentialService } from '../../services/credential.service';
import { AccCredential } from '../../Models/AccCredential';
@Component({
  selector: 'app-payee',
  templateUrl: './payee.component.html',
  styleUrls: ['./payee.component.css']
})
export class PayeeComponent implements OnInit {

  PayeeId = 0

  Beneficiaryinfo: FormGroup = this._bfi.group({
    payeeName: ['', [Validators.required]],
    payeeAccountNumber: ['', [Validators.required]],
    nickName: ['']
  })

  Account?: Account
  PayeeAccount?: Payee[]
  Cred? : AccCredential

  constructor(private _bfi: FormBuilder,
   
    private _as: AccountService,
    private route: ActivatedRoute,
    private _ps: PayeeService,
    private router: Router,
    private _cs : AccCredentialService,
    private _Li: FormBuilder) { }



  ngOnInit(): void {
    this._as.getAccountbyId(this.Account?.customerId).subscribe(
      {next : (Accounts : Account) =>{ this.Account = Accounts;
        console.log(Accounts);
        
        
       }, 
      error : (err) => console.log(err),
      complete : () => {
       
      }
      
      }
    )
   
     
     


    const ObservablePayeeAccount: Observable<Payee[]> = this._ps.getAllPayee()
    ObservablePayeeAccount.subscribe(
      (Accounts: Payee[]) => this.PayeeAccount = Accounts)



  }


  navigatepay(){this.router.navigateByUrl("/user/transaction/mode")}


  errorMessage?: string;
  succes? : string;
  submitData() {
    console.log(this.Beneficiaryinfo.value)
   


    const ObservableAccount: Observable<ResponseModel> = this._ps.addPayee(this.Beneficiaryinfo.value)

    const observerObj: Observer<ResponseModel> = {
      next: (data: ResponseModel) => {
        console.log(data)
        if (data.response){this.succes = "Payee Added Succedfully"
        }
        
      },
      error: (errresp: HttpErrorResponse) => {

        this.errorMessage = errresp.message
      },
      complete: () => { }
    };
    ObservableAccount.subscribe(observerObj)

  }

 
  reload(){
    window.location.reload();
  }

}
