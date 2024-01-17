import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {  ActivatedRoute, Router } from '@angular/router';
import { ResponseModel } from '../../Models/ResponseModel';
import { Transaction } from '../../Models/Transaction';
import { TransactionService } from '../../services/transaction.service';

@Component({
  selector: 'app-transaction-verification',
  templateUrl: './transaction-verification.component.html',
  styleUrls: ['./transaction-verification.component.css']
})
export class TransactionVerificationComponent implements OnInit {

  constructor(private router : Router,private activeRoute : ActivatedRoute,private _Ts : TransactionService, private _imps : FormBuilder) { }
  IMPSpaymentinfo: FormGroup = this._imps.group({
  
   
    transactionamount: ['', [Validators.required]],
    payeeAccountNumber: ['', [Validators.required]],
    modeId : [1],
    maturityInstruction: ['', [Validators.required]],
    remark: ['']
  })

  data? : Transaction
  

  
  ngOnInit(): void {
    
    const reffid = this.activeRoute.snapshot.params["customerId"]

   
    
         
    this._Ts.getTransactionbyId(reffid).subscribe(

      {
       next: (data: Transaction) => this.data = data 
        
 
       ,
       error: (errresp: HttpErrorResponse) => {
 
        console.log(errresp);
        
       },
       complete: () => {}
     })
    
  }
  proceed(){
console.log(this.data?.transactionReferenceId);

    this._Ts.proceedTransaction(this.data?.transactionReferenceId).subscribe(

      {
       next: (data: ResponseModel) => console.log(data) ,
        
 
       
       error: (errresp: HttpErrorResponse) => {
 
        console.log(errresp);
        
       },
       complete: () => { this.router.navigateByUrl(`/user/transaction/success/${this.data?.transactionReferenceId}`); }
     })
   
  }
}
