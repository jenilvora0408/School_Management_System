import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Injector, Output } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ITeacherDropdownInterface } from '../../../models/common/teacher-dropdown';
import { IManageSubjectInterface } from '../../../models/principal/manage-subject';
import { PrincipalService } from '../../../services/principal.service';
import { DropdownMenu } from '../../../shared/models/dropdown-menu';
import { IResponse } from '../../../shared/models/IResponse';
import { NotificationService } from '../../../shared/services/notification.service';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { IUnassignedSubjectTeachersInterface } from '../../../models/principal/unassigned-subject-teachers';

@Component({
  selector: 'app-edit-subject',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    FormSubmitDirective,
    InputComponent,
    ButtonComponent,
    SelectComponent,
  ],
  templateUrl: './edit-subject.component.html',
  styleUrl: './edit-subject.component.scss',
})
export class EditSubjectComponent {
  subjectId: number = 0;
  subjectName: string = '';
  subjectCode: string = '';
  subjectTeacherName: string = '';
  subjectTeacherId: number = 0;
  teachersList: DropdownMenu[] = [];
  isEditing: boolean = false;
  selectedTeacherName: string = '';
  teachersData: ITeacherDropdownInterface[] = [];
  @Output() subjectEdited = new EventEmitter<void>();
  editSubjectForm = new FormGroup({
    subjectName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
      ])
    ),
    subjectCode: new FormControl('', Validators.required),
    subjectTeacher: new FormControl<string | number | null>(
      '',
      Validators.required
    ),
  });

  constructor(
    private modalService: NgbModal,
    private injector: Injector,
    private notificationService: NotificationService,
    private principalService: PrincipalService
  ) {}

  ngOnInit(): void {
    this.subjectId = this.injector.get('subjectId');
    this.subjectName = this.injector.get('subjectName');
    this.subjectCode = this.injector.get('subjectCode');
    this.subjectTeacherName = this.injector.get('subjectTeacherName');
    this.subjectTeacherId = this.injector.get('subjectTeacherId');

    this.getAllTeachers();
  }

  getAllTeachers() {
    this.principalService.getAllUnassignedSubjectTeachers().subscribe({
      next: (response: IResponse<IUnassignedSubjectTeachersInterface[]>) => {
        this.teachersList = response.data.map(
          (item: IUnassignedSubjectTeachersInterface) => ({
            value: item.userName,
            viewValue: item.userName,
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

  close(): void {
    this.modalService.dismissAll();
  }

  onSubmit(): void {
    if (!this.editSubjectForm.valid) {
      return;
    }

    const selectedTeacher = this.teachersList.find(
      (teacher) =>
        teacher.viewValue === this.editSubjectForm.value.subjectTeacher
    );

    const payload: IManageSubjectInterface = {
      subjectId: this.subjectId,
      subjectName: this.editSubjectForm.value.subjectName ?? '',
      subjectCode: this.editSubjectForm.value.subjectCode ?? '',
      subjectTeacherId: selectedTeacher
        ? selectedTeacher.id
        : this.subjectTeacherId,
    };

    this.principalService.manageSubject(payload).subscribe({
      next: (response: IResponse<string>) => {
        this.modalService.dismissAll();
        this.subjectEdited.emit();
        this.notificationService.success(response.data);
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  toggleEdit(editMode: boolean) {
    if (!editMode) {
      this.editSubjectForm.patchValue({
        subjectTeacher:
          this.teachersList.find(
            (teacher) => teacher.viewValue === this.selectedTeacherName
          )?.id || '',
      });
    }
    this.isEditing = editMode;
  }

  saveEdit() {
    const selectedTeacher = this.teachersList.find(
      (teacher) =>
        teacher.id === Number(this.editSubjectForm.value.subjectTeacher)
    );
    this.selectedTeacherName = selectedTeacher?.viewValue || '';
    this.isEditing = false;
  }
}
