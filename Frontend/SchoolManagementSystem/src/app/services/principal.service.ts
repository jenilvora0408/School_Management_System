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
import { IContactPrincipalListInterface } from '../models/principal/contact-principal-list';
import { IContactPrincipalResponse } from '../models/principal/contact-principal-response';
import { ICourseListForClassSubjectInterface } from '../models/principal/course-list-for-class-subject';
import { ISubmitCourseInfo } from '../models/principal/submit-course-info';

@Injectable({
  providedIn: 'root',
})
export class PrincipalService {
  getAllSubjectsApi = ApiCallConstant.GET_ALL_SUBJECTS_BY_CLASS_ID;
  editClassApi = ApiCallConstant.EDIT_CLASS;
  leaveRequestApi = ApiCallConstant.LEAVE_REQUESTS;
  contactPrincipalApi = ApiCallConstant.CONTACT_PRINCIPAL_REQUESTS;
  contactPrincipalDocumentsAPi =
    ApiCallConstant.GET_CONTACT_PRINCIPAL_DOCUMENTS;
  postContactPrincipalResponseApi =
    ApiCallConstant.POST_CONTACT_PRINCIPAL_RESPONSE;
  getChaptersForClassSubjectApi =
    ApiCallConstant.GET_CHAPTERS_FOR_CLASS_SUBJECT;
  upsertCourseChaptersApi = ApiCallConstant.UPSERT_COURSE_CHAPTERS;
  allSubjectsForPrincipalApi = ApiCallConstant.GET_ALL_SUBJECTS_FOR_PRINCIPAL;

  constructor(private http: HttpClient) {}

  getAllSubjectsByClass(
    classId: number
  ): Observable<IResponse<ISubjectsListInterface[]>> {
    return this.http.get<IResponse<ISubjectsListInterface[]>>(
      `${this.getAllSubjectsApi}/${classId}`
    );
  }

  submitClassInfo(
    requestCredentials: IClassInfoInterface
  ): Observable<IResponse<null>> {
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

  getContactPrincipalRequests(
    listCredentials: IPageListRequest
  ): Observable<
    IResponse<IPageListResponse<IContactPrincipalListInterface[]>>
  > {
    return this.http.post<
      IResponse<IPageListResponse<IContactPrincipalListInterface[]>>
    >(this.contactPrincipalApi, listCredentials);
  }

  getContactPrincipalDocuments(id: number): Observable<IResponse<string[]>> {
    return this.http.get<IResponse<string[]>>(
      `${this.contactPrincipalDocumentsAPi}/${id}`
    );
  }

  postContactPrincipalResponse(
    requestCredentials: IContactPrincipalResponse
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.postContactPrincipalResponseApi}`,
      requestCredentials
    );
  }

  getChaptersForClassSubject(
    id: number
  ): Observable<IResponse<ICourseListForClassSubjectInterface[]>> {
    return this.http.get<IResponse<ICourseListForClassSubjectInterface[]>>(
      `${this.getChaptersForClassSubjectApi}/${id}`
    );
  }

  submitChaptersInfo(
    requestCredentials: ISubmitCourseInfo
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.upsertCourseChaptersApi}`,
      requestCredentials
    );
  }

  getAllSubjects(
    listCredentials: IPageListRequest
  ): Observable<IResponse<IPageListResponse<ISubjectsListInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<ISubjectsListInterface[]>>
    >(this.allSubjectsForPrincipalApi, listCredentials);
  }
}
