import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountType } from '../_classes/AccountType';
import { RegisterRequest } from '../_DTOs/RegisterRequest';
import { LoginRequest } from '../_DTOs/LoginRequest';
import { UpdateDetailsRequest } from '../_DTOs/UpdateDetailsRequest';
import { ChangePasswordRequest } from '../_DTOs/ChangePasswordRequest';
import { Branch } from '../_models/Branch';

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

  register(email: string, password: string, accountType: AccountType, name: string, address: string, phone: string, branch: Branch): Observable<any> {
    const request: RegisterRequest = {
      email: email,
      password: password,
      accountType: accountType,
      name: name,
      address: address,
      phone: phone,
      branch: branch
    }

    return this.http.post(
      AUTH_API + 'register-account',
      request,
      httpOptions
    );
  }

  updateDetails(email: string, address: string, phone: string): Observable<any> {
    const request: UpdateDetailsRequest = {
      email: email,
      address: address,
      phone: phone
    }

    return this.http.post(
      AUTH_API + 'update-details',
      request,
      httpOptions
    );
  }

  changePassword(email: string, oldPassword: string, newPassword: string): Observable<any> {
    const request: ChangePasswordRequest = {
      email: email,
      oldPassword: oldPassword,
      newPassword: newPassword
    }

    return this.http.post(
      AUTH_API + 'change-password',
      request,
      httpOptions
    );
  }
}
