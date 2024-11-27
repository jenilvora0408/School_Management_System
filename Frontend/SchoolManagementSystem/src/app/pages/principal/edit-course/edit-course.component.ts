import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { ICourseListForClassSubjectInterface } from '../../../models/principal/course-list-for-class-subject';
import { PrincipalService } from '../../../services/principal.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { CommonService } from '../../../shared/services/common.service';
import { ITeachersListInterface } from '../../../models/teacher/teachers-list';
import { DropdownMenu } from '../../../shared/models/dropdown-menu';
import { ReactiveFormsModule } from '@angular/forms';
import { InputComponent } from '../../../shared/components/input/input.component';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddChapterToSubjectComponent } from '../../../NgbModals/Principal/add-chapter-to-subject/add-chapter-to-subject.component';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { ISubmitCourseInfo } from '../../../models/principal/submit-course-info';

@Component({
  selector: 'app-edit-course',
  standalone: true,
  imports: [
    HeaderComponent,
    ButtonComponent,
    InputComponent,
    SelectComponent,
    ReactiveFormsModule,
  ],
  templateUrl: './edit-course.component.html',
  styleUrl: './edit-course.component.scss',
})
export class EditCourseComponent {
  classSubjectId: number = 0;
  className: string = '';
  subjectName: any = '';
  responseData: ICourseListForClassSubjectInterface[] = [];
  subjectId: number = 0;
  teachersList: DropdownMenu[] = [];

  constructor(
    private route: ActivatedRoute,
    private principalService: PrincipalService,
    private notificationService: NotificationService,
    private modalService: NgbModal,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.decryptQueryParams();
    this.getAllChaptersForClassSubject();
  }

  decryptQueryParams(): void {
    this.route.queryParams.subscribe((params) => {
      this.classSubjectId = parseInt(
        CryptoJS.AES.decrypt(
          params['classSubjectId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
      this.className = CryptoJS.AES.decrypt(
        params['className'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.subjectName = CryptoJS.AES.decrypt(
        params['subjectName'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.subjectId = parseInt(
        CryptoJS.AES.decrypt(
          params['subjectId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
    });
  }

  getAllChaptersForClassSubject(): void {
    this.principalService
      .getChaptersForClassSubject(this.classSubjectId)
      .subscribe({
        next: (response: IResponse<ICourseListForClassSubjectInterface[]>) => {
          this.responseData = response.data;
        },
        error: (error: HttpErrorResponse) => {
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
  }

  onSubmit(): void {
    console.log('submit');

    const payload : ISubmitCourseInfo = {
      classSubjectId: this.classSubjectId,
      addChaptersDTO: this.responseData as ICourseListForClassSubjectInterface[]
    }
    
    this.principalService.submitChaptersInfo(payload).subscribe({
      next: (response: IResponse<null>) => {
        this.router.navigate([RoutingPathConstant.classesAndSubjectsUrl]);
        this.notificationService.success(response.message);
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  addChapters(): void {
    const modalRef = this.modalService.open(AddChapterToSubjectComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });
    modalRef.componentInstance.existingChapters = this.responseData;

    modalRef.componentInstance.chapterAdded.subscribe(
      (subject: ICourseListForClassSubjectInterface) => {
        this.responseData.push(subject);
        console.log(this.responseData);
      }
    );
  }

  deleteChapter(courseId: number): void {
    console.log(courseId);
    const index = this.responseData.findIndex(
      (subject) => subject.courseId === courseId
    );
    if (index !== -1) {
      this.responseData.splice(index, 1);
      this.responseData.forEach((chapter, i) => {
        chapter.chapterSerialNumber = i + 1;
      });
    } else {
      console.log('Course not found with id:', courseId);
    }
    console.log('Updated: ', this.responseData);
  }

  cancelFormData(): void {}
}
