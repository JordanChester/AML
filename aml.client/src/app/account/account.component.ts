import { Component, OnInit } from '@angular/core';
import { StorageService } from '../_services/storage.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.css'
})
export class AccountComponent implements OnInit {
  detailsform: any = {
    address: null,
    phone: null
  };
  passwordform: any = {
    oldpassword: null,
    newpassword: null,
    confirmpassword: null
  }
  currentUser: any;
  editMode: boolean = false;
  changePassword: boolean = false;
  errorMessage = '';

  constructor(private storageService: StorageService, private authService: AuthService) { }

  ngOnInit(): void {
    this.currentUser = this.storageService.getUser();
  }

  editClicked(): void {
    this.editMode = !this.editMode;
  }

  changePassClicked(): void {
    this.changePassword = !this.changePassword;
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
        window.location.reload();
      },
      error: err => {
        this.errorMessage = err.error.message;
      }
    });
  }

}
