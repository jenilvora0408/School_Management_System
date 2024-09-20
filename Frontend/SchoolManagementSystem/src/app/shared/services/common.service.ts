import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../../constants/api-call/apis';
import { IClassListResponseInterface } from '../../models/teacher/classes-list-response';
import { Observable } from 'rxjs';
import { IResponse } from '../models/IResponse';
import { ITeachersListInterface } from '../../models/teacher/teachers-list';
import { ISubjectsListInterface } from '../../models/principal/subjects-list';
import { IMyProfileInterface } from '../../models/common/my-profile';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private http: HttpClient) {}

  getCommonEntityList() {
    return this.http.get<any>(ApiCallConstant.GET_COMMON_ENTITY_DATA);
  }

  getAllClassesInfo(): Observable<IResponse<IClassListResponseInterface[]>> {
    return this.http.get<IResponse<IClassListResponseInterface[]>>(
      ApiCallConstant.GET_ALL_CLASSES_INFO
    );
  }

  getAllTeachers(): Observable<IResponse<ITeachersListInterface[]>> {
    return this.http.get<IResponse<ITeachersListInterface[]>>(
      ApiCallConstant.GET_ALL_TEACHERS
    );
  }

  getAllSubjects(): Observable<IResponse<ISubjectsListInterface[]>> {
    return this.http.get<IResponse<ISubjectsListInterface[]>>(
      ApiCallConstant.GET_ALL_SUBJECTS
    );
  }

  getMyProfile(userId: number): Observable<IResponse<IMyProfileInterface>> {
    return this.http.get
    <IResponse<IMyProfileInterface>>(`${ApiCallConstant.GET_MY_PROFILE}/${userId}`);
  }

  updateUserProfile(
    listCredentials: IMyProfileInterface
  ): Observable<IResponse<string>> {
    return this.http.put<
      IResponse<string>
    >(ApiCallConstant.UPDATE_USER_PROFILE, listCredentials);
  }
}
