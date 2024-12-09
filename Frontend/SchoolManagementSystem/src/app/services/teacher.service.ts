import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { IPageListRequest } from '../shared/models/page-list-request';
import { BehaviorSubject, Observable } from 'rxjs';
import { IResponse } from '../shared/models/IResponse';
import { IPageListResponse } from '../shared/models/page-list-response';
import { IAdmitRequestListInterface } from '../models/teacher/admit-request-list';
import { IViewAdmitRequestInterface } from '../models/teacher/view-admit-request';
import { ILeaveRequestListInterface } from '../models/teacher/leave-request-list';
import { IUserPageListRequest } from '../shared/models/user-page-list-request';
import { ICreateLeaveRequestInterface } from '../models/teacher/create-leave-request';
import { ILeavesCountInterface } from '../models/teacher/leaves-count';
import { ISubjectTeacherInfoInterface } from '../models/teacher/subject-teacher-info';
import { IChaptersOfClassSubjectInterface } from '../models/teacher/chapters-of-class-subject';

@Injectable({
  providedIn: 'root',
})
export class TeacherService {
  getAdmitRequestListApi = ApiCallConstant.GET_ADMIT_REQUEST_LIST;
  getLeaveRequestListApi = ApiCallConstant.GET_LEAVE_REQUEST_LIST;
  viewAdmitRequestListApi = ApiCallConstant.VIEW_ADMIT_REQUEST;
  admitRequestApprovalApi = ApiCallConstant.ADMIT_REQUEST_APPROVAL;
  createLeaveRequestApi = ApiCallConstant.CREATE_LEAVE_REQUEST;
  getLeavesCountApi = ApiCallConstant.GET_LEAVES_COUNT;
  getClassesForSubjectTeacherApi = ApiCallConstant.GET_CLASSES_FOR_SUBJECT_TEACHER;
  chaptersOfClassSubjectApi = ApiCallConstant.CHAPTERS_OF_CLASS_SUBJECT;

  constructor(private http: HttpClient) {}

  getAdmitRequestList(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<IAdmitRequestListInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<IAdmitRequestListInterface[]>>
    >(this.getAdmitRequestListApi, listCredentials);
  }

  getLeaveRequestList(
    listCredentials: IUserPageListRequest
  ): Observable<IResponse<IPageListResponse<ILeaveRequestListInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<ILeaveRequestListInterface[]>>
    >(this.getLeaveRequestListApi, listCredentials);
  }

  getAdmitRequest(
    id: number
  ): Observable<IResponse<IViewAdmitRequestInterface>> {
    return this.http.get<IResponse<IViewAdmitRequestInterface>>(
      `${this.viewAdmitRequestListApi}/${id}`
    );
  }

  admitRequestApproval(requestCredentials: any): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.admitRequestApprovalApi}`,
      requestCredentials
    );
  }

  createLeaveRequest(
    requestCredentials: ICreateLeaveRequestInterface
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.createLeaveRequestApi}`,
      requestCredentials
    );
  }

  getLeavesCount(userId: number): Observable<IResponse<ILeavesCountInterface>> {
    return this.http.get<IResponse<ILeavesCountInterface>>(
      `${this.getLeavesCountApi}/${userId}`
    );
  }

  getClassesForSubjectTeacher(
    userId: number
  ): Observable<IResponse<ISubjectTeacherInfoInterface>> {
    return this.http.get<IResponse<ISubjectTeacherInfoInterface>>(
      `${this.getClassesForSubjectTeacherApi}/${userId}`
    );
  }

  getChaptersOfClassSubject(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<IChaptersOfClassSubjectInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<IChaptersOfClassSubjectInterface[]>>
    >(this.chaptersOfClassSubjectApi, listCredentials);
  }
}
