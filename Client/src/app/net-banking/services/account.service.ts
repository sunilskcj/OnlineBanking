import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from 'rxjs';
import { Account } from '../Models/Account';
import { ResponseModel } from '../Models/ResponseModel';
@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  private url = "http://localhost:5175/api/Accounts"
  constructor(private _http : HttpClient) { }
  tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ sessionStorage.getItem('token')})
  getAllaccount () : Observable<Account[]> 
  {
    
 
    const responseObject = this._http.get(this.url,{headers : this.tokenHeader});
// response from the get is in type Object { {Account}}

   const mappedObservable : Observable<Account[]> = responseObject
        .pipe(map(array =>  <Account[]>array)) ;
    return mappedObservable 
 }

 getAccountbyId(id? : number) : Observable<Account> {


 
   const responseObject = this._http.get(`${this.url}/${id}`,{'headers' : this.tokenHeader})
   const mappedObservableAccount : Observable<Account> = responseObject.pipe(map(a => <Account>a));
   return mappedObservableAccount
 } 
  getAccountbyIdAdmin(id : number) : Observable<Account> {
    
 
   const responseObject = this._http.get(`${this.url}/admin/${id}`,{'headers' : this.tokenHeader})
   const mappedObservableAccount : Observable<Account> = responseObject.pipe(map(a => <Account>a));
   return mappedObservableAccount
 } 
 getAccountbystatus(status : string) : Observable<Account[]> {
  
  const responseObject = this._http.get(`${this.url}/acc/${status}`, {'headers': this.tokenHeader})
  const mappedObservableAccount : Observable<Account[]> = responseObject.pipe(map(a => <Account[]>a));
  return mappedObservableAccount
} 

 addAccount(Account : Account ): Observable<ResponseModel> {
   const responseObject = this._http.post(`${this.url}`, Account,{'headers' : this.tokenHeader})
   return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
 }

 updateAccount(Account : Account): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, Account,{'headers' : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}

deleteAccount(id? : number): Observable<ResponseModel> {
  const responseObject = this._http.delete(`${this.url}/${id}`,{'headers' : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}



} 
