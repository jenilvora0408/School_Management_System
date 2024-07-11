import { Routes } from '@angular/router';
import { AdmitRequestComponent } from './pages/authentication/admit-request/admit-request.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { VerifyOtpComponent } from './pages/authentication/verify-otp/verify-otp.component';
import { ForgetPasswordComponent } from './pages/authentication/forget-password/forget-password.component';
import { ResetPasswordComponent } from './pages/authentication/reset-password/reset-password.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admit-request', component: AdmitRequestComponent },
  { path: 'verify-otp', component: VerifyOtpComponent },
  { path: 'forget-password', component: ForgetPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
];
