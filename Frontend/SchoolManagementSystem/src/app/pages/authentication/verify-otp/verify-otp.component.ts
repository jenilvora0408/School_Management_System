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
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import {
  SystemConstants,
  UserRole,
} from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { NotificationMessageConstant } from '../../../constants/notification/notification-message';

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
  locationUrl: string = '';

  constructor(
    private authService: AuthenticationService,
    private route: ActivatedRoute,
    private notificationsService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.email = CryptoJS.AES.decrypt(
        params['email'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.locationUrl = CryptoJS.AES.decrypt(
        params['from'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
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
    console.log('Hii', this.verifyOtpForm.value, this.email);

    if (this.verifyOtpForm.valid && this.email) {
      const otpValue = this.verifyOtpForm.get('otp')?.value;
      this.authService.verifyOtp(this.email, otpValue).subscribe({
        next: (response: any) => {
          if (this.locationUrl == 'login') {
            console.log('verify-otp response: ', response);
            this.authService.decodeToken(response.data.accessToken);
            this.notificationsService.success(
              NotificationMessageConstant.loginSuccessful
            );
            if (this.authService.getUserType() == UserRole.principalRoleId) {
              this.router.navigate([RoutingPathConstant.principalDashboardUrl]);
            } else if (
              this.authService.getUserType() == UserRole.teacherRoleId
            ) {
              this.router.navigate([RoutingPathConstant.teacherDashboardUrl]);
            } else if (
              this.authService.getUserType() == UserRole.studentRoleId
            ) {
              this.router.navigate([RoutingPathConstant.studentDashboardUrl]);
            }
            const userId = this.authService.getUserId() || '';
            console.log('UserId: ' + userId);
          } else {
            this.notificationsService.success(
              NotificationMessageConstant.otpVerifiedSuccessfully
            );
            this.router.navigate([RoutingPathConstant.resetPasswordUrl], {
              queryParams: {
                email: CryptoJS.AES.encrypt(
                  this.email,
                  SystemConstants.EncryptionKey
                ),
              },
            });
          }
        },
        error: (error: HttpErrorResponse) => {
          this.notificationsService.error(error.error.errors);
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
