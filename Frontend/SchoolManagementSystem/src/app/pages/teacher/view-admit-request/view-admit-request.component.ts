import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { TeacherService } from '../../../services/teacher.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IViewAdmitRequestInterface } from '../../../models/teacher/view-admit-request';
import { IResponse } from '../../../shared/models/IResponse';
import { ActivatedRoute } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-view-admit-request',
  standalone: true,
  imports: [HeaderComponent],
  templateUrl: './view-admit-request.component.html',
  styleUrl: './view-admit-request.component.scss',
})
export class ViewAdmitRequestComponent {
  admitRequestId: number = 1;
  requestData!: IViewAdmitRequestInterface;
  constructor(
    private teacherService: TeacherService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.admitRequestId = parseInt(
        CryptoJS.AES.decrypt(
          params['id'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
    });

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

  getApprovalStatusText(status: number): string {
    switch (status) {
      case 1:
        return 'Pending';
      case 2:
        return 'Approved';
      case 3:
        return 'Declined';
      case 5:
        return 'Blocked';
      default:
        return 'Unknown';
    }
  }
}
