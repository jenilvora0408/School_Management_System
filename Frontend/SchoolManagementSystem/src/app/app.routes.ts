import { Routes } from '@angular/router';
import { AdmitRequestComponent } from './pages/authentication/admit-request/admit-request.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { VerifyOtpComponent } from './pages/authentication/verify-otp/verify-otp.component';
import { ForgetPasswordComponent } from './pages/authentication/forget-password/forget-password.component';
import { ResetPasswordComponent } from './pages/authentication/reset-password/reset-password.component';
import { TeacherDashboardComponent } from './pages/teacher/teacher-dashboard/teacher-dashboard.component';
import { AuthGuard } from './guards/auth.guard';
import { LeaveDashboardComponent } from './pages/teacher/leave-dashboard/leave-dashboard.component';
import { StudentDashboardComponent } from './pages/student/student-dashboard/student-dashboard.component';
import { PrincipalDashboardComponent } from './pages/principal/principal-dashboard/principal-dashboard.component';
import { ClassesSubjectsComponent } from './pages/principal/classes-subjects/classes-subjects.component';
import { EditClassComponent } from './pages/principal/edit-class/edit-class.component';
import { MyProfileComponent } from './pages/common/my-profile/my-profile.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'admit-request', component: AdmitRequestComponent },
  { path: 'verify-otp', component: VerifyOtpComponent },
  { path: 'forget-password', component: ForgetPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  {
    path: 'teacher',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: TeacherDashboardComponent },
      {
        path: 'leave-dashboard',
        component: LeaveDashboardComponent,
      },
    ],
  },
  {
    path: 'student',
    component: StudentDashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'principal',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: PrincipalDashboardComponent },
      {
        path: 'classes-and-subjects',
        component: ClassesSubjectsComponent,
      },
      {
        path: 'edit-class',
        component: EditClassComponent,
      },
      {
        path: 'my-profile',
        component: MyProfileComponent,
      },
    ],
  },
];
