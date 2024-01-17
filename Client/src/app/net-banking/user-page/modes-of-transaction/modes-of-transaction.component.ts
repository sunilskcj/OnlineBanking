import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccCredential } from '../../Models/AccCredential';
import { ResponseModel } from '../../Models/ResponseModel';
import { AccCredentialService } from '../../services/credential.service';
import { PayeeService } from '../../services/payee.service';
import { TransactionService } from '../../services/transaction.service';
@Component({
  selector: 'app-modes-of-transaction',
  templateUrl: './modes-of-transaction.component.html',
  styleUrls: ['./modes-of-transaction.component.css']
})
export class ModesOfTransactionComponent implements OnInit {

 


ngOnInit(): void {
  this._cs.getAccountCredbyId(this.Cred?.credentialId).subscribe((AccCredential : AccCredential) => {this.Cred = AccCredential ; console.log(AccCredential);})
}


  constructor(private _cs : AccCredentialService,
    private _imps: FormBuilder,
    private _neft: FormBuilder,
    private _rtgs: FormBuilder,
    private router : Router,
    private _Ts : TransactionService){}
Cred? : AccCredential

  IMPSpaymentinfo: FormGroup = this._imps.group({
  
   
    transactionamount: ['', [Validators.required]],
    payeeAccountNumber: ['', [Validators.required]],
    modeId : [1],
    maturityInstruction: ['', [Validators.required]],
    remark: [''],
    payeeMobileNumber : ['']
  })
  NEFTpaymentinfo: FormGroup = this._neft.group({
   
    payeeAccountNumber: ['', [Validators.required]],
    transactionamount: ['', [Validators.required]],
    modeId : [2],
    remark: ['']
  })
  RTGSpaymentinfo: FormGroup = this._rtgs.group({
   
    modeId : [3],
    payeeAccountNumber: ['', [Validators.required]],
    transactionamount: ['', [Validators.required]],

    remark: ['']
  })
  

  save(){
    
    this._Ts.addTransaction(this.IMPSpaymentinfo.value).subscribe(

      {
       next: (data: ResponseModel) => { localStorage.setItem("TransactionrefID", data.response)
        
 
       },
       error: (errresp: HttpErrorResponse) => {
 
        console.log(errresp);
        
       },
       complete: () => { }
     })
  
  }


id : any

  proceedIMPSpay() {
    console.log(this.IMPSpaymentinfo.value);
   
    this._Ts.addTransaction(this.IMPSpaymentinfo.value).subscribe(

     {
      next: (data: ResponseModel) => { this.id = data.response
        localStorage.removeItem("TransactionrefID")
        localStorage.setItem("TransactionrefID", data.response)

      },
      error: (errresp: HttpErrorResponse) => {

       console.log(errresp);
       
      },
      complete: () => {this.router.navigateByUrl(`/user/transaction/verification/${this.id}`); }
    })
 
    
  }

  proceedNEFTpay() {
    console.log(this.NEFTpaymentinfo.value);
   
    this._Ts.addTransaction(this.NEFTpaymentinfo.value).subscribe(

     {
      next: (data: ResponseModel) => { this.id = data.response
        localStorage.removeItem("TransactionrefID");
        localStorage.setItem("TransactionrefID", data.response);
       

      },
      error: (errresp: HttpErrorResponse) => {

       console.log(errresp);
       
      },
      complete: () => {this.router.navigateByUrl(`/user/transaction/verification/${this.id}`); }
    })
 
    
  }
  proceedRTGSSpay() {
    console.log(this.RTGSpaymentinfo.value);
   
    this._Ts.addTransaction(this.RTGSpaymentinfo.value).subscribe(

     {
      next: (data: ResponseModel) => { this.id = data.response ;
       

      },
      error: (errresp: HttpErrorResponse) => {

       console.log(errresp);
       
      },
      complete: () => {this.router.navigateByUrl(`/user/transaction/verification/${this.id}`); }
    })
 
    
  }


}
