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
import { debounceTime, Subject } from 'rxjs';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NgClass } from '@angular/common';
import { Router } from '@angular/router';
import {
  StatusConstants,
  SystemConstants,
} from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { ViewAdmitRequestComponent } from '../../../NgbModals/Teacher/view-admit-request/view-admit-request.component';
import { AuthenticationService } from '../../../services/authentication.service';
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
  private searchSubject = new Subject<string>();
  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortOrder: string = 'ascending';
  filter: number = 1;
  approvalStatus!: string;
  constructor(
    private teacherService: TeacherService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getAdmitRequestData();
    this.searchSubject.pipe(debounceTime(1000)).subscribe((searchTerm) => {
      this.search(searchTerm);
    });
  }

  onKeyup(searchTerm: string) {
    this.searchSubject.next(searchTerm);
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    this.getAdmitRequestData();
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
    this.getAdmitRequestData();
  }

  getAdmitRequestData() {
    console.log('Page Data: ', this.page, this.pageSize);

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

  getFormattedPhoneNumber(phoneNumber: string): string {
    return phoneNumber.replace(ValidationPattern.formatPhoneNumber, '');
  }

  onFilter(filterStatus: number): void {
    console.log(filterStatus);
    this.filter = filterStatus;
    this.getAdmitRequestData();
  }

  viewRequest(id: number): void {
    console.log(id);
    this.modalService.open(ViewAdmitRequestComponent, {
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
  }
}
