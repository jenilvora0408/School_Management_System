import { Component } from '@angular/core';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { AuthenticationService } from '../../../services/authentication.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { IForgetPasswordInterface } from '../../../models/auth/forget-password.interface';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forget-password',
  standalone: true,
  imports: [
    InputComponent,
    ButtonComponent,
    ReactiveFormsModule,
    FormSubmitDirective,
  ],
  templateUrl: './forget-password.component.html',
  styleUrl: './forget-password.component.scss',
})
export class ForgetPasswordComponent {
  emailValidationMsg: string = ValidationMessageConstant.email;

  forgetPasswordForm = new FormGroup({
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
      ])
    ),
  });

  constructor(
    private authService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  onSubmit() {
    this.forgetPasswordForm.markAllAsTouched();
    if (this.forgetPasswordForm.valid)
      this.authService
        .forgetPassword(<IForgetPasswordInterface>this.forgetPasswordForm.value)
        .subscribe({
          next: (response: IResponse<null>) => {
            console.log('forget-password: ', response);

            if (response.success) {
              this.notificationService.success(response.message);
              this.router.navigate(['/verify-otp'], {
                queryParams: {
                  email: this.forgetPasswordForm.value.email,
                  from: 'forgot-password',
                },
              });
            }
          },
          error: (error: HttpErrorResponse) => {
            this.notificationService.error(error.error.messages);
          },
        });
  }
}
