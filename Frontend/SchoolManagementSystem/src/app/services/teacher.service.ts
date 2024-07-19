import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { IPageListRequest } from '../shared/models/page-list-request';
import { Observable } from 'rxjs';
import { IResponse } from '../shared/models/IResponse';
import { IPageListResponse } from '../shared/models/page-list-response';
import { IAdmitRequestInterface } from '../models/auth/admit-request.interface';
import { IAdmitRequestListInterface } from '../models/teacher/admit-request-list';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  getAdmitRequestListApi = ApiCallConstant.GET_ADMIT_REQUEST_LIST;

  constructor(private http: HttpClient) {}

  getAdmitRequestList(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<IAdmitRequestListInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<IAdmitRequestListInterface[]>>
    >(this.getAdmitRequestListApi, listCredentials);
  }
}
