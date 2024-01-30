import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ApiCallConstant } from 'src/app/constants/api-call/apis';
import { RoutingPathConstant } from 'src/app/constants/routing/routing-path';
import { StorageHelperConstant } from 'src/app/constants/storage-helper/storage-helper';
import { ILoginInterface } from '../models/auth/login.interface';
import { StorageHelperService } from './storage-helper.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  loginApi = ApiCallConstant.LOGIN_URL;

  constructor(
    private router: Router,
    private http: HttpClient,
    private storageHelper: StorageHelperService
  ) {}

  login(loginCredential: ILoginInterface) {
    this.storageHelper.setAsSession(
      StorageHelperConstant.email,
      loginCredential.email
    );
    this.http
      .post(this.loginApi, loginCredential, {
        withCredentials: true,
        headers: {
          credentials: 'include',
        },
      })
      .subscribe({
        next: (res: any) => {
          this.storageHelper.setAsSession(
            StorageHelperConstant.names,
            res.data
          );
          this.router.navigate([RoutingPathConstant.verifyOtpUrl]);
        },
      });
  }
}
