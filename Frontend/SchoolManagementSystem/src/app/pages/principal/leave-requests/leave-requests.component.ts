import { Component, ElementRef, ViewChild } from '@angular/core';
import { ILeaveRequestsInterface } from '../../../models/principal/leave-requests';
import { PrincipalService } from '../../../services/principal.service';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbModal,
  NgbPaginationModule,
  NgbPopoverModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import * as XLSX from 'xlsx';
import jsPDF from 'jspdf';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import html2canvas from 'html2canvas';
import { ConfirmLeaveActionComponent } from '../../../NgbModals/Confirmation/confirm-leave-action/confirm-leave-action.component';

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
    DateFormatPipe,
    NgbPopoverModule,
    ButtonComponent,
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
  excelFfileName = 'LeaveRequestData.xlsx';
  pdfFileName = 'LeaveRequestData.pdf';
  @ViewChild('content') content!: ElementRef;

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
            },
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

  openModal(status: number, leaveId: number) {
    const modalRef = this.modalService.open(ConfirmLeaveActionComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });

    modalRef.componentInstance.leaveData = this.responseData.find(
      (data) => data.subjectDetails.id === leaveId
    );

    modalRef.componentInstance.status = status;

    modalRef.componentInstance.actionCompleted.subscribe(() => {
      this.getLeaveRequestData();
    });
  }

  exportexcel(): void {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(element, {
      raw: true,
    });
    const range = XLSX.utils.decode_range(ws['!ref']!);

    for (let C = range.s.c; C <= range.e.c; ++C) {
      const cellAddress = XLSX.utils.encode_cell({ r: 0, c: C });
      const cell = ws[cellAddress];

      if (cell && cell.v === 'Actions') {
        for (let R = 0; R <= range.e.r; ++R) {
          const removeCellAddress = XLSX.utils.encode_cell({ r: R, c: C });
          delete ws[removeCellAddress];
        }
        ws['!cols'] = ws['!cols'] || [];
        ws['!cols'][C] = { hidden: true };
      }
    }

    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, this.excelFfileName);

    XLSX.writeFile(wb, this.excelFfileName);
  }

  savePDF(): void {
    const doc = new jsPDF({
      orientation: 'portrait',
      unit: 'pt',
      format: 'a2',
    });

    const content = this.content.nativeElement;

    html2canvas(content).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const imgWidth = 1200;
      const pageHeight = 2000;
      const imgHeight = (canvas.height * imgWidth) / canvas.width;
      let heightLeft = imgHeight;
      let position = 0;

      doc.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
      heightLeft -= pageHeight;

      while (heightLeft >= 0) {
        position = heightLeft - imgHeight;
        doc.addPage();
        doc.addImage(imgData, 'PNG', 0, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;
      }

      doc.save(this.pdfFileName);
    });
  }
}
