import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, Observable } from 'rxjs';

import { ResponseModel } from '../Models/ResponseModel';
import { AccCredential } from '../Models/AccCredential';
@Injectable({
  providedIn: 'root'
})
export class AccCredentialService {
  private url = "http://localhost:5175/api/Credential"
  constructor(private _http : HttpClient) { }

   tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ sessionStorage.getItem('token')})

  getAllaccount () : Observable<AccCredential[]> 
  {

    const responseObject = this._http.get(this.url,{headers : this.tokenHeader});
// response from the get is in type Object 

   const mappedObservable : Observable<AccCredential[]> = responseObject
        .pipe(map(array =>  <AccCredential[]>array)) ;
    return mappedObservable 
 }

 getAccountCredbyId(id? : number) : Observable<AccCredential> {

   const responseObject = this._http.get(`${this.url}/cred/cust/${id}`,{headers : this.tokenHeader})
   const mappedObservableAccount : Observable<AccCredential> = responseObject.pipe(map(a => <AccCredential>a));
   return mappedObservableAccount
 } 
 
 addAccountCred(id? : number  ): Observable<ResponseModel> {
   const responseObject = this._http.post(`${this.url}/${id}`, id,{headers : this.tokenHeader} )
   return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
 }

 updateAccount(Account : AccCredential): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, Account,{headers : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}

deleteAccount(id : number): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, id,{headers : this.tokenHeader})
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}



} 
