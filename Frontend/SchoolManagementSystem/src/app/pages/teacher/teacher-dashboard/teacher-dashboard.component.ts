import { Component } from '@angular/core';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbPaginationModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IAdmitRequestListInterface } from '../../../models/teacher/admit-request-list';
import { InputComponent } from '../../../shared/components/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, Subject } from 'rxjs';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NgClass } from '@angular/common';
@Component({
  selector: 'app-teacher-dashboard',
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
  ],
  templateUrl: './teacher-dashboard.component.html',
  styleUrl: './teacher-dashboard.component.scss',
})
export class TeacherDashboardComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: IAdmitRequestListInterface[] = [];
  private searchSubject = new Subject<string>();
  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortOrder: string = 'ascending';
  constructor(private teacherService: TeacherService) {}

  ngOnInit(): void {
    this.searchSubject.pipe(debounceTime(3000)).subscribe((searchTerm) => {
      this.search(searchTerm);
    });
    this.getAdmitRequestData();
  }

  onKeyup(searchTerm: string) {
    this.searchSubject.next(searchTerm);
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
    this.getAdmitRequestData();
  }

  onSort(column: string) {
    console.log('SORT: ', this.sortColumn, this.sortOrder);

    if (this.sortColumn === column) {
      this.sortOrder =
        this.sortOrder === 'ascending' ? 'descending' : 'ascending';
    } else {
      this.sortColumn = column;
      this.sortOrder = 'ascending';
    }
    console.log('SORT: ', this.sortColumn, this.sortOrder);
    this.getAdmitRequestData();
  }

  getAdmitRequestData() {
    console.log('Page Data: ', this.page, this.pageSize);

    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: this.sortOrder,
      sortColumn: this.sortColumn,
      searchQuery: this.searchQuery,
    };

    this.teacherService
      .getAdmitRequestList(requestPayload as IPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<IAdmitRequestListInterface[]>>
        ) => {
          console.log('request list: ', response);
          this.responseData = response.data.records;
          console.log('Final response: ', this.responseData);
          this.collectionSize = response.data.totalRecords;
        },
        error: (error: HttpErrorResponse) => {
          console.log(error);
        },
      });
  }
}
