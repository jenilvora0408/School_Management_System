import { Component, NgModule } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgClass } from '@angular/common';
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
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { ILeavesCountInterface } from '../../../models/teacher/leaves-count';
import { LeaveStatusComponent } from '../../../shared/components/leave-status/leave-status.component';
import { ChartOptions } from 'chart.js';
import { NgChartsModule } from 'ng2-charts';
import { NotificationService } from '../../../shared/services/notification.service';

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
    LeaveStatusComponent,
    NgChartsModule,
  ],
})
export class LeaveDashboardComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  searchQuery: string = '';
  sortColumn: string = '';
  sortOrder: string = '';
  responseData: ILeaveRequestListInterface[] = [];
  filter: number = 2;
  approvalStatus!: string;
  activeStatus: string = 'Approved';

  leavesCountResponse: ILeavesCountInterface = {
    totalRequestsCount: 0,
    approvedRequestsCount: 0,
    pendingRequestsCount: 0,
    declinedRequestCount: 0,
    sickLeavesCount: 0,
    leavesRemainingCount: 0,
  };

  public pieChartOptions: ChartOptions<'pie'> = {
    responsive: false,
  };
  public pieChartLabels = ['Approved', 'Pending', 'Declined', 'Sick Leaves'];
  public pieChartDatasets = [
    {
      data: [0, 0, 0, 0],
    },
  ];
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor(
    private teacherService: TeacherService,
    private authService: AuthenticationService,
    private modalService: NgbModal,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getLeavesCount();
    this.getLeaveRequestData();
  }

  getFormattedPhoneNumber(phoneNumber?: string): string {
    if (phoneNumber != null || phoneNumber != ' ') {
      return phoneNumber!.replace(ValidationPattern.formatPhoneNumber, '');
    } else {
      return '';
    }
  }

  onFilter(statusLabel: string, filterStatus: number): void {
    this.filter = filterStatus;
    this.activeStatus = statusLabel;
    this.getLeaveRequestData();
  }

  getLeavesCount() {
    this.teacherService.getLeavesCount(this.authService.getUserId()).subscribe({
      next: (response: IResponse<ILeavesCountInterface>) => {
        this.leavesCountResponse = response.data;
        this.pieChartDatasets = [
          {
            data: [
              this.leavesCountResponse.approvedRequestsCount,
              this.leavesCountResponse.pendingRequestsCount,
              this.leavesCountResponse.declinedRequestCount,
              this.leavesCountResponse.sickLeavesCount,
            ],
          },
        ];
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  getLeaveRequestData() {
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
          this.responseData = response.data.records;
          this.collectionSize = response.data.totalRecords;
        },
        error: (error: HttpErrorResponse) => {
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
  }

  createLeaveRequest(): void {
    const modalRef = this.modalService.open(CreateLeaveRequestComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });

    modalRef.componentInstance.leaveRequestCreated.subscribe(() => {
      this.getLeaveRequestData();
      this.getLeavesCount();
    });
  }
}
