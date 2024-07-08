import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { AuthenticationService } from '../../../services/authentication.service';
import { ILoginInterface } from '../../../models/auth/login.interface';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { RouterLink } from '@angular/router';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { NotificationService } from '../../../shared/services/notification.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    InputComponent,
    ButtonComponent,
    ReactiveFormsModule,
    RouterLink,
    FormSubmitDirective,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  emailValidationMsg: string = ValidationMessageConstant.email;
  passwordValidationMsg: string = ValidationMessageConstant.password;
  showPassword: boolean = false;

  constructor(
    private authService: AuthenticationService,
    private notificationService: NotificationService
  ) {}

  loginForm = new FormGroup({
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
      ])
    ),
    password: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.password),
      ])
    ),
  });

  onSubmit() {
    this.loginForm.markAllAsTouched();
    if (this.loginForm.valid) {
      this.authService.login(<ILoginInterface>this.loginForm.value);
      console.log('Login successful!');
      this.notificationService.success('Login successful!');
    }
  }
}
