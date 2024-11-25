import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Branch } from "../_models/Branch";
import { Observable } from "rxjs";

const AUTH_API = 'https://localhost:7033/api/branch/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})

export class BranchService {
  branches: Array<Branch> = new Array<Branch>();

  constructor(private http: HttpClient) { }

  getBranches(): Observable<any> {
    return this.http.get(
      AUTH_API + 'get-branches',
      httpOptions
    );
  }
}
