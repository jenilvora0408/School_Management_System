import { Routes } from '@angular/router';
import { AdmitRequestComponent } from './pages/authentication/admit-request/admit-request.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { VerifyOtpComponent } from './pages/authentication/verify-otp/verify-otp.component';
import { ForgetPasswordComponent } from './pages/authentication/forget-password/forget-password.component';
import { ResetPasswordComponent } from './pages/authentication/reset-password/reset-password.component';
import { TeacherDashboardComponent } from './pages/teacher/teacher-dashboard/teacher-dashboard.component';
import { TeacherLeaveRequestComponent } from './pages/teacher/teacher-leave-request/teacher-leave-request.component';
import { AuthGuard } from './guards/auth.guard';
import { LeaveDashboardComponent } from './pages/teacher/leave-dashboard/leave-dashboard.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admit-request', component: AdmitRequestComponent },
  { path: 'verify-otp', component: VerifyOtpComponent },
  { path: 'forget-password', component: ForgetPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  {
    path: 'teacher-dashboard',
    component: TeacherDashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'teacher-leave-request',
    component: TeacherLeaveRequestComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'leave-dashboard',
    component: LeaveDashboardComponent,
    canActivate: [AuthGuard],
  },
];
