import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { NgClass } from '@angular/common';
import { Panel } from '../../../shared/models/panel';
import { PrincipalService } from '../../../services/principal.service';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { LoaderService } from '../../../shared/services/loader.service';
import { ContactPrincipalTaglineConstants } from '../../../constants/shared/system-constants';
import {
  NgbDropdownModule,
  NgbPaginationModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-requests',
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
  templateUrl: './contact-requests.component.html',
  styleUrl: './contact-requests.component.scss',
})
export class ContactRequestsComponent {
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
    private principalService: PrincipalService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getContactRequestData();
  }

  getContactRequestData(): void {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
    };

    console.log(requestPayload);
    

    this.loaderService.show();

    this.principalService
      .getContactPrincipalRequests(requestPayload)
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

  viewContactRequest(id: number) {
    const matchedRequest = this.requestData.find(
      (request) => request.contactPrincipalId === id
    );

    this.router.navigate(['principal/view-contact-request'], {
      state: { exportData: [matchedRequest] },
    });
  }
}
