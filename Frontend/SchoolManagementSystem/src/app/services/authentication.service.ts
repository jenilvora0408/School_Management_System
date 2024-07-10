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

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  admitRequestApi = ApiCallConstant.CREATE_ADMIT_REQUEST;
  loginApi = ApiCallConstant.LOGIN_URL;
  verifyOtpApi = ApiCallConstant.VERIFY_OTP_URL;
  sendOtpApi = ApiCallConstant.SEND_OTP;
  forgetPasswordApi = ApiCallConstant.FORGET_PASSWORD;
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
    return this.http.post<IResponse<string>>(`${this.verifyOtpApi}`, body);
  }

  sendOtp(email: string): Observable<IResponse<null>> {
    const body = { email };
    return this.http.post<IResponse<null>>(`${this.sendOtpApi}`, body);
  }

  forgetPassword(email: IForgetPasswordInterface): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(`${this.forgetPasswordApi}`, email);
  }

  //#endregion HTTP_Methods

  //#region  Token_Methods

  decodeToken(token: string) {
    const decodedToken = this.jwtService.decodeToken(token);
    const userRole =
      decodedToken[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ];
    const userId = decodedToken['UserId'];
    const userName =
      decodedToken[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ];

    this.storageHelper.setAsLocal(StorageHelperConstant.authToken, token);
    this.storageHelper.setAsLocal(StorageHelperConstant.userRole, userRole);
    this.storageHelper.setAsLocal(StorageHelperConstant.userId, userId);
    this.storageHelper.setAsLocal(StorageHelperConstant.userName, userName);
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
    return this.storageHelper.getFromLocal(StorageHelperConstant.authToken);
  }

  getRefreshToken() {
    return this.storageHelper.getFromLocal(StorageHelperConstant.refreshToken);
  }

  getUserType() {
    return this.storageHelper.getFromLocal(StorageHelperConstant.userRole);
  }

  getUserId() {
    return this.storageHelper.getFromLocal(StorageHelperConstant.userId);
  }

  getUserName() {
    return this.storageHelper.getFromLocal(StorageHelperConstant.userName);
  }

  logOut(): void {
    this.storageHelper.removeFromLocal(StorageHelperConstant.authToken);
    this.storageHelper.removeFromLocal(StorageHelperConstant.refreshToken);
    this.storageHelper.removeFromLocal(StorageHelperConstant.userRole);
    this.storageHelper.removeFromLocal(StorageHelperConstant.userId);
    this.storageHelper.removeFromLocal(StorageHelperConstant.userName);
    this.router.navigate([RoutingPathConstant.loginUrl]);
  }

  //#endregion Token_Methods
}
