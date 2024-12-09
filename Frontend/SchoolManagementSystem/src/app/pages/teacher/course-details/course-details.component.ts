import { NgClass } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbHighlight,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { IChaptersOfClassSubjectInterface } from '../../../models/teacher/chapters-of-class-subject';
import { TeacherService } from '../../../services/teacher.service';
import { LoaderService } from '../../../shared/services/loader.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { IClassSubjectPageListRequestInterface } from '../../../shared/models/class-subject-page-list-request';
import { ActivatedRoute } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { CapitalizePipe } from '../../../pipes/capitalize.pipe';

@Component({
  selector: 'app-course-details',
  standalone: true,
  imports: [
    NgbDropdownModule,
    HeaderComponent,
    InputComponent,
    NgbPaginationModule,
    NgbTypeaheadModule,
    NgbHighlight,
    ReactiveFormsModule,
    FormsModule,
    NgClass,
    CapitalizePipe
  ],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.scss',
})
export class CourseDetailsComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: IChaptersOfClassSubjectInterface[] = [];
  searchQuery: string = '';
  sortColumn: string = 'ProbableWeightageInExam';
  sortOrder: string = 'ascending';
  filter: number = 1;
  classId: number = 0;
  subjectId: number = 0;
  className: string = '';
  subjectName: string = '';

  constructor(
    private teacherService: TeacherService,
    private notificationService: NotificationService,
    private loaderService: LoaderService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.decryptQueryParams();
    console.log(this.classId, this.subjectId);
    this.getChaptersData();
  }

  decryptQueryParams():void{
    this.route.queryParams.subscribe((params) => {
      this.classId = parseInt(CryptoJS.AES.decrypt(
        params['classId'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8));
      this.subjectId = parseInt(CryptoJS.AES.decrypt(
        params['subjectId'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8));
      this.className = CryptoJS.AES.decrypt(
        params['className'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.subjectName = CryptoJS.AES.decrypt(
        params['subjectName'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
    });
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    if(this.searchQuery.length >= 3)
      this.getChaptersData();
    else if(this.searchQuery.length == 0)
      this.getChaptersData();
  }

  onSort(column: string) {
    if (this.sortColumn === column) {
      this.sortOrder =
        this.sortOrder === SystemConstants.Ascending
          ? SystemConstants.Descending
          : SystemConstants.Ascending;
    } else {
      this.sortColumn = column;
      this.sortOrder = SystemConstants.Ascending;
    }
    this.getChaptersData();
  }

  getChaptersData() {
    const requestPayload: IClassSubjectPageListRequestInterface = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
      classId: this.classId,
      subjectId: this.subjectId
    };

    this.loaderService.show();

    this.teacherService
      .getChaptersOfClassSubject(requestPayload as IClassSubjectPageListRequestInterface)
      .subscribe({
        next: (
          response: IResponse<
            IPageListResponse<IChaptersOfClassSubjectInterface[]>
          >
        ) => {
          this.responseData = response.data.records;
          this.collectionSize = response.data.totalRecords;
          this.loaderService.hide();
        },
        error: (error: HttpErrorResponse) => {
          this.loaderService.hide();
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
  }
}
