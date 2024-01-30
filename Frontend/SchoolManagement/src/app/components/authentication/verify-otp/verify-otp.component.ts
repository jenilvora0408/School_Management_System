import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { StorageHelperConstant } from 'src/app/constants/storage-helper/storage-helper';
import { ValidationMessageConstant } from 'src/app/constants/validation/validation-message';
import { ValidationPattern } from 'src/app/constants/validation/validation-pattern';
import { IVerifyOtpInterface } from 'src/app/models/auth/verify-otp.interface';
import { StorageHelperService } from 'src/app/services/storage-helper.service';
import { VerifyOtpService } from 'src/app/services/verify-otp.service';

@Component({
  selector: 'app-verify-otp',
  templateUrl: './verify-otp.component.html',
  styleUrls: ['./verify-otp.component.scss'],
})
export class VerifyOtpComponent {
  userName = this.storageHelper.getFromSession(StorageHelperConstant.names);

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

  constructor(
    private service: VerifyOtpService,
    private router: Router,
    private titleService: Title,
    private storageHelper: StorageHelperService
  ) {}

  ngOnInit() {
    this.router.events.subscribe(() => {
      // this.titleService.setTitle(TabTitleConstant.verifyOtp);
    });
  }

  onSubmit() {
    this.verifyOtpForm.markAllAsTouched();
    if (this.verifyOtpForm.valid) {
      this.service.verifyOtp(0, <IVerifyOtpInterface>this.verifyOtpForm.value);
    }
  }

  resendOtp() {
    this.service.resendOtp();
  }
}
