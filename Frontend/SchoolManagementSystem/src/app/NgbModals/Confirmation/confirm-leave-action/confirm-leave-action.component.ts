import { NgClass } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CapitalizePipe } from '../../../pipes/capitalize.pipe';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ILeaveRequestsInterface } from '../../../models/principal/leave-requests';
import { ILeaveApprovalInterface } from '../../../models/common/leave-approval';
import { CommonService } from '../../../shared/services/common.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-confirm-leave-action',
  standalone: true,
  imports: [DateFormatPipe, ButtonComponent, CapitalizePipe, NgClass],
  templateUrl: './confirm-leave-action.component.html',
  styleUrl: './confirm-leave-action.component.scss',
})
export class ConfirmLeaveActionComponent {
  @Input() leaveData!: ILeaveRequestsInterface;
  @Input() status: number = 0;
  @Output() actionCompleted = new EventEmitter<void>();
  userName: string = '';
  actionWord: string = '';

  constructor(
    private modalService: NgbModal,
    private commonService: CommonService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.userName = this.leaveData.name;

    if (this.status == 2) this.actionWord = 'approve';
    else if (this.status == 3) this.actionWord = 'decline';
  }

  close(): void {
    this.modalService.dismissAll();
  }

  leaveAction(): void {
    const payload: ILeaveApprovalInterface = {
      leaveId: this.leaveData.subjectDetails.id,
      approvalStatus: this.status,
    };

    this.commonService.leaveAction(payload).subscribe({
      next: (response: IResponse<null>) => {
        if (response.success) {
          this.modalService.dismissAll();
          this.notificationService.success(response.message);
          this.actionCompleted.emit();
        }
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }
}
