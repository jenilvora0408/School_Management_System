import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { RoutingPathConstant } from '../constants/routing/routing-path';
import { StorageHelperConstant } from '../constants/storage-helper/storage-helper';
import { ILoginInterface } from '../models/auth/login.interface';
import { StorageHelperService } from '../shared/services/storage-helper.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  admitRequestApi = ApiCallConstant.CREATE_ADMIT_REQUEST;
  loginApi = ApiCallConstant.LOGIN_URL;
  constructor(
    private http: HttpClient,
    private storageHelper: StorageHelperService,
    private router: Router
  ) {}

  createAdmitRequest(admitRequestData: any): Observable<any> {
    console.log(admitRequestData);

    return this.http.post<any>(this.admitRequestApi, admitRequestData);
  }

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
