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
import { AuthenticationService } from '../../../services/authentication.service';
import { IVerifyOtpInterface } from '../../../models/auth/verify-otp.interface';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';

@Component({
  selector: 'app-verify-otp',
  standalone: true,
  imports: [
    InputComponent,
    ButtonComponent,
    ReactiveFormsModule,
    FormSubmitDirective,
  ],
  templateUrl: './verify-otp.component.html',
  styleUrl: './verify-otp.component.scss',
})
export class VerifyOtpComponent {
  userName: string = '';
  email: string = '';

  constructor(
    private authService: AuthenticationService,
    private route: ActivatedRoute,
    private notificationsService: NotificationService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.email = params['email'];
    });
  }

  verifyOtpForm = new FormGroup({
    otp: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(6),
      ])
    ),
  });

  onSubmit(): void {
    this.verifyOtpForm.markAllAsTouched();
    if (this.verifyOtpForm.valid && this.email) {
      const otpValue = this.verifyOtpForm.get('otp')?.value;
      this.authService.verifyOtp(this.email, otpValue).subscribe({
        next: (response: any) => {
          console.log('verify-otp response: ', response);
          this.authService.decodeToken(response.data.accessToken);
          const userId = this.authService.getUserId() || '';
          console.log('UserId: ' + userId);
          this.notificationsService.success(response.message);
        },
        error: (error: HttpErrorResponse) => {
          this.notificationsService.error(error.error.messages);
        },
      });
    }
  }

  resendOtp() {
    console.log(this.email);

    this.authService.sendOtp(this.email).subscribe({
      next: (response: IResponse<null>) => {
        console.log('resend', response, this.email);

        this.notificationsService.success(response.message);
      },
      error: (error: HttpErrorResponse) => {
        this.notificationsService.error(error.error.messages);
      },
    });
  }
}
