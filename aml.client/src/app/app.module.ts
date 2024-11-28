import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { AccountComponent } from './account/account.component';

import { httpInterceptorProviders } from './_helpers/http.interceptor';
import { LibraryComponent } from './library/library.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatPaginator } from "@angular/material/paginator";
import { MediaComponent } from './media/media.component';
import { OrderMediaComponent } from './order-media/order-media.component';
import {MatTab, MatTabGroup} from "@angular/material/tabs";
import {MatFormField, MatFormFieldModule} from "@angular/material/form-field";
import {
  MatDatepickerModule,
  MatDatepickerToggle,
  MatDateRangeInput,
  MatDateRangePicker
} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    HomeComponent,
    RegistrationComponent,
    AccountComponent,
    LibraryComponent,
    MediaComponent,
    OrderMediaComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    MatPaginator,
    MatTabGroup,
    MatTab,
    MatFormField,
    MatDateRangeInput,
    MatDatepickerToggle,
    MatDateRangePicker,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [httpInterceptorProviders,
    provideAnimationsAsync(),
    MatDatepickerModule,],
  bootstrap: [AppComponent]
})
export class AppModule { }
