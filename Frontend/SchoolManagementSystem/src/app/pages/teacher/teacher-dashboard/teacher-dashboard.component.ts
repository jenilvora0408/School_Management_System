import { Component, Injector } from '@angular/core';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbModal,
  NgbPaginationModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IAdmitRequestListInterface } from '../../../models/teacher/admit-request-list';
import { InputComponent } from '../../../shared/components/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Subject } from 'rxjs';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NgClass } from '@angular/common';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { ViewAdmitRequestComponent } from '../../../NgbModals/Teacher/view-admit-request/view-admit-request.component';
import { NotificationService } from '../../../shared/services/notification.service';
import { LoaderService } from '../../../shared/services/loader.service';
@Component({
  selector: 'app-teacher-dashboard',
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
  templateUrl: './teacher-dashboard.component.html',
  styleUrl: './teacher-dashboard.component.scss',
})
export class TeacherDashboardComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: IAdmitRequestListInterface[] = [];
  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortOrder: string = 'ascending';
  filter: number = 1;
  approvalStatus!: string;
  tagline: string = 'pending';

  constructor(
    private teacherService: TeacherService,
    private modalService: NgbModal,
    private notificationService: NotificationService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    this.loaderService.show();
    this.getAdmitRequestData();
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    this.getAdmitRequestData();
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
    this.getAdmitRequestData();
  }

  getAdmitRequestData() {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
    };

    this.teacherService
      .getAdmitRequestList(requestPayload as IPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<IAdmitRequestListInterface[]>>
        ) => {
          this.responseData = response.data.records;
          this.collectionSize = response.data.totalRecords;
          this.loaderService.hide();
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
    this.getAdmitRequestData();
  }

  viewRequest(id: number): void {
    const modalRef = this.modalService.open(ViewAdmitRequestComponent, {
      centered: true,
      size: 'xl',
      backdrop: 'static',
      injector: Injector.create({
        providers: [
          {
            provide: 'id',
            useValue: id,
          },
        ],
      }),
    });

    modalRef.componentInstance.admitRequestApproved.subscribe(() => {
      this.getAdmitRequestData();
    });

    modalRef.componentInstance.admitRequestDeclined.subscribe(() => {
      this.getAdmitRequestData();
    });

    modalRef.componentInstance.admitRequestBlocked.subscribe(() => {
      this.getAdmitRequestData();
    });
  }
}
