import { Routes } from '@angular/router';
import { AdmitRequestComponent } from './pages/authentication/admit-request/admit-request.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { VerifyOtpComponent } from './pages/authentication/verify-otp/verify-otp.component';
import { ForgetPasswordComponent } from './pages/authentication/forget-password/forget-password.component';
import { ResetPasswordComponent } from './pages/authentication/reset-password/reset-password.component';
import { TeacherDashboardComponent } from './pages/teacher/teacher-dashboard/teacher-dashboard.component';
import { ViewAdmitRequestComponent } from './pages/teacher/view-admit-request/view-admit-request.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admit-request', component: AdmitRequestComponent },
  { path: 'verify-otp', component: VerifyOtpComponent },
  { path: 'forget-password', component: ForgetPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'teacher-dashboard', component: TeacherDashboardComponent },
  { path: 'view-admit-request', component: ViewAdmitRequestComponent },
];
