import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IContactPrincipalListInterface } from '../../../models/principal/contact-principal-list';
import { PrincipalService } from '../../../services/principal.service';
import { IResponse } from '../../../shared/models/IResponse';

@Component({
  selector: 'app-view-contact-request',
  standalone: true,
  imports: [HeaderComponent],
  templateUrl: './view-contact-request.component.html',
  styleUrl: './view-contact-request.component.scss',
})
export class ViewContactRequestComponent {
  importData!: IContactPrincipalListInterface ;
  contactRequestId: number = 0;
  requestDocuments: string[] = [];
  username: string = '';
  subject: string = '';
  requestType: string = '';
  description: string = '';

  constructor(
    private principalService: PrincipalService
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
    console.log(this.importData, this.contactRequestId);

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
    const link = document.createElement('a');
    link.href = imageUrl;
    link.download = `evidence_${index + 1}`;
    link.click();
  }
  
}
