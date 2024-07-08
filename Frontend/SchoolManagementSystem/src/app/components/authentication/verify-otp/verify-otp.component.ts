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

  onSubmit() {
    console.log(this.verifyOtpForm.value);

    this.verifyOtpForm.markAllAsTouched();
    // if (this.verifyOtpForm.valid) {
    //   this.service.verifyOtp(0, <IVerifyOtpInterface>this.verifyOtpForm.value);
    // }
  }

  resendOtp() {
    // this.service.resendOtp();
  }
}
