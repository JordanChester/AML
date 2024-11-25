import { Component, OnInit } from '@angular/core';
import { StorageService } from '../_services/storage.service';
import { AuthService } from '../_services/auth.service';
import { Branch } from '../_models/Branch';
import { BranchService } from '../_services/branch.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent implements OnInit {
  currentUser: any;
  userBranch: Branch | undefined;
  userBranchName: string | undefined;
  branches: Array<Branch> = new Array<Branch>();
  showReadonly: boolean = false;
  editMode: boolean = false;
  changePassword: boolean = false;
  changeBranch: boolean = false;
  changeSuccess: boolean = false;
  errorMessage = '';

  detailsform: any = {
    address: null,
    phone: null
  };

  passwordform: any = {
    oldpassword: null,
    newpassword: null,
    confirmpassword: null
  };

  branchform: any = {
    branch: null
  }

  constructor(private storageService: StorageService, private authService: AuthService, private branchService: BranchService) { }

  ngOnInit(): void {
    this.branchService.getBranches().subscribe({
      next: data => {
        this.branches = data;
      }
    });

    this.currentUser = this.storageService.getUser();

    this.branchService.getBranch(this.currentUser.branchId).subscribe({
      next: data => {
        this.userBranch = data;
        this.userBranchName = data.name;
      }
    });
  }

  editClicked(): void {
    this.editMode = !this.editMode;
    this.showReadonly = !this.showReadonly;
    this.changePassword = false;
    this.changeBranch = false;
  }

  changePassClicked(): void {
    this.changePassword = !this.changePassword;
    this.showReadonly = !this.showReadonly;
    this.editMode = false;
    this.changeBranch = false;
  }

  changeBranchClicked(): void {
    this.changeBranch = !this.changeBranch;
    this.showReadonly = !this.showReadonly;
    this.editMode = false;
    this.changePassword = false;
  }

  updateDetails(): void {
    const { address, phone } = this.detailsform;
    const email = this.currentUser.email;

    this.authService.updateDetails(email, address, phone).subscribe({
      next: data => {
        this.storageService.saveUser(data);
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
      }
    });
  }

  updatePassword(): void {
    const { oldpassword, newpassword } = this.passwordform;
    const email = this.currentUser.email;

    this.authService.changePassword(email, oldpassword, newpassword).subscribe({
      next: data => {
        this.storageService.saveUser(data);
        this.changeSuccess = true;
      },
      error: err => {
        this.errorMessage = err.error.message;
      }
    });
  }

  updateBranch(): void {
    const { branch } = this.branchform;
    const email = this.currentUser.email;

    this.branchService.updateBranch(email, branch).subscribe({
      next: data => {
        this.storageService.saveUser(data);
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
      }
    });
  }

}
