import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ResponseModel } from '../Models/ResponseModel';
import { Transaction } from '../Models/Transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private url = "http://localhost:5175/api/Transaction"
  constructor(private _http : HttpClient) { }
  tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ sessionStorage.getItem('token')})
  
  getAllTransaction (id? : number) : Observable<Transaction[]> 
  {

    const responseObject = this._http.get(`${this.url}/${id}/all`,{headers : this.tokenHeader});
// response from the get is in type Object 

   const mappedObservable : Observable<Transaction[]> = responseObject
        .pipe(map(array =>  <Transaction[]>array)) ;
    return mappedObservable 
 }

 getTransactionbyId(id : number) : Observable<Transaction> {

   const responseObject = this._http.get(`${this.url}/${id}`,{headers : this.tokenHeader})
   const mappedObservableTransaction : Observable<Transaction> = responseObject.pipe(map(a => <Transaction>a));
   return mappedObservableTransaction
 } 
 getTransactionbystatus(stat : string) : Observable<Transaction[]> {

  const responseObject = this._http.get(`${this.url}/cred/${stat}`,{headers : this.tokenHeader})
  const mappedObservableTransaction : Observable<Transaction[]> = responseObject.pipe(map(a => <Transaction[]>a));
  return mappedObservableTransaction
} 
 addTransaction(Transaction : Transaction ): Observable<ResponseModel> {
   const responseObject = this._http.post(`${this.url}`, Transaction,{headers : this.tokenHeader})
   return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
 }
 proceedTransaction( id? : number ): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}/payment/${id}`, {headers : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}
 updateTransaction(Transaction : Transaction): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, Transaction,{headers : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}

deleteTransaction(id : number): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, id,{headers : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}

}
