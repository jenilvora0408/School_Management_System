import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  admitRequestApi = ApiCallConstant.CREATE_ADMIT_REQUEST;
  constructor(private http: HttpClient) {}

  createAdmitRequest(admitRequestData: any): Observable<any> {
    console.log(admitRequestData);

    return this.http.post<any>(this.admitRequestApi, admitRequestData);
  }
}
