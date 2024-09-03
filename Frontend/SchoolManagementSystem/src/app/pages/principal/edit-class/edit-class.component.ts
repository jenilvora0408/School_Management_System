import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonService } from '../../../shared/services/common.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { ITeachersListInterface } from '../../../models/teacher/teachers-list';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ISubjectsListInterface } from '../../../models/teacher/subjects-list';
import { PrincipalService } from '../../../services/principal.service';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddSubjectToClassComponent } from '../../../NgbModals/Principal/add-subject-to-class/add-subject-to-class.component';

@Component({
  selector: 'app-edit-class',
  standalone: true,
  imports: [
    HeaderComponent,
    SelectComponent,
    ReactiveFormsModule,
    FormSubmitDirective,
    InputComponent,
    ButtonComponent,
  ],
  templateUrl: './edit-class.component.html',
  styleUrl: './edit-class.component.scss',
})
export class EditClassComponent {
  classId: number = 0;
  classTeacherName: string = '';
  classStrength: number = 0;
  className: string = '';
  teachersList: DropdownItem[] = [];
  responseData: ISubjectsListInterface[] = [];

  editClassForm = new FormGroup({
    classTeacherId: new FormControl('', Validators.required),
    classStrength: new FormControl('', Validators.required),
  });

  constructor(
    private route: ActivatedRoute,
    private commonService: CommonService,
    private notificationService: NotificationService,
    private cdr: ChangeDetectorRef,
    private principalService: PrincipalService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.decryptQueryParams();
    this.getAllTeachers();
    this.getAllSubjects();

    this.editClassForm.patchValue({
      classStrength: this.classStrength.toString(),
      classTeacherId: this.classTeacherName,
    });

    this.cdr.detectChanges();

    console.log(this.responseData);
    
  }

  getAllTeachers() {
    this.commonService.getAllTeachers().subscribe({
      next: (response: IResponse<ITeachersListInterface[]>) => {
        this.teachersList = response.data.map(
          (item: ITeachersListInterface) => ({
            value: item.firstName + ' ' + item.lastName,
            viewValue: item.firstName + ' ' + item.lastName,
          })
        );
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  getAllSubjects() {
    this.principalService.getAllSubjects(this.classId).subscribe({
      next: (response: IResponse<ISubjectsListInterface[]>) => {
        this.responseData = response.data;
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  decryptQueryParams() {
    this.route.queryParams.subscribe((params) => {
      this.classId = parseInt(
        CryptoJS.AES.decrypt(
          params['classId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
      this.classTeacherName = CryptoJS.AES.decrypt(
        params['classTeacherName'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
      this.classStrength = parseInt(
        CryptoJS.AES.decrypt(
          params['classStrength'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
      this.className = 
        CryptoJS.AES.decrypt(
          params['className'],
          SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
    });

    console.log(this.classId);
  }

  addSubject() {
    const modalRef = this.modalService.open(AddSubjectToClassComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });
    modalRef.componentInstance.existingSubjects = this.responseData;

    modalRef.componentInstance.subjectAdded.subscribe((subject: ISubjectsListInterface) => {
      this.responseData.push(subject); 
    });
  }

  onSubmit() {}

  cancelFormData() {
  } 
}
