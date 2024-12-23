import { Component } from '@angular/core';
import { ISubjectsListInterface } from '../../../models/principal/subjects-list';
import { PrincipalService } from '../../../services/principal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ILeaveRequestsInterface } from '../../../models/principal/leave-requests';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NotificationService } from '../../../shared/services/notification.service';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbHighlight,
  NgbPopoverModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { Router } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';

@Component({
  selector: 'app-manage-subjects',
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
    DateFormatPipe,
    NgbPopoverModule,
    ButtonComponent,
  ],
  templateUrl: './manage-subjects.component.html',
  styleUrl: './manage-subjects.component.scss',
})
export class ManageSubjectsComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: ISubjectsListInterface[] = [];
  searchQuery: string = '';

  constructor(
    private principalService: PrincipalService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  search(searchTerm: string) {
    if (this.responseData.length == 0 && searchTerm.length >= 3) {
      this.notificationService.warning('Subjects not found!');
      return;
    }

    this.searchQuery = searchTerm;

    if (this.searchQuery.length >= 3) {
      this.page = 1;
      this.getAllSubjectsData();
    } else if (this.searchQuery.length == 0) this.getAllSubjectsData();
  }

  getAllSubjectsData(): void {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: '',
      sortColumn: '',
      searchQuery: this.searchQuery,
      filter: 0,
    };

    this.principalService
      .getAllSubjects(requestPayload as IPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<ISubjectsListInterface[]>>
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

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.principalDashboardUrl]);
  }
}
