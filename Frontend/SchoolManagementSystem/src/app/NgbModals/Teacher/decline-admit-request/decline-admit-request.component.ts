import { Component, Injector, Input } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from '../../../services/authentication.service';
import { TeacherService } from '../../../services/teacher.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { NotificationService } from '../../../shared/services/notification.service';

@Component({
  selector: 'app-decline-admit-request',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormSubmitDirective,
    TextareaComponent,
    ButtonComponent,
  ],
  templateUrl: './decline-admit-request.component.html',
  styleUrl: './decline-admit-request.component.scss',
})
export class DeclineAdmitRequestComponent {
  @Input() id: number = 0;

  declineAdmitRequestForm = new FormGroup({
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
    const payload: any = {
      comment: this.declineAdmitRequestForm.value.comment,
      admitRequestId: this.id,
      approvalStatus: 3,
      approvedBy: 0,
      declinedBy: parseInt(this.authService.getUserId()),
      blockedBy: 0,
      reasonForBlock: null,
    };

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
