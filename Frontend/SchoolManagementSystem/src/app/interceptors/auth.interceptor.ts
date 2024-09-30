import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders,
} from '@angular/common/http';
import { finalize, Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';
import { LoaderService } from '../shared/services/loader.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationService, private loaderService: LoaderService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const authToken = this.authService.getJwtToken();
    this.loaderService.show();
    if (authToken === null || authToken === '') return next.handle(request);
    const authRequest = request.clone({
      setHeaders: {
        Authorization: `${authToken}`,
        'Access-Control-Allow-Origin': 'http://localhost:4200',
        Accept: 'application/pdf',
      },
      withCredentials: true,
    });
    return next.handle(authRequest).pipe(
      finalize(() => this.loaderService.hide())
    );;
  }
}
