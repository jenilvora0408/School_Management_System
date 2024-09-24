import { Component } from '@angular/core';
import { ILeaveRequestsInterface } from '../../../models/principal/leave-requests';
import { PrincipalService } from '../../../services/principal.service';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbModal,
  NgbPaginationModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';

@Component({
  selector: 'app-leave-requests',
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
    DateFormatPipe
  ],
  templateUrl: './leave-requests.component.html',
  styleUrl: './leave-requests.component.scss',
})
export class LeaveRequestsComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: ILeaveRequestsInterface[] = [];
  searchQuery: string = '';
  sortColumn: string = '';
  sortOrder: string = 'ascending';
  filter: number = 1;
  approvalStatus!: string;
  tagline: string = 'pending';
  fileName= 'ExcelSheet.xlsx';

  constructor(
    private principalService: PrincipalService,
    private modalService: NgbModal,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getLeaveRequestData();
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    this.getLeaveRequestData();
  }

  getLeaveRequestData() {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
    };

    this.principalService
      .getLeaveRequestList(requestPayload as IPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<ILeaveRequestsInterface[]>>
        ) => {
          this.responseData = response.data.records.map((record: any) => ({
            userId: record.userId,
            name: record.name,
            subjectDetails: {
              id: record.id,
              reasonForLeave: record.reasonForLeave,
              startDate: new Date(record.startDate),
              endDate: new Date(record.endDate),
              leaveDuration: record.leaveDuration,
              leaveType: record.leaveType,
              approvalStatus: record.approvalStatus,
              phoneNumber: record.phoneNumber,
              alternatePhoneNumber: record.alternatePhoneNumber,
            } 
          }));
          this.collectionSize = response.data.totalRecords;
        },
        error: (error: HttpErrorResponse) => {
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
  }

  getFormattedPhoneNumber(phoneNumber: string): string {
    return phoneNumber.replace(ValidationPattern.formatPhoneNumber, '');
  }

  onFilter(filterStatus: number, tag: string): void {
    this.tagline = tag;
    this.filter = filterStatus;
    this.getLeaveRequestData();
  }

  openModal(action: string){
    console.log(action);
  }
}
