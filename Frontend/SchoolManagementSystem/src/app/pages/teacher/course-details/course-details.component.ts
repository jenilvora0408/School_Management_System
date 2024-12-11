import { NgClass } from '@angular/common';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbHighlight,
  NgbPopoverModule,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { IChaptersOfClassSubjectInterface } from '../../../models/teacher/chapters-of-class-subject';
import { TeacherService } from '../../../services/teacher.service';
import { LoaderService } from '../../../shared/services/loader.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { IClassSubjectPageListRequestInterface } from '../../../shared/models/class-subject-page-list-request';
import { ActivatedRoute, Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { CapitalizePipe } from '../../../pipes/capitalize.pipe';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import * as XLSX from 'xlsx';
import jsPDF from 'jspdf';
import 'jspdf-autotable';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';

@Component({
  selector: 'app-course-details',
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
    CapitalizePipe,
    ButtonComponent,
    NgbPopoverModule,
  ],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.scss',
})
export class CourseDetailsComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: IChaptersOfClassSubjectInterface[] = [];
  searchQuery: string = '';
  sortColumn: string = 'ProbableWeightageInExam';
  sortOrder: string = 'ascending';
  filter: number = 1;
  classId: number = 0;
  subjectId: number = 0;
  className: string = '';
  subjectName: string = '';
  excelFileName = 'ChaptersData.xlsx';
  pdfFileName = 'DhaptersData.pdf';
  @ViewChild('content') content!: ElementRef;

  constructor(
    private teacherService: TeacherService,
    private notificationService: NotificationService,
    private loaderService: LoaderService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.decryptQueryParams();
    console.log(this.classId, this.subjectId);
    this.getChaptersData();
  }

  decryptQueryParams(): void {
    this.route.queryParams.subscribe((params) => {
      this.classId = parseInt(
        CryptoJS.AES.decrypt(
          params['classId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
      this.subjectId = parseInt(
        CryptoJS.AES.decrypt(
          params['subjectId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
      this.className = CryptoJS.AES.decrypt(
        params['className'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.subjectName = CryptoJS.AES.decrypt(
        params['subjectName'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
    });
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    if (this.searchQuery.length >= 3) this.getChaptersData();
    else if (this.searchQuery.length == 0) this.getChaptersData();
  }

  onSort(column: string) {
    if (this.sortColumn === column) {
      this.sortOrder =
        this.sortOrder === SystemConstants.Ascending
          ? SystemConstants.Descending
          : SystemConstants.Ascending;
    } else {
      this.sortColumn = column;
      this.sortOrder = SystemConstants.Ascending;
    }
    this.getChaptersData();
  }

  getChaptersData() {
    const requestPayload: IClassSubjectPageListRequestInterface = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
      filter: this.filter,
      classId: this.classId,
      subjectId: this.subjectId,
    };

    this.loaderService.show();

    this.teacherService
      .getChaptersOfClassSubject(
        requestPayload as IClassSubjectPageListRequestInterface
      )
      .subscribe({
        next: (
          response: IResponse<
            IPageListResponse<IChaptersOfClassSubjectInterface[]>
          >
        ) => {
          this.responseData = response.data.records;
          this.collectionSize = response.data.totalRecords;
          this.loaderService.hide();
        },
        error: (error: HttpErrorResponse) => {
          this.loaderService.hide();
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
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
    XLSX.utils.book_append_sheet(wb, ws, this.excelFileName);

    this.loaderService.hide();

    XLSX.writeFile(wb, this.excelFileName);
  }

  savePDF(): void {
    this.loaderService.show();

    const doc = new jsPDF({
      orientation: 'portrait',
      unit: 'pt',
      format: 'a2',
    });

    // Add Title
    doc.setFontSize(18);
    doc.setTextColor(40);
    doc.text('Chapter Details', 40, 40);

    // Table Headers and Data
    const headers = [
      {
        content: 'Serial No.',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Chapter Name',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Probable Weightage',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Probable Duration',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
      {
        content: 'Is Optional To Teach',
        styles: {
          halign: 'center',
          fillColor: [41, 128, 185],
          textColor: [255, 255, 255],
        },
      },
    ];

    const tableData = this.responseData.map((item, index) => [
      { content: index + 1, styles: { halign: 'center' } },
      {
        content: this.capitalizeWords(item.chapterName),
        styles: { halign: 'center' },
      },
      {
        content: item.probableWeightageInExam
          ? `${item.probableWeightageInExam} marks`
          : 'N/A',
        styles: { halign: 'center' },
      },
      {
        content: item.probableDurationToTeach
          ? `${item.probableDurationToTeach} `
          : 'N/A',
        styles: { halign: 'center' },
      },
      {
        content: item.isOptionalToTeach ? 'Yes' : 'No',
        styles: { halign: 'center' },
      },
    ]);

    // Add the Table
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

  capitalizeWords(text: string): string {
    return text
      .split(' ')
      .map((word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join(' ');
  }

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.subjectClassesUrl]);
  }
}
