import { Injectable, inject } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { NotificationService } from '../shared/services/notification.service';
import { AuthenticationService } from '../services/authentication.service';
import { NotificationMessageConstant } from '../constants/notification/notification-message';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authService: AuthenticationService,
    private messageService: NotificationService
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const isAuthenticated = this.authService.isAuthenticate();

    if (!isAuthenticated) {
      this.messageService.error(NotificationMessageConstant.loginFirst);
      this.router.navigate(['/']);
      return false;
    }
    return true;
  }
}
