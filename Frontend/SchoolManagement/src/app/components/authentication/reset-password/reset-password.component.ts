import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { passwordMatchValidator } from 'src/app/common/password-match-validator';
import { ValidationMessageConstant } from 'src/app/constants/validation/validation-message';
import { ValidationPattern } from 'src/app/constants/validation/validation-pattern';
import { IResetPasswordInterface } from 'src/app/models/auth/reset-password.interface';
import { ResetPasswordService } from 'src/app/services/reset-password.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
})
export class ResetPasswordComponent implements OnInit {
  emailValidationMsg: string = ValidationMessageConstant.email;
  passwordValidationMsg: string = ValidationMessageConstant.password;
  showPassword: boolean = false;

  resetPasswordForm = new FormGroup({
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
    private service: ResetPasswordService,
    private titleService: Title,
    private router: Router
  ) {}

  ngOnInit() {
    this.router.events.subscribe(() => {
      // this.titleService.setTitle(TabTitleConstant.resetPassword);
    });
  }

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
  }

  onSubmit() {
    this.resetPasswordForm.markAllAsTouched();
    if (this.resetPasswordForm.valid) {
      this.service.resetPassword(
        <IResetPasswordInterface>this.resetPasswordForm.value
      );
    }
  }
}
