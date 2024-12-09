import { NgClass } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbHighlight,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { IChaptersOfClassSubjectInterface } from '../../../models/teacher/chapters-of-class-subject';
import { TeacherService } from '../../../services/teacher.service';
import { LoaderService } from '../../../shared/services/loader.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IAdmitRequestListInterface } from '../../../models/teacher/admit-request-list';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { IClassSubjectPageListRequestInterface } from '../../../shared/models/class-subject-page-list-request';

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
    ApprovalStatusPipe,
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
  approvalStatus!: string;
  tagline: string = 'pending';
  classId: number = 0;
  subjectId: number = 0;

  constructor(
    private teacherService: TeacherService,
    private modalService: NgbModal,
    private notificationService: NotificationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.getChaptersData();
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
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
      classId: 0,
      subjectId: 0
    };

    this.loaderService.show();

    this.teacherService
      .getChaptersOfClassSubject(requestPayload as IPageListRequest)
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
