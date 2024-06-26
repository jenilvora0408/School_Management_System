import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdmitRequestService {
  constructor(private http: HttpClient) {}

  // submitUserData(submitUserData: any) {
  //   console.log(submitUserData);
  //   return this.http.post(submitUserData);
  // }

  submitUserData(formData: any): Observable<any> {
    console.log('hi');
    const endpointUrl = ApiCallConstant.SUBMIT_USER_DATA;
    return this.http.post<any>(endpointUrl, formData);
  }
}
