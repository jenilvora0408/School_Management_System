import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { IMessage } from '../models/message';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private messageSource = new BehaviorSubject<IMessage | null>(null);
  public currentMessage = this.messageSource.asObservable();
  message: string = '';

  constructor(private toastr: ToastrService) {}

  clear() {
    this.message = '';
    this.messageSource.next(null);
  }

  success(message: string, action?: string) {
    this.toastr.success(message, action, {
      timeOut: 10000,
      positionClass: 'toast-top-right',
    });
  }
  error(message: string, action?: string) {
    this.toastr.error(message, action, {
      timeOut: 3000,
      positionClass: 'toast-top-right',
    });
  }
  info(message: string, action?: string) {
    this.toastr.info(message, action, {
      timeOut: 3000,
      positionClass: 'toast-top-right',
    });
  }
  warning(message: string, action?: string) {
    this.toastr.warning(message, action, {
      timeOut: 3000,
      positionClass: 'toast-top-right',
    });
  }
}
