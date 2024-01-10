import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ApiCallConstant } from 'src/app/constants/api-call/apis';
import { NotificationResult } from '../models/notification';
import { SwipeSetting } from '../models/swipe-setting';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private http: HttpClient) {}

  getNotificationCount(): Observable<Number> {
    return this.http
      .get<Number>(`${ApiCallConstant.GET_NOTIFICATION_COUNT}`)
      .pipe(catchError(this.handleError));
  }

  getNotificationMessage(): Observable<NotificationResult[]> {
    return this.http
      .get<NotificationResult[]>(`${ApiCallConstant.GET_NOTIFICATIONS}`)
      .pipe(catchError(this.handleError));
  }

  readNotifications(id: number | null): Observable<any> {
    let params = new HttpParams();
    if (id !== null) {
      params = params.set('notificationId', id.toString());
    }
    return this.http
      .get<any>(`${ApiCallConstant.READ_NOTIFICATIONS}`, { params })
      .pipe(catchError(this.handleError));
  }

  deleteNotifications(id: number | null): Observable<any> {
    let params = new HttpParams();
    if (id !== null) {
      params = params.set('notificationId', id.toString());
    }
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http
      .delete(`${ApiCallConstant.DELETE_NOTIFICATIONS}`, {
        headers: headers,
        params,
      })
      .pipe(catchError(this.handleError));
  }

  getSwipeSetting(): Observable<SwipeSetting> {
    return this.http
      .get<SwipeSetting>(`${ApiCallConstant.GET_SWIPE_SETTING}`)
      .pipe(catchError(this.handleError));
  }

  saveSwipeSetting(swipeSetting: SwipeSetting): Observable<SwipeSetting> {
    return this.http
      .post<SwipeSetting>(ApiCallConstant.SAVE_SWIPE_SETTING, swipeSetting)
      .pipe(catchError(this.handleError));
  }

  private handleError(err: any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
