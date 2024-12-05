import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { CommonService } from '../../../shared/services/common.service';
import { IClassListResponseInterface } from '../../../models/teacher/classes-list-response';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { ButtonComponent } from '../../../shared/components/button/button.component';

@Component({
  selector: 'app-classes-subjects',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent],
  templateUrl: './classes-subjects.component.html',
  styleUrl: './classes-subjects.component.scss',
})
export class ClassesSubjectsComponent {
  responseData: IClassListResponseInterface[] = [];

  constructor(
    private commonService: CommonService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getAllClassesInfo();
  }

  getAllClassesInfo() {
    this.commonService.getAllClassesInfo().subscribe({
      next: (response: IResponse<IClassListResponseInterface[]>) => {
        console.log('common classes: ', response);
        this.responseData = response.data;
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  editClass(classId: number, classTeacherName: string, classStrength: number, className: string) {
    this.router.navigate(['principal/edit-class'], {
      queryParams: {
        classId: CryptoJS.AES.encrypt(
          classId.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
        classTeacherName: CryptoJS.AES.encrypt(
          classTeacherName ?? '',
          SystemConstants.EncryptionKey
        ),
        classStrength: CryptoJS.AES.encrypt(
          classStrength.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
        className: CryptoJS.AES.encrypt(
          className.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
      },
    });
  }

  navigateBack(): void {
    this.router.navigate(['/principal']);
  }
}
