import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { IPageListRequest } from '../shared/models/page-list-request';
import { Observable } from 'rxjs';
import { IResponse } from '../shared/models/IResponse';
import { IPageListResponse } from '../shared/models/page-list-response';
import { IAdmitRequestListInterface } from '../models/teacher/admit-request-list';
import { IViewAdmitRequestInterface } from '../models/teacher/view-admit-request';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  getAdmitRequestListApi = ApiCallConstant.GET_ADMIT_REQUEST_LIST;
  viewAdmitRequestListApi = ApiCallConstant.VIEW_ADMIT_REQUEST;

  constructor(private http: HttpClient) {}

  getAdmitRequestList(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<IAdmitRequestListInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<IAdmitRequestListInterface[]>>
    >(this.getAdmitRequestListApi, listCredentials);
  }

  getAdmitRequest(
    id: number
  ): Observable<IResponse<IViewAdmitRequestInterface>> {
    return this.http.get<IResponse<IViewAdmitRequestInterface>>(
      `${this.viewAdmitRequestListApi}/${id}`
    );
  }
}
