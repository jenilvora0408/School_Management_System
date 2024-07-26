import { Pipe, PipeTransform } from '@angular/core';
import { StatusConstants } from '../constants/shared/system-constants';

@Pipe({
  name: 'approvalStatus',
  standalone: true,
})
export class ApprovalStatusPipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case 1:
        return StatusConstants.pending;
      case 2:
        return StatusConstants.approved;
      case 3:
        return StatusConstants.declined;
      case 5:
        return StatusConstants.blocked;
      default:
        return 'Unknown';
    }
  }
}
