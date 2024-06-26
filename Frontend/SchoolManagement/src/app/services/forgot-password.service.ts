import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from 'src/app/constants/api-call/apis';

@Injectable({
  providedIn: 'root',
})
export class ForgotPasswordService {
  forgotPasswordApi = ApiCallConstant.FORGOT_PASSWORD_URL;

  constructor(private http: HttpClient) {}

  forgotPassword(email: string) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers: headers };

    this.http
      .post(this.forgotPasswordApi, JSON.stringify(email), options)
      .subscribe();
  }
}
