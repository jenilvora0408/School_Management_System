import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiCallConstant } from '../../constants/api-call/apis';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private http: HttpClient) {}

  getCommonEntityList() {
    return this.http.get<any>(ApiCallConstant.GET_COMMON_ENTITY_DATA);
  }
}
