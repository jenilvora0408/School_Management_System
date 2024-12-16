import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { AuthenticationService } from '../../../services/authentication.service';
import { IResponse } from '../../../shared/models/IResponse';
import { IUserPageListRequest } from '../../../shared/models/user-page-list-request';
import { HttpErrorResponse } from '@angular/common/http';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NotificationService } from '../../../shared/services/notification.service';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbPaginationModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { InputComponent } from '../../../shared/components/input/input.component';
import { StudentService } from '../../../services/student.service';
import { ISubjectsListForStudentsInterface } from '../../../models/student/subjects-list';

@Component({
  selector: 'app-student-dashboard',
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
  ],
  templateUrl: './student-dashboard.component.html',
  styleUrl: './student-dashboard.component.scss',
})
export class StudentDashboardComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  userId: number = 0;
  responseData: ISubjectsListForStudentsInterface[] = [];
  searchQuery: string = '';
  className: string = '';

  constructor(
    private authService: AuthenticationService,
    private studentService: StudentService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
    this.getSubjectsData();
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    if (this.searchQuery.length >= 3) {
      this.page = 1;
      this.getSubjectsData();
    } else if (this.searchQuery.length == 0) this.getSubjectsData();
  }

  getSubjectsData(): void {
    const payload: IUserPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: '',
      sortColumn: '',
      searchQuery: this.searchQuery,
      filter: 0,
      userId: this.userId,
    };

    this.studentService.getStudentsSubjectList(payload).subscribe({
      next: (
        response: IResponse<IPageListResponse<ISubjectsListForStudentsInterface[]>>
      ) => {
        this.collectionSize = response.data.totalRecords;
        this.responseData = response.data.records;
        this.className = this.responseData[0].className;
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }
}
