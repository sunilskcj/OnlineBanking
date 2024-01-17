import { NgModule } from '@angular/core';
import { AccountStatementComponent } from './account-statement/account-statement.component';
import { FundTransferComponent } from './fund-transfer/fund-transfer.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { RouterModule } from '@angular/router';
import { UserPageComponent } from './user-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AccountSummaryComponent } from './account-summary/account-summary.component';

import { UserDashComponent } from './user-dash/user-dash.component';
import { TransactionSuccesfulComponent } from './transaction-succesful/transaction-succesful.component';
import { TransactionVerificationComponent } from './transaction-verification/transaction-verification.component';
import { PayeeComponent } from './payee/payee.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { ModesOfTransactionComponent } from './modes-of-transaction/modes-of-transaction.component';
import { ChangePasswordComponent } from './change-password/change-password.component';




@NgModule({
  declarations: [
      UserPageComponent,
    AccountStatementComponent,
    FundTransferComponent,
    AccountDetailsComponent,
    NavbarComponent,
    AccountSummaryComponent,
 
    UserDashComponent,
       TransactionSuccesfulComponent,
       TransactionVerificationComponent,
       PayeeComponent,
       EditProfileComponent,
       ModesOfTransactionComponent,
       ChangePasswordComponent
    

 
  ],
  imports: [RouterModule,ReactiveFormsModule,CommonModule
   
  ],
  providers: [],
  exports : [UserPageComponent,FundTransferComponent]
 
})
export class UserPageModule { }
