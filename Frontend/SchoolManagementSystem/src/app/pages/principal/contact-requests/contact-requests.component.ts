import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { NgClass } from '@angular/common';
import { Panel } from '../../../shared/models/panel';
import { PrincipalService } from '../../../services/principal.service';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { AccordionComponent } from '../../../shared/components/accordion/accordion.component';
import { LoaderService } from '../../../shared/services/loader.service';
import { ContactPrincipalTaglineConstants } from '../../../constants/shared/system-constants';

@Component({
  selector: 'app-contact-requests',
  standalone: true,
  imports: [HeaderComponent, NgClass, AccordionComponent],
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
  selectedTagline: string =
  ContactPrincipalTaglineConstants.all;
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

  constructor(
    private principalService: PrincipalService,
    private loaderService: LoaderService
  ) {}

  ngOnInit(): void {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
    };

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
          for (let item of this.requestData) {
            const panel = {
              subject: item.subject,
              description: item.description,
              username: item.userName,
              contactType: item.contactTypeTitle,
              requestDate: item.requestDate,
              relatableEvidence: item.relatableEvidence,
            } as Panel;
            this.panels.push(panel);
          }
          this.loaderService.hide();
          console.log(this.requestData);
        }
      );
  }

  onFilterSelect(filter: string) {
    if (this.selectedFilter === filter) return;
    this.selectedFilter = filter;
    this.selectedTagline = this.taglines[filter];
  }

  clearFilter(event: Event) {
    event.stopPropagation();
    this.selectedFilter = null;
    this.selectedTagline = this.taglines['All'];
  }
}
