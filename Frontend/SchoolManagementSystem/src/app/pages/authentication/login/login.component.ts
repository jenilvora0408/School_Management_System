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
import { Router, RouterLink } from '@angular/router';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { NotificationService } from '../../../shared/services/notification.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { LoaderService } from '../../../shared/services/loader.service';

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
  userName: string = '';

  constructor(
    private authService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router,
    private loaderService: LoaderService
  ) {}

  loginForm = new FormGroup({
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
        Validators.maxLength(32),
        Validators.minLength(8),
      ])
    ),
    password: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.password),
        Validators.maxLength(15),
      ])
    ),
  });

  onSubmit() {
    this.loginForm.markAllAsTouched();
    if (this.loginForm.valid)
      this.authService.login(<ILoginInterface>this.loginForm.value).subscribe({
        next: (response: IResponse<string>) => {
          console.log('login: ', response);
          this.userName = response.data;
          if (response.success) {
            this.notificationService.success(response.message);
            this.router.navigate(['/verify-otp'], {
              queryParams: {
                email: CryptoJS.AES.encrypt(
                  this.loginForm.value.email ?? '',
                  SystemConstants.EncryptionKey
                ),
                from: CryptoJS.AES.encrypt(
                  'login',
                  SystemConstants.EncryptionKey
                ),
                userName: CryptoJS.AES.encrypt(
                  this.userName,
                  SystemConstants.EncryptionKey
                ),
              },
            });
          }
        },
        error: (error: HttpErrorResponse) => {
          this.loaderService.hide();
          this.notificationService.error(error.error.errors);
        },
      });
  }
}
