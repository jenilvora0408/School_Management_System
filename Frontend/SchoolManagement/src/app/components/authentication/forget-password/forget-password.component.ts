import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ValidationMessageConstant } from 'src/app/constants/validation/validation-message';
import { ValidationPattern } from 'src/app/constants/validation/validation-pattern';
import { ForgotPasswordService } from 'src/app/services/forgot-password.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.scss'],
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
    private service: ForgotPasswordService,
    private titleService: Title,
    private router: Router
  ) {}

  ngOnInit() {
    this.router.events.subscribe(() => {
      // this.titleService.setTitle(TabTitleConstant.forgotPassword);
    });
  }

  onSubmit() {
    this.forgetPasswordForm.markAllAsTouched();
    if (this.forgetPasswordForm.valid) {
      this.service.forgotPassword(<string>this.forgetPasswordForm.value.email);
      this.router.navigate(['/login']);
    }
  }
}
