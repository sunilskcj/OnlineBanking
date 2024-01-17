import { NgModule } from '@angular/core';



import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

import { CreateAccountComponent } from './create-account/create-account.component';


import { HomePageComponent } from './home-page/home-page.component';
import { RouterModule } from '@angular/router';
import { NetBankingRoutingModule } from './net-banking-routing.module';
import { UserPageModule } from './user-page/user-page.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AdminNavbarComponent } from './admin/admin-navbar/admin-navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { AccountService } from './services/account.service';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin/admin.component';
import { RequestedAccountComponent } from './admin/requested-account/requested-account.component';
import { RespondedAccountsComponent } from './admin/responded-accounts/responded-accounts.component';
import { AdminProfileComponent } from './admin/admin-profile/admin-profile.component';
import { RequestedAccountDetailsComponent } from './admin/requested-account-details/requested-account-details.component';
import { CreateAccSuccessComponent } from './create-account/create-acc-success/create-acc-success.component';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';









@NgModule({
  declarations: [
    
    LoginComponent,
    RegistrationComponent,
    HomePageComponent,
    CreateAccountComponent,
    AdminComponent,
    AdminNavbarComponent,
    RequestedAccountComponent,
    RespondedAccountsComponent,
    AdminProfileComponent,
    RequestedAccountDetailsComponent,
    CreateAccSuccessComponent,
    ForgetPasswordComponent,
   



    
  ],
  imports: [RouterModule,FormsModule,NetBankingRoutingModule,UserPageModule,FormsModule,ReactiveFormsModule,HttpClientModule,CommonModule
    
  ],
  providers: [AccountService],
  bootstrap: [],
  exports : [HomePageComponent]
})
export class NetBankingModule { }
