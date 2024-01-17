import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { map, Observable } from 'rxjs';

import { ResponseModel } from '../Models/ResponseModel';

import { LoginCredentials } from '../Models/loginCredentials';
import { TokenInfo } from '../Models/TokenInfo';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private url = "http://localhost:5175/api/login"
  constructor(private _http : HttpClient) { }
 
  loginuser(cd : LoginCredentials  ): Observable<TokenInfo> {
    const responseTokenInfo = this._http.post(`${this.url}`, cd )
    return responseTokenInfo.pipe(map((response: any) => <TokenInfo>response)) 
  }
  loginadmin(cd : LoginCredentials  ): Observable<TokenInfo> {
    const responseTokenInfo = this._http.post(`${this.url}/admin`, cd )
    return responseTokenInfo.pipe(map((response: any) => <TokenInfo>response)) 
  }

} 
