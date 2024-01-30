import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ApiCallConstant } from 'src/app/constants/api-call/apis';
import { RoutingPathConstant } from 'src/app/constants/routing/routing-path';
import { IResetPasswordInterface } from '../models/auth/reset-password.interface';

@Injectable({
  providedIn: 'root',
})
export class ResetPasswordService {
  resetPasswordApi = ApiCallConstant.RESET_PASSWORD_URL;

  constructor(
    private router: Router,
    private http: HttpClient,
    private activatedRoute: ActivatedRoute
  ) {}

  resetPassword(resetPasswordDetails: IResetPasswordInterface) {
    let token;
    this.activatedRoute.queryParams.forEach((params: Params) => {
      token = params['token'];
    });
    this.http
      .post(this.resetPasswordApi + '?token=' + token, resetPasswordDetails)
      .subscribe({
        next: (res) => {
          this.router.navigate([RoutingPathConstant.loginUrl]);
        },
      });
  }
}
