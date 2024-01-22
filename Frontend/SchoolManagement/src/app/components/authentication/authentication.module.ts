import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared.module';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerifyOtpComponent } from './verify-otp/verify-otp.component';
import { AdmitRequestComponent } from './admit-request/admit-request.component';

const components = [
  LoginComponent,
  ForgetPasswordComponent,
  ResetPasswordComponent,
  VerifyOtpComponent,
  AdmitRequestComponent,
];

@NgModule({
  declarations: [...components],
  imports: [CommonModule, AuthenticationRoutingModule, NgbModule, SharedModule],
})
export class AuthenticationModule {}
