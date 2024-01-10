import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { LoginComponent } from './login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared.module';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

const components = [
  LoginComponent,
  ForgetPasswordComponent,
  ResetPasswordComponent,
];

@NgModule({
  declarations: [...components],
  imports: [CommonModule, AuthenticationRoutingModule, NgbModule, SharedModule],
})
export class AuthenticationModule {}
