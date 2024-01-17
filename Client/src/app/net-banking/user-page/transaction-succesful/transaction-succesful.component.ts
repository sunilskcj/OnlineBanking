import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Transaction } from '../../Models/Transaction';
import { TransactionService } from '../../services/transaction.service';

@Component({
  selector: 'app-transaction-succesful',
  templateUrl: './transaction-succesful.component.html',
  styleUrls: ['./transaction-succesful.component.css']
})
export class TransactionSuccesfulComponent implements OnInit {

  constructor(private router : Router,private activeroute : ActivatedRoute,private _Ts : TransactionService) { }
  
  data? : Transaction
  

  
  ngOnInit(): void {
      
    
      const refId = this.activeroute.snapshot.params["customerId"]
    
         
    this._Ts.getTransactionbyId(refId).subscribe(

      {
       next: (data: Transaction) => this.data = data 
        
 
       ,
       error: (errresp: HttpErrorResponse) => {
 
        console.log(errresp);
        
       },
       complete: () => {}
     })
    
  }


  redirect(){this.router.navigateByUrl("user/transaction/mode")}

  redirectdash(){this.router.navigateByUrl("user/dash")}
}
