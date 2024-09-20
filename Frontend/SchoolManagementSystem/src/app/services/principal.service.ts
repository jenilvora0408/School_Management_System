import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILeavesCountInterface } from '../models/teacher/leaves-count';
import { IResponse } from '../shared/models/IResponse';
import { ISubjectsListInterface } from '../models/principal/subjects-list';
import { ApiCallConstant } from '../constants/api-call/apis';
import { IClassInfoInterface } from '../models/principal/class-info';

@Injectable({
  providedIn: 'root',
})
export class PrincipalService {
  getAllSubjectsApi = ApiCallConstant.GET_ALL_SUBJECTS_BY_CLASS_ID;
  editClassApi = ApiCallConstant.EDIT_CLASS;

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
}
