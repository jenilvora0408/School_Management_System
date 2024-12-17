import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../constants/api-call/apis';
import { Observable } from 'rxjs';
import { IResponse } from '../shared/models/IResponse';
import { IPageListResponse } from '../shared/models/page-list-response';
import { HttpClient } from '@angular/common/http';
import { IUserPageListRequest } from '../shared/models/user-page-list-request';
import { ISubjectsListForStudentsInterface } from '../models/student/subjects-list';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  studentsSubjectListApi = ApiCallConstant.SUBEJCTS_LIST_FOR_STUDENTS;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  getStudentsSubjectList(
    listCredentials: IUserPageListRequest
  ): Observable<IResponse<IPageListResponse<ISubjectsListForStudentsInterface[]>>> {
    return this.http.post<
      IResponse<IPageListResponse<ISubjectsListForStudentsInterface[]>>
    >(this.studentsSubjectListApi, listCredentials);
  }
}
