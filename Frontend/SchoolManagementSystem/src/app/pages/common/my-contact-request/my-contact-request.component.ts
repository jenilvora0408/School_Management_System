import { Component } from '@angular/core';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { PrincipalService } from '../../../services/principal.service';
import { IResponse } from '../../../shared/models/IResponse';
import { CommonService } from '../../../shared/services/common.service';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { Router } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';

@Component({
  selector: 'app-my-contact-request',
  standalone: true,
  imports: [HeaderComponent, DateFormatPipe, ButtonComponent],
  templateUrl: './my-contact-request.component.html',
  styleUrl: './my-contact-request.component.scss',
})
export class MyContactRequestComponent {
  importData!: IContactPrincipalListInterface;
  contactRequestId: number = 0;
  requestDocuments: string[] = [];
  username: string = '';
  subject: string = '';
  requestType: string = '';
  description: string = '';
  ckEditorContent: string = '';
  requestedDate: Date = new Date();
  resolved: boolean = false;
  responseMessage: string = '';

  constructor(
    private principalService: PrincipalService,
    private commonService: CommonService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const importDataArray = history.state
      .exportData as IContactPrincipalListInterface[];
    this.importData = importDataArray[0];

    this.contactRequestId = this.importData.contactPrincipalId;
    this.username = this.importData.userName;
    this.subject = this.importData.subject;
    this.requestType = this.importData.contactTypeTitle;
    this.description = this.importData.description;
    this.requestedDate = this.importData.requestDate;
    this.resolved = this.importData.isResolved;
    this.responseMessage = this.importData.responseMessage;

    this.getContactRequestDocuments(this.contactRequestId);
  }

  getContactRequestDocuments(id: number): void {
    this.principalService
      .getContactPrincipalDocuments(id)
      .subscribe((response: IResponse<string[]>) => {
        this.requestDocuments = response.data;
        console.log(this.requestDocuments);
      });
  }

  downloadImage(imageUrl: string, index: number) {
    this.commonService.downloadImage(imageUrl, index);
  }

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.contactRequestHistoryUrl]);
  }
}
