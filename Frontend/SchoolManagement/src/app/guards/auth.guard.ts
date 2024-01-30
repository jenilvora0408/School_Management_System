import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router, CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MessageService } from '../shared/services/message.service';
import { RoutingPathConstant } from '../constants/routing/routing-path';
import { SystemConstant, UserRole } from '../constants/shared/system-constant';
import { MessageConstant } from '../constants/validation/message-constants';

export function AuthGuard(): CanActivateFn {
  return (next: ActivatedRouteSnapshot) => {
    const authService = inject(AuthService);
    const messageService = inject(MessageService);
    const router = inject(Router);

    const expectedRole = next.data[SystemConstant.expectedRole];
    const isAuthenticated = authService.isAuthenticate();
    const userRole = authService.getUserType();
    if (!isAuthenticated) {
      messageService.error(MessageConstant.loginFirst, MessageConstant.close);
      router.navigate([RoutingPathConstant.loginUrl]);
      return false;
    }

    if (
      userRole === UserRole.principalRoleId &&
      expectedRole !== UserRole.principal
    ) {
      messageService.error(MessageConstant.unauthorize, MessageConstant.close);
      router.navigate([RoutingPathConstant.unauthorizeUrl]);
      return false;
    }

    if (
      userRole === UserRole.teacherRoleId &&
      expectedRole !== UserRole.teacher
    ) {
      messageService.error(MessageConstant.unauthorize, MessageConstant.close);
      router.navigate([RoutingPathConstant.unauthorizeUrl]);
      return false;
    }

    if (
      userRole === UserRole.studentRoleId &&
      expectedRole !== UserRole.student
    ) {
      messageService.error(MessageConstant.unauthorize, MessageConstant.close);
      router.navigate([RoutingPathConstant.unauthorizeUrl]);
      return false;
    }
    return true;
  };
}
