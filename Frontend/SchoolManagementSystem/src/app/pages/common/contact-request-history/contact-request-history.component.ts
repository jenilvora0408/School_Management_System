import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { CommonService } from '../../../shared/services/common.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IResponse } from '../../../shared/models/IResponse';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { Router } from '@angular/router';
import {
  ContactPrincipalTaglineConstants,
  SystemConstants,
} from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { PrincipalService } from '../../../services/principal.service';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { Panel } from '../../../shared/models/panel';
import { LoaderService } from '../../../shared/services/loader.service';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { IUserPageListRequest } from '../../../shared/models/user-page-list-request';

@Component({
  selector: 'app-contact-request-history',
  standalone: true,
  imports: [
    HeaderComponent,
    NgbDropdownModule,
    HeaderComponent,
    InputComponent,
    NgbPaginationModule,
    ReactiveFormsModule,
    FormsModule,
    NgClass,
    DateFormatPipe,
    ButtonComponent,
  ],
  templateUrl: './contact-request-history.component.html',
  styleUrl: './contact-request-history.component.scss',
})
export class ContactRequestHistoryComponent {
  filters = [
    'All',
    'Harassment',
    'Awareness',
    'Notice',
    'External Help',
    'Other',
  ];
  selectedFilter: string | null = null;
  selectedTagline: string = ContactPrincipalTaglineConstants.all;
  panels: Panel[] = [];
  page = 1;
  pageSize = 10;
  searchQuery: string = '';
  sortColumn: string = '';
  sortOrder: string = 'ascending';
  filter: number = 0;
  collectionSize!: number;
  requestData: IContactPrincipalListInterface[] = [];
  taglines: { [key: string]: string } = {
    All: ContactPrincipalTaglineConstants.all,
    Harassment: ContactPrincipalTaglineConstants.harassment,
    Awareness: ContactPrincipalTaglineConstants.awareness,
    Notice: ContactPrincipalTaglineConstants.notice,
    'External Help': ContactPrincipalTaglineConstants.externalHelp,
    Other: ContactPrincipalTaglineConstants.other,
  };

  exportData!: IContactPrincipalListInterface[];

  constructor(
    private loaderService: LoaderService,
    private router: Router,
    private commonService: CommonService,
    private authService: AuthenticationService,
  ) {}

  ngOnInit(): void {
    this.getContactRequestData();
  }

  getContactRequestData(): void {
    const requestPayload: IUserPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
      userId: this.authService.getUserId()
    };

    this.loaderService.show();

    this.commonService
      .getOwnContactRequestsHistory(requestPayload)
      .subscribe(
        (
          response: IResponse<
            IPageListResponse<IContactPrincipalListInterface[]>
          >
        ) => {
          this.requestData = response.data.records;
          this.collectionSize = response.data.totalRecords;
          this.loaderService.hide();
          console.log(this.requestData);
        }
      );
  }

  onFilterSelect(filter: string) {
    if (this.selectedFilter === filter) return;
    this.selectedFilter = filter;
    this.selectedTagline = this.taglines[filter];

    switch (filter) {
      case 'All':
        this.filter = 0;
        break;
      case 'Harassment':
        this.filter = 1;
        break;
      case 'Awareness':
        this.filter = 2;
        break;
      case 'Notice':
        this.filter = 3;
        break;
      case 'External Help':
        this.filter = 4;
        break;
      case 'Other':
        this.filter = 5;
        break;
      default:
        console.log(ValidationMessageConstant.filterError);
    }

    this.getContactRequestData();
  }

  clearFilter(event: Event) {
    event.stopPropagation();
    this.selectedFilter = null;
    this.filter = 0;
    this.selectedTagline = this.taglines['All'];
    this.getContactRequestData();
  }

  viewContactRequest(contactPrincipalId: number) {
    const matchedRequest = this.requestData.find(
      (request) => request.contactPrincipalId === contactPrincipalId
    );

    this.router.navigate(['/my-contact-request'], {
      queryParams: {
        contactPrincipalId: CryptoJS.AES.encrypt(
          contactPrincipalId.toString() ?? '',
          SystemConstants.EncryptionKey
        )
      },
      state: { exportData: [matchedRequest] },
    },
  );
  }

  navigateBack(): void {
      this.router.navigate(['/contact-request-options']);
  }
}
