import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { AccountComponent } from './account/account.component';

import { httpInterceptorProviders } from './_helpers/http.interceptor';
import {LibraryComponent} from "./library/library.component";
import {MediaComponent} from "./media/media.component";
import { LibraryComponent } from './library/library.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatPaginator} from "@angular/material/paginator";
import { MediaComponent } from './media/media.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    HomeComponent,
    RegistrationComponent,
    AccountComponent,
    LibraryComponent,
    MediaComponent
  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        MatPaginator
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [httpInterceptorProviders,
    provideAnimationsAsync()],
  bootstrap: [AppComponent]
})
export class AppModule { }
