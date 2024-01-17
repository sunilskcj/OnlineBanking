import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminProfileComponent } from "./admin/admin-profile/admin-profile.component";
import { AdminComponent } from "./admin/admin.component";
import { RequestedAccountDetailsComponent } from "./admin/requested-account-details/requested-account-details.component";
import { RequestedAccountComponent } from "./admin/requested-account/requested-account.component";
import { RespondedAccountsComponent } from "./admin/responded-accounts/responded-accounts.component";
import { AuthGuard } from "./core/auth.guard";
import { CreateAccSuccessComponent } from "./create-account/create-acc-success/create-acc-success.component";
import { CreateAccountComponent } from "./create-account/create-account.component";
import { ForgetPasswordComponent } from "./forget-password/forget-password.component";
import { HomePageComponent } from "./home-page/home-page.component";
import { LoginComponent } from "./login/login.component";
import { RegistrationComponent } from "./registration/registration.component";
import { AccountDetailsComponent } from "./user-page/account-details/account-details.component";
import { AccountStatementComponent } from "./user-page/account-statement/account-statement.component";
import { AccountSummaryComponent } from "./user-page/account-summary/account-summary.component";
import { ChangePasswordComponent } from "./user-page/change-password/change-password.component";
import { EditProfileComponent } from "./user-page/edit-profile/edit-profile.component";

import { FundTransferComponent } from "./user-page/fund-transfer/fund-transfer.component";
import { ModesOfTransactionComponent } from "./user-page/modes-of-transaction/modes-of-transaction.component";
import { PayeeComponent } from "./user-page/payee/payee.component";
import { TransactionSuccesfulComponent } from "./user-page/transaction-succesful/transaction-succesful.component";
import { TransactionVerificationComponent } from "./user-page/transaction-verification/transaction-verification.component";
import { UserDashComponent } from "./user-page/user-dash/user-dash.component";
import { UserPageComponent } from "./user-page/user-page.component";


const AppRoutes : Routes = [
    {path : '', component : HomePageComponent, pathMatch : "full" },
    
   
    {path : 'login', component : LoginComponent },
    {path : 'forgetpassword', component : ForgetPasswordComponent },
   
   
    {path : 'register', component : RegistrationComponent},
    {path : 'CreateAccount', component : CreateAccountComponent},
    {path : 'CreateAccount/success', component : CreateAccSuccessComponent},
    {path : 'user', component : UserPageComponent, 
        children : 

        [  
            {path : 'changepassword', component : ChangePasswordComponent },
             {path : 'dash/:customerId', component : UserDashComponent},
            {path : 'statement', component : AccountStatementComponent},
            {path : 'profile', component : AccountDetailsComponent},
            {path: 'editprofile', component : EditProfileComponent},
            {path : 'transaction', component : FundTransferComponent,
             children : 
            [   {path : 'mode', component : ModesOfTransactionComponent},
                {path : 'verification/:customerId', component : TransactionVerificationComponent},
                {path : 'success/:customerId', component : TransactionSuccesfulComponent}
            ]},
            {path: 'payee', component : PayeeComponent},
            {path : 'summary', component : AccountSummaryComponent}
        ]},
    {path : 'admin', component : AdminComponent ,canActivate : [AuthGuard], 
        children : 
        [
            {path : 'reqaccounts', component : RequestedAccountComponent},
            {path : 'reqaccount/:customerId', component : RequestedAccountDetailsComponent},
            {path : 'profile', component : AdminProfileComponent},
            {path : 'resaccounts', component : RespondedAccountsComponent},
        ]},
      
   
   
    // admin/reqaccounts
]



@NgModule({
    imports : [ RouterModule.forRoot(AppRoutes)],
    exports : [RouterModule]
})
export class NetBankingRoutingModule{}