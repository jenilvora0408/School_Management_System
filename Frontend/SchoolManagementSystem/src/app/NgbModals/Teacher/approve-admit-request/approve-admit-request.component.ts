import { Component, Injector, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from '../../../services/authentication.service';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';

@Component({
  selector: 'app-approve-admit-request',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormSubmitDirective,
    TextareaComponent,
    ButtonComponent,
  ],
  templateUrl: './approve-admit-request.component.html',
  styleUrl: './approve-admit-request.component.scss',
})
export class ApproveAdmitRequestComponent {
  @Input() id: number = 0;

  approveAdmitRequestForm = new FormGroup({
    comment: new FormControl(''),
  });

  constructor(
    private modalService: NgbModal,
    private injector: Injector,
    private authService: AuthenticationService,
    private teacherService: TeacherService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {}

  onSubmit(): void {
    console.log(this.approveAdmitRequestForm.value);

    const payload: any = {
      comment: this.approveAdmitRequestForm.value.comment,
      admitRequestId: this.id,
      approvalStatus: 2,
      approvedBy: parseInt(this.authService.getUserId()),
      declinedBy: 0,
      blockedBy: 0,
      reasonForBlock: null,
    };

    console.log('onSubmit', payload);

    this.teacherService.admitRequestApproval(payload).subscribe({
      next: (response: IResponse<null>) => {
        console.log('admitRequestApproval: ', response);

        if (response.success) {
          this.modalService.dismissAll();
          this.notificationService.success(response.message);
        }
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }

  close(): void {
    this.modalService.dismissAll();
  }
}
