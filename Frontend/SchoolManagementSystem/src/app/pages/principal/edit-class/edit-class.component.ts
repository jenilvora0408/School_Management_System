import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ISubjectsListInterface } from '../../../models/principal/subjects-list';
import { PrincipalService } from '../../../services/principal.service';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddSubjectToClassComponent } from '../../../NgbModals/Principal/add-subject-to-class/add-subject-to-class.component';
import { DropdownMenu } from '../../../shared/models/dropdown-menu';
import { IClassInfoInterface } from '../../../models/principal/class-info';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { ITeacherDropdownInterface } from '../../../models/common/teacher-dropdown';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';

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
  classTeacherId: number = 0;
  classStrength: number = 0;
  className: string = '';
  strength: number = 0;
  teachersList: DropdownMenu[] = [];
  teachersData: ITeacherDropdownInterface[] = [];
  responseData: ISubjectsListInterface[] = [];
  classData: any;

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
    private modalService: NgbModal,
    private router: Router
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
  }

  getAllTeachers() {
    this.commonService.getAllTeachers().subscribe({
      next: (response: IResponse<ITeacherDropdownInterface[]>) => {
        this.teachersData = response.data;
        this.teachersList = response.data.map(
          (item: ITeacherDropdownInterface) => ({
            value: item.firstName + ' ' + item.lastName,
            viewValue: item.firstName + ' ' + item.lastName,
            id: item.userId,
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
      this.className = CryptoJS.AES.decrypt(
        params['className'],
        SystemConstants.EncryptionKey
      ).toString(CryptoJS.enc.Utf8);
    });
  }

  addSubject() {
    const modalRef = this.modalService.open(AddSubjectToClassComponent, {
      centered: true,
      size: 'md',
      backdrop: 'static',
    });
    modalRef.componentInstance.existingSubjects = this.responseData;

    modalRef.componentInstance.subjectAdded.subscribe(
      (subject: ISubjectsListInterface) => {
        this.responseData.push(subject);
      }
    );
  }

  onSubmit() {
    if (this.editClassForm.valid) {
      if (this.editClassForm.value.classTeacherId) {
        const selectedTeacherId = this.editClassForm.value.classTeacherId;
        const selectedTeacher = this.teachersList.find(
          (teacher) => teacher.value === selectedTeacherId
        );
        this.classTeacherId = selectedTeacher ? selectedTeacher.id : 0;

        const findAlreadyAssignedTeacher = this.teachersData.find(
          (teacher) =>
            this.classTeacherId == teacher.userId &&
            teacher.isAssigned == true &&
            this.classId != teacher.assignedClassId
        );

        if (
          findAlreadyAssignedTeacher != null ||
          findAlreadyAssignedTeacher != undefined
        ) {
          this.notificationService.error(
            ValidationMessageConstant.classTeacherAlreadyAssigned
          );
          return;
        }
      }

      if (this.editClassForm.value.classStrength) {
        this.strength = parseInt(this.editClassForm.value.classStrength);
      }

      const subjectPayload: ISubjectsListInterface[] = this.responseData;

      const classPayload: IClassInfoInterface = {
        classId: this.classId,
        classStrength: this.strength,
        classTeacherId: this.classTeacherId,
        subjectDetails: subjectPayload,
      };

      this.principalService.submitClassInfo(classPayload).subscribe({
        next: (response: IResponse<null>) => {
          this.router.navigate([RoutingPathConstant.classesAndSubjectsUrl]);
          this.notificationService.success(response.message);
        },
        error: (error: HttpErrorResponse) => {
          this.notificationService.error(error.error.errors);
          console.log(error);
        },
      });
    }
  }

  cancelFormData() {}

  deleteSubject(subjectId: number) {
    console.log(subjectId);
    const index = this.responseData.findIndex(
      (subject) => subject.subjectId === subjectId
    );
    if (index !== -1) {
      this.responseData.splice(index, 1);
    } else {
      console.log('Subject not found with id:', subjectId);
    }
  }

  editCourse(
    classSubjectId: number,
    className: string,
    subjectName: string,
    subjectId: number
  ) {
    this.router.navigate(['principal/edit-course'], {
      queryParams: {
        classSubjectId: CryptoJS.AES.encrypt(
          classSubjectId.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
        className: CryptoJS.AES.encrypt(
          className ?? '',
          SystemConstants.EncryptionKey
        ),
        subjectName: CryptoJS.AES.encrypt(
          subjectName ?? '',
          SystemConstants.EncryptionKey
        ),
        subjectId: CryptoJS.AES.encrypt(
          subjectId.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
        classId: CryptoJS.AES.encrypt(
          this.classId.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
        classTeacherName: CryptoJS.AES.encrypt(
          this.classTeacherName ?? '',
          SystemConstants.EncryptionKey
        ),
        classStrength: CryptoJS.AES.encrypt(
          this.classStrength.toString() ?? '',
          SystemConstants.EncryptionKey
        ),
      },
    });
  }

  navigateBack(): void {
    this.router.navigate(['principal/classes-and-subjects']);
  }
}
