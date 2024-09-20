import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
  FormsModule,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { CommonService } from '../../../shared/services/common.service';
import { ISubjectsListInterface } from '../../../models/principal/subjects-list';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { ButtonComponent } from '../../../shared/components/button/button.component';

@Component({
  selector: 'app-add-subject-to-class',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    SelectComponent,
    FormsModule,
    FormSubmitDirective,
    ButtonComponent,
  ],
  templateUrl: './add-subject-to-class.component.html',
  styleUrl: './add-subject-to-class.component.scss',
})
export class AddSubjectToClassComponent {
  selectedSubjectCode: string = '';
  selectedSubjectTeacher: string = '';
  @Input() existingSubjects: any[] = [];
  @Output() subjectAdded = new EventEmitter<ISubjectsListInterface>();
  selectedSubject: ISubjectsListInterface = {
    subjectId: 0,
    subjectName: '',
    subjectTeacherId: 0,
    subjectTeacherName: '',
    subjectCode: '',
  };
  showError: boolean = false;

  addSubjectForm = new FormGroup({
    subjectName: new FormControl('', Validators.required),
  });

  subjectOptions: DropdownItem[] = [];
  allSubjectsData: ISubjectsListInterface[] = [];

  constructor(
    private modalService: NgbModal,
    private commonService: CommonService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getAllSubjects();
  }

  close() {
    this.modalService.dismissAll();
  }

  onSubjectChange(event: any) {
    const selectedSubjectId = parseInt(event.target.value);
    const selectedSubject = this.subjectOptions.find(
      (option) => option.value === selectedSubjectId
    );

    if (selectedSubject) {
      const subject = this.allSubjectsData.find(
        (option) => option.subjectId === selectedSubjectId
      );

      if (subject != undefined) {
        this.selectedSubjectCode = subject.subjectCode;
        this.selectedSubjectTeacher = subject.subjectTeacherName;
        this.selectedSubject = subject;
        if (this.selectedSubjectTeacher == ' ')
          this.selectedSubjectTeacher = 'Not Assigned';
      }

      const checkForExistingSubject = this.existingSubjects.find(
        (option) => option.subjectId === selectedSubjectId
      );

      if (checkForExistingSubject != undefined) {
        this.showError = true;
      } else {
        this.showError = false;
      }
    }
  }

  getAllSubjects() {
    this.commonService.getAllSubjects().subscribe({
      next: (response: IResponse<ISubjectsListInterface[]>) => {
        this.allSubjectsData = response.data;
        this.subjectOptions = response.data.map(
          (item: ISubjectsListInterface) => ({
            value: item.subjectId,
            viewValue: item.subjectName,
          })
        );
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }

  onSubmit(): void {
    if (this.selectedSubject && !this.showError) {
      this.subjectAdded.emit(this.selectedSubject);
      this.close();
    }
  }
}
