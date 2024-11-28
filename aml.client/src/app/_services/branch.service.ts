import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Branch } from "../_models/Branch";
import { Observable } from "rxjs";
import { UpdateBranchRequest } from "../_DTOs/UpdateBranchRequest";

const AUTH_API = 'http://localhost:7033/api/branch/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})

export class BranchService {
  constructor(private http: HttpClient) { }

  getBranches(): Observable<any> {
    return this.http.get(
      AUTH_API + 'get-branches',
      httpOptions
    );
  }

  getBranch(branchId: any): Observable<any> {
    let params = new HttpParams().set("branchId", branchId)
    let httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params
    };

    return this.http.get(
      AUTH_API + 'get-branch',
      httpOptions
    );
  }

  updateBranch(email: string, branch: Branch): Observable<any> {
    const request: UpdateBranchRequest = {
      email: email,
      branch: branch
    }

    return this.http.post(
      AUTH_API + 'update-branch',
      request,
      httpOptions
    );
  }
}
