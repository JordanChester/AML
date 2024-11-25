import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Branch } from '../_models/Branch';
import { BranchService } from '../_services/branch.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent implements OnInit {
  form: any = {
    email: null,
    password: null,
    accountType: 1,
    name: null,
    address: null,
    phone: null,
    branch: null
  };
  branches: Array<Branch> = new Array<Branch>();
  selectedBranch: Branch | undefined;
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  constructor(private authService: AuthService, private branchService: BranchService) { }

  ngOnInit(): void {
    this.branchService.getBranches().subscribe({
      next: data => {
        this.branches = data;
      }
    })
  }

  onSubmit(): void {
    const { email, password, accountType, name, address, phone, branch } = this.form;

    this.authService.register(email, password, accountType, name, address, phone, branch).subscribe({
      next: data => {
        console.log(data);
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      error: err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    });
  }

}
