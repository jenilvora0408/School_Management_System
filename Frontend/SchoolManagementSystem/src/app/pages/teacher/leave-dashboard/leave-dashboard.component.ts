import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { debounceTime, Subject } from 'rxjs';
import { NgClass } from '@angular/common';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { ILeaveRequestListInterface } from '../../../models/teacher/leave-request-list';
import { TeacherService } from '../../../services/teacher.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { IUserPageListRequest } from '../../../shared/models/user-page-list-request';
import { AuthenticationService } from '../../../services/authentication.service';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { CapitalizePipe } from '../../../pipes/capitalize.pipe';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { NgbModal, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CreateLeaveRequestComponent } from '../../../NgbModals/Teacher/create-leave-request/create-leave-request.component';

@Component({
  selector: 'app-leave-dashboard',
  standalone: true,
  templateUrl: './leave-dashboard.component.html',
  styleUrl: './leave-dashboard.component.scss',
  imports: [
    HeaderComponent,
    ButtonComponent,
    NgClass,
    ApprovalStatusPipe,
    CapitalizePipe,
    DateFormatPipe,
    NgbPaginationModule,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class LeaveDashboardComponent {
  private searchSubject = new Subject<string>();
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  searchQuery: string = '';
  sortColumn: string = 'LeaveType';
  sortOrder: string = 'ascending';
  responseData: ILeaveRequestListInterface[] = [];
  filter: number = 1;
  approvalStatus!: string;

  constructor(
    private teacherService: TeacherService,
    private authService: AuthenticationService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getLeaveRequestData();
    this.searchSubject.pipe(debounceTime(500)).subscribe((searchTerm) => {
      this.search(searchTerm);
    });
  }

  onKeyup(searchTerm: string) {
    this.searchSubject.next(searchTerm);
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    this.getLeaveRequestData();
  }

  onFilter(filterStatus: number): void {
    console.log(filterStatus);
    this.filter = filterStatus;
    this.getLeaveRequestData();
  }

  onSort(column: string) {
    console.log('SORT: ', this.sortColumn, this.sortOrder);

    if (this.sortColumn === column) {
      this.sortOrder =
        this.sortOrder === SystemConstants.Ascending
          ? SystemConstants.Descending
          : SystemConstants.Ascending;
    } else {
      this.sortColumn = column;
      this.sortOrder = SystemConstants.Ascending;
    }
    console.log('SORT: ', this.sortColumn, this.sortOrder);
    this.getLeaveRequestData();
  }

  getLeaveRequestData() {
    console.log('Page Data: ', this.page, this.pageSize);

    const requestPayload: IUserPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
      userId: parseInt(this.authService.getUserId()),
    };

    this.teacherService
      .getLeaveRequestList(requestPayload as IUserPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<ILeaveRequestListInterface[]>>
        ) => {
          console.log('request list: ', response);
          this.responseData = response.data.records;
          console.log('Final response: ', this.responseData);
          this.collectionSize = response.data.totalRecords;
        },
        error: (error: HttpErrorResponse) => {
          console.log(error);
        },
      });
  }

  createLeaveRequest(): void {
    console.log('hii');
    this.modalService.open(CreateLeaveRequestComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });
  }
}
