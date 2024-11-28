import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { CommonService } from '../../../shared/services/common.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { Router } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { IPageListRequest } from '../../../shared/models/page-list-request';

@Component({
  selector: 'app-contact-request-history',
  standalone: true,
  imports: [HeaderComponent, DateFormatPipe],
  templateUrl: './contact-request-history.component.html',
  styleUrl: './contact-request-history.component.scss',
})
export class ContactRequestHistoryComponent {
  responseData: IContactPrincipalListInterface[] = [];
  userId: number = 0;
  page = 1;
  pageSize = 10;
  searchQuery: string = '';
  sortColumn: string = '';
  sortOrder: string = 'ascending';
  filter: number = 0;
  collectionSize!: number;

  constructor(
    private commonService: CommonService,
    private authService: AuthenticationService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
    this.getOwnContactRequestData();
  }

  getOwnContactRequestData() {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
    };
    
    this.commonService.getOwnContactRequestsHistory(this.userId).subscribe({
      next: (response: IResponse<IContactPrincipalListInterface[]>) => {
        console.log('own contact requests: ', response);
        this.responseData = response.data;
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  navigateToMyRequest(contactPrincipalId: number){
    const matchedRequest = this.responseData.find(
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
}
