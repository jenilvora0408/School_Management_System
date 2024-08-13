import { Pipe, PipeTransform } from '@angular/core';
import { LeaveTypeConstants } from '../constants/shared/system-constants';

@Pipe({
  name: 'leaveType',
  standalone: true,
})
export class LeaveTypePipe implements PipeTransform {
  transform(value: string | null | undefined): string {
    switch (value) {
      case '1':
        return LeaveTypeConstants.sickLeave;
      case '2':
        return LeaveTypeConstants.casualLeave;
      case '3':
        return LeaveTypeConstants.adhocLeave;
      default:
        return 'Leave';
    }
  }
}
