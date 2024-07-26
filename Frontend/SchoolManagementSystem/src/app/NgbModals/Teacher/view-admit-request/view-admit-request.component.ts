import { Component, Injector } from '@angular/core';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { IViewAdmitRequestInterface } from '../../../models/teacher/view-admit-request';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-view-admit-request',
  standalone: true,
  imports: [HeaderComponent, ApprovalStatusPipe, ButtonComponent],
  templateUrl: './view-admit-request.component.html',
  styleUrl: './view-admit-request.component.scss',
})
export class ViewAdmitRequestComponent {
  admitRequestId: number = 1;
  requestData!: IViewAdmitRequestInterface;
  constructor(
    private teacherService: TeacherService,
    private route: ActivatedRoute,
    private injector: Injector,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.admitRequestId = this.injector.get('id');

    this.teacherService.getAdmitRequest(this.admitRequestId).subscribe({
      next: (response: IResponse<IViewAdmitRequestInterface>) => {
        this.requestData = response.data;
        console.log('view request ', this.requestData);
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  close() {
    this.modalService.dismissAll();
  }
}
