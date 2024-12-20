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
import { LoaderService } from '../../../shared/services/loader.service';
import { Router } from '@angular/router';

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
    private notificationService: NotificationService,
    private loaderService: LoaderService,
    private router: Router
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
    this.loaderService.show();
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

    this.loaderService.hide();

    XLSX.writeFile(wb, this.excelFfileName);
  }

  savePDF(): void {
    this.loaderService.show();

    const doc = new jsPDF({
      orientation: 'portrait',
      unit: 'pt',
      format: 'a2',
    });

    const datePipe = new DateFormatPipe();
    const approvalStatusPipe = new ApprovalStatusPipe();

    // Add Title
    doc.setFontSize(18);
    doc.setTextColor(40);
    doc.text('Leave Requests', 40, 40);

    // Define Table Headers
    const headers = [
      {
        content: 'Name',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Reason for Leave',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Phone Number',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Start Date',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'End Date',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Status',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
    ];

    // Prepare Table Data
    const tableData = this.responseData.map((item) => [
      { content: item.name, styles: { halign: 'center' } },
      {
        content: item.subjectDetails.reasonForLeave,
        styles: { halign: 'center' },
      },
      {
        content: item.subjectDetails.phoneNumber,
        styles: { halign: 'center' },
      },
      { content: datePipe.transform(item.subjectDetails.startDate), styles: { halign: 'center' } },
      { content: datePipe.transform(item.subjectDetails.endDate), styles: { halign: 'center' } },
      {
        content: approvalStatusPipe.transform(item.subjectDetails.approvalStatus),
        styles: { halign: 'center' },
      },
    ]);

    // Add the Table to PDF
    (doc as any).autoTable({
      head: [headers],
      body: tableData,
      startY: 80,
      theme: 'grid',
      styles: {
        font: 'helvetica',
        fontSize: 10,
        cellPadding: 5,
        textColor: [40, 40, 40],
        lineColor: [41, 128, 185],
        lineWidth: 0.5,
      },
      alternateRowStyles: {
        fillColor: [245, 245, 245],
      },
      headStyles: {
        fontSize: 12,
        halign: 'center',
      },
      bodyStyles: {
        fontSize: 10,
      },
    });

    this.loaderService.hide();

    // Save the PDF
    doc.save(this.pdfFileName);
  }

  navigateBack(): void {
    this.router.navigate(['/principal']);
  }
}
