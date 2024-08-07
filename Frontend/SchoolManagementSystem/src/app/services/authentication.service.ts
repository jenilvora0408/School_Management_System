import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { RoutingPathConstant } from '../constants/routing/routing-path';
import { StorageHelperConstant } from '../constants/storage-helper/storage-helper';
import { ILoginInterface } from '../models/auth/login.interface';
import { StorageHelperService } from '../shared/services/storage-helper.service';
import { Router } from '@angular/router';
import { IResponse } from '../shared/models/IResponse';
import { IAdmitRequestInterface } from '../models/auth/admit-request.interface';
import { IForgetPasswordInterface } from '../models/auth/forget-password.interface';
import { IResetPasswordInterface } from '../models/auth/reset-password.interface';
import { SystemConstants } from '../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  admitRequestApi = ApiCallConstant.CREATE_ADMIT_REQUEST;
  loginApi = ApiCallConstant.LOGIN_URL;
  verifyOtpApi = ApiCallConstant.VERIFY_OTP_URL;
  sendOtpApi = ApiCallConstant.SEND_OTP;
  forgetPasswordApi = ApiCallConstant.FORGET_PASSWORD;
  resetPasswordApi = ApiCallConstant.RESET_PASSWORD;

  token: string = '';

  constructor(
    private http: HttpClient,
    private storageHelper: StorageHelperService,
    private router: Router,
    private jwtService: JwtHelperService
  ) {}

  //#region HTTP_Methods

  createAdmitRequest(
    admitRequestData: IAdmitRequestInterface
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      this.admitRequestApi,
      admitRequestData
    );
  }

  login(loginCredentials: ILoginInterface): Observable<IResponse<string>> {
    return this.http.post<IResponse<string>>(this.loginApi, loginCredentials, {
      withCredentials: true,
      headers: {
        credentials: 'include',
      },
    });
  }

  verifyOtp(
    email: string,
    otp: string | null | undefined
  ): Observable<IResponse<string>> {
    const body = { email, otp };
    return this.http.post<IResponse<string>>(`${this.verifyOtpApi}`, body, {
      withCredentials: true,
      headers: {
        credentials: 'include',
      },
    });
  }

  sendOtp(email: string): Observable<IResponse<null>> {
    const body = { email };
    return this.http.post<IResponse<null>>(`${this.sendOtpApi}`, body);
  }

  forgetPassword(email: IForgetPasswordInterface): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(`${this.forgetPasswordApi}`, email);
  }

  resetPassword(
    resetCredentials: IResetPasswordInterface
  ): Observable<IResponse<null>> {
    return this.http.put<IResponse<null>>(
      `${this.resetPasswordApi}`,
      resetCredentials
    );
  }

  //#endregion HTTP_Methods

  //#region Token_Methods

  setToken(token: string) {
    const encryptedToken = CryptoJS.AES.encrypt(
      token,
      SystemConstants.EncryptionKey
    ).toString();

    this.storageHelper.setAsLocal(
      StorageHelperConstant.authToken,
      encryptedToken
    );
  }

  isJwtTokenExpire() {
    return this.jwtService.isTokenExpired(this.getJwtToken());
  }

  isAuthenticate() {
    if (this.getJwtToken() === null || this.getJwtToken() === '') {
      return false;
    } else {
      return true;
    }
  }

  getJwtToken() {
    const encryptedToken = this.storageHelper.getFromLocal(
      StorageHelperConstant.authToken
    );

    const decryptedToken = CryptoJS.AES.decrypt(
      encryptedToken,
      SystemConstants.EncryptionKey
    ).toString(CryptoJS.enc.Utf8);

    return decryptedToken;
  }

  getUserType() {
    const token = this.getJwtToken();
    const userRole =
      this.jwtService.decodeToken(token)?.[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];

    return userRole;
  }

  getUserId() {
    const token = this.getJwtToken();
    const userId = this.jwtService.decodeToken(token)?.['UserId'];
    return userId;
  }

  getUserName() {
    const token = this.getJwtToken();
    const userName =
      this.jwtService.decodeToken(token)?.[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ];

    return userName;
  }

  logOut(): void {
    this.storageHelper.removeFromLocal(StorageHelperConstant.authToken);
    this.router.navigate([RoutingPathConstant.loginUrl]);
  }

  //#endregion Token_Methods
}
