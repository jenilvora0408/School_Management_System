import { Component, Injector } from '@angular/core';
import { ISubjectsListInterface } from '../../../models/principal/subjects-list';
import { PrincipalService } from '../../../services/principal.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IPageListRequest } from '../../../shared/models/page-list-request';
import { IPageListResponse } from '../../../shared/models/page-list-response';
import { NotificationService } from '../../../shared/services/notification.service';
import { NgClass } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  NgbDropdownModule,
  NgbPaginationModule,
  NgbTypeaheadModule,
  NgbHighlight,
  NgbPopoverModule,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { ApprovalStatusPipe } from '../../../pipes/approval-status.pipe';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { Router } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { AddSubjectComponent } from '../../../NgbModals/Principal/add-subject/add-subject.component';
import { EditSubjectComponent } from '../../../NgbModals/Principal/edit-subject/edit-subject.component';
import { DeleteSubjectComponent } from '../../../NgbModals/Principal/delete-subject/delete-subject.component';

@Component({
  selector: 'app-manage-subjects',
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
  templateUrl: './manage-subjects.component.html',
  styleUrl: './manage-subjects.component.scss',
})
export class ManageSubjectsComponent {
  page = 1;
  pageSize = 10;
  collectionSize!: number;
  responseData: ISubjectsListInterface[] = [];
  searchQuery: string = '';

  constructor(
    private principalService: PrincipalService,
    private notificationService: NotificationService,
    private router: Router,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getAllSubjectsData();
  }

  search(searchTerm: string) {
    if (this.responseData.length == 0 && searchTerm.length >= 3) {
      this.notificationService.warning('Subjects not found!');
      return;
    }

    this.searchQuery = searchTerm;

    if (this.searchQuery.length >= 3) {
      this.page = 1;
      this.getAllSubjectsData();
    } else if (this.searchQuery.length == 0) this.getAllSubjectsData();
  }

  getAllSubjectsData(): void {
    const requestPayload: IPageListRequest = {
      pageIndex: this.page,
      pageSize: this.pageSize,
      sortOrder: '',
      sortColumn: '',
      searchQuery: this.searchQuery,
      filter: 0,
    };

    this.principalService
      .getAllSubjects(requestPayload as IPageListRequest)
      .subscribe({
        next: (
          response: IResponse<IPageListResponse<ISubjectsListInterface[]>>
        ) => {
          this.responseData = response.data.records;
          this.collectionSize = response.data.totalRecords;
        },
        error: (error: HttpErrorResponse) => {
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
  }

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.principalDashboardUrl]);
  }

  addSubject(): void {
    const modalRef = this.modalService.open(AddSubjectComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });

    modalRef.componentInstance.subjectAdded.subscribe(() => {
      this.getAllSubjectsData();
    });
  }

  // pass subject details
  editSubject(
    subjectId: number,
    subjectName: string,
    subjectCode: string,
    subjectTeacherName: string,
    subjectTeacherId: number
  ) {
    const modalRef = this.modalService.open(EditSubjectComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
      injector: Injector.create({
        providers: [
          {
            provide: 'subjectId',
            useValue: subjectId,
          },
          {
            provide: 'subjectName',
            useValue: subjectName,
          },
          {
            provide: 'subjectCode',
            useValue: subjectCode,
          },
          {
            provide: 'subjectTeacherName',
            useValue: subjectTeacherName,
          },
          {
            provide: 'subjectTeacherId',
            useValue: subjectTeacherId,
          },
        ],
      }),
    });

    modalRef.componentInstance.subjectEdited.subscribe(() => {
      this.getAllSubjectsData();
    });
  }

  deleteSubject(subjectId: number) {
    const modalRef = this.modalService.open(DeleteSubjectComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
      injector: Injector.create({
        providers: [
          {
            provide: 'subjectId',
            useValue: subjectId,
          },
        ],
      }),
    });

    modalRef.componentInstance.subjectDeleted.subscribe(() => {
      this.getAllSubjectsData();
    });
  }
}
