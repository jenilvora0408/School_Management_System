import { Routes } from '@angular/router';
import { AuthenticationComponent } from './components/authentication/authentication.component';
import { AdmitRequestComponent } from './components/authentication/admit-request/admit-request.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { VerifyOtpComponent } from './components/authentication/verify-otp/verify-otp.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admit-request', component: AdmitRequestComponent },
  { path: 'verify-otp', component: VerifyOtpComponent },
];
