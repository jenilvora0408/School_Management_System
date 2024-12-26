import { Component, EventEmitter, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { ITeacherDropdownInterface } from '../../../models/common/teacher-dropdown';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { DropdownMenu } from '../../../shared/models/dropdown-menu';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { PrincipalService } from '../../../services/principal.service';
import { IManageSubjectInterface } from '../../../models/principal/manage-subject';
import { IUnassignedSubjectTeachersInterface } from '../../../models/principal/unassigned-subject-teachers';

@Component({
  selector: 'app-add-subject',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule,
    FormSubmitDirective,
    InputComponent,
    ButtonComponent,
    SelectComponent,
  ],
  templateUrl: './add-subject.component.html',
  styleUrl: './add-subject.component.scss',
})
export class AddSubjectComponent {
  teachersList: DropdownMenu[] = [];
  teachersData: ITeacherDropdownInterface[] = [];
  @Output() subjectAdded = new EventEmitter<void>();
  addSubjectForm = new FormGroup({
    subjectName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(20),
      ])
    ),
    subjectCode: new FormControl('', Validators.required),
    subjectTeacher: new FormControl('', Validators.required),
  });

  constructor(
    private modalService: NgbModal,
    private notificationService: NotificationService,
    private principalService: PrincipalService
  ) {}

  ngOnInit(): void {
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
    if (!this.addSubjectForm.valid) {
      return;
    }

    const selectedTeacher = this.teachersList.find(
      (teacher) => teacher.viewValue === this.addSubjectForm.value.subjectTeacher
    );

    const payload: IManageSubjectInterface = {
      subjectId: 0,
      subjectName: this.addSubjectForm.value.subjectName ?? '',
      subjectCode: this.addSubjectForm.value.subjectCode ?? '',
      subjectTeacherId: selectedTeacher ? selectedTeacher.id : 0
    };

    this.principalService.manageSubject(payload).subscribe({
      next: (response: IResponse<string>) => {
        this.modalService.dismissAll();
        this.subjectAdded.emit();
        this.notificationService.success(response.data);
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }
}
