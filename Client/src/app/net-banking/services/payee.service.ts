import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Payee } from '../Models/Payee';
import { ResponseModel } from '../Models/ResponseModel';

@Injectable({
  providedIn: 'root'
})
export class PayeeService {
  private url = "http://localhost:5175/api/Payee"
  constructor(private _http : HttpClient) { }
  tokenHeader = new HttpHeaders({'Authorization':'Bearer '+ sessionStorage.getItem('token')})
  getAllPayee ( ) : Observable<Payee[]> 
  {

    const responseObject = this._http.get(`${this.url}/id`,{headers : this.tokenHeader});
// response from the get is in type Object 

   const mappedObservable : Observable<Payee[]> = responseObject
        .pipe(map(array =>  <Payee[]>array)) ;
    return mappedObservable 
 }

 getPayeebyId() : Observable<Payee> {

   const responseObject = this._http.get(`${this.url}`,{headers : this.tokenHeader} )
   const mappedObservablePayee : Observable<Payee> = responseObject.pipe(map(a => <Payee>a));
   return mappedObservablePayee
 } 

 addPayee(Payee : Payee ): Observable<ResponseModel> {
   const responseObject = this._http.post(`${this.url}/custid`, Payee,{headers : this.tokenHeader})
   return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
 }

 updatePayee(Payee : Payee): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, Payee)
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}

deletePayee(id : number): Observable<ResponseModel> {
  const responseObject = this._http.put(`${this.url}`, id)
  return responseObject.pipe(map((response: any) => <ResponseModel>response)) 
}


}
