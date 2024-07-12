import { Component } from '@angular/core';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { passwordMatchValidator } from '../../../common/password-match-validator';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../../services/authentication.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { IResetPasswordInterface } from '../../../models/auth/reset-password.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports: [
    InputComponent,
    ButtonComponent,
    ReactiveFormsModule,
    FormSubmitDirective,
  ],
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss',
})
export class ResetPasswordComponent {
  email: string = '';
  resetPasswordForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.password),
      ])
    ),
    confirmPassword: new FormControl(
      '',
      [Validators.required],
      [passwordMatchValidator()]
    ),
  });

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthenticationService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.email = CryptoJS.AES.decrypt(
        params['email'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
    });
  }

  onSubmit() {
    this.resetPasswordForm.markAllAsTouched();
    this.resetPasswordForm.value.email = this.email;
    if (this.resetPasswordForm.valid)
      this.authService
        .resetPassword(<IResetPasswordInterface>this.resetPasswordForm.value)
        .subscribe({
          next: (response: IResponse<null>) => {
            console.log('reset-password: ', response);

            if (response.success) {
              this.notificationService.success(response.message);
              this.router.navigate(['']);
            }
          },
          error: (error: HttpErrorResponse) => {
            this.notificationService.error(error.error.errors);
          },
        });
  }
}
