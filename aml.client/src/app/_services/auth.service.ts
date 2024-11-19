import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountType } from '../_classes/AccountType';
import { RegisterRequest } from '../_DTOs/RegisterRequest';
import { LoginRequest } from '../_DTOs/LoginRequest';

const AUTH_API = 'https://localhost:7033/api/account/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const request: LoginRequest = {
      email: email,
      password: password
    }

    return this.http.post(
      AUTH_API + 'verify-login',
      request,
      httpOptions
    );
  }

  register(email: string, password: string, accountType: AccountType, name: string, address: string, phone: string): Observable<any> {
    const request: RegisterRequest = {
      email: email,
      password: password,
      accountType: accountType,
      name: name,
      address: address,
      phone: phone
    }

    return this.http.post(
      AUTH_API + 'register-account',
      request,
      httpOptions
    );
  }

  logout(): Observable<any> {
    return this.http.post(AUTH_API + 'signout', {}, httpOptions);
  }
}
