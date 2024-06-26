import {
  HTTP_INTERCEPTORS,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
} from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, finalize, tap } from 'rxjs';
import { MessageService } from '../shared/services/message.service';
import { LoaderService } from '../shared/services/loader.service';
import { SystemConstant } from '../constants/shared/system-constant';
import { IResponse } from '../shared/models/iresponse';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  private messageService = inject(MessageService);
  private loaderService = inject(LoaderService);

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      tap((event: HttpEvent<any>) => {
        this.loaderService.setLoader(true);
        if (
          event instanceof HttpResponse &&
          (req.method === SystemConstant.post ||
            req.method === SystemConstant.delete ||
            req.method === SystemConstant.put) &&
          event.body.message &&
          event.body.message !== 'Success' &&
          event.body.message?.length > 0
        ) {
          const response: IResponse<null> = event.body;
          this.messageService.success(response.message);
        }
      }),
      finalize(() => this.loaderService.setLoader(false))
    );
  }
}

export const API_INTERCEPTOR = {
  multi: true,
  useClass: ApiInterceptor,
  provide: HTTP_INTERCEPTORS,
};
