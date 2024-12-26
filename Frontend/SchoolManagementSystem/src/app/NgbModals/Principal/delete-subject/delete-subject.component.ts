import { Component, EventEmitter, Injector, Output } from '@angular/core';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PrincipalService } from '../../../services/principal.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IManageSubjectInterface } from '../../../models/principal/manage-subject';
import { IResponse } from '../../../shared/models/IResponse';

@Component({
  selector: 'app-delete-subject',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './delete-subject.component.html',
  styleUrl: './delete-subject.component.scss',
})
export class DeleteSubjectComponent {
  subjectId: number = 0;

  @Output() subjectDeleted = new EventEmitter<void>();

  constructor(
    private modalService: NgbModal,
    private injector: Injector,
    private notificationService: NotificationService,
    private principalService: PrincipalService
  ) {}

  ngOnInit(): void {
    this.subjectId = this.injector.get('subjectId');
  }

  close(): void {
    this.modalService.dismissAll();
  }

  onSubmit(): void {
    const payload: IManageSubjectInterface = {
      subjectId: this.subjectId,
      subjectName: null,
      subjectCode: null,
      subjectTeacherId: 0,
    };

    console.log(payload);

    this.principalService.manageSubject(payload).subscribe({
      next: (response: IResponse<string>) => {
        this.modalService.dismissAll();
        this.subjectDeleted.emit();
        this.notificationService.success(response.data);
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }
}
