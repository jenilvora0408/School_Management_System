import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILeavesCountInterface } from '../models/teacher/leaves-count';
import { IResponse } from '../shared/models/IResponse';
import { ISubjectsListInterface } from '../models/principal/subjects-list';
import { ApiCallConstant } from '../constants/api-call/apis';
import { IClassInfoInterface } from '../models/principal/class-info';
import { IAdmitRequestListInterface } from '../models/teacher/admit-request-list';
import { IPageListRequest } from '../shared/models/page-list-request';
import { IPageListResponse } from '../shared/models/page-list-response';
import { ILeaveRequestsInterface } from '../models/principal/leave-requests';

@Injectable({
  providedIn: 'root',
})
export class PrincipalService {
  getAllSubjectsApi = ApiCallConstant.GET_ALL_SUBJECTS_BY_CLASS_ID;
  editClassApi = ApiCallConstant.EDIT_CLASS;
  leaveRequestApi = ApiCallConstant.LEAVE_REQUESTS;

  constructor(private http: HttpClient) {}

  getAllSubjects(
    classId: number
  ): Observable<IResponse<ISubjectsListInterface[]>> {
    return this.http.get<IResponse<ISubjectsListInterface[]>>(
      `${this.getAllSubjectsApi}/${classId}`
    );
  }

  submitClassInfo(requestCredentials: IClassInfoInterface): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.editClassApi}`,
      requestCredentials
    );
  }

  getLeaveRequestList(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<ILeaveRequestsInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<ILeaveRequestsInterface[]>>
    >(this.leaveRequestApi, listCredentials);
  }
}
