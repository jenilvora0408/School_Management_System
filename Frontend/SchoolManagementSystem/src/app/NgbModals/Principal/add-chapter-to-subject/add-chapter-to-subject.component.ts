import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { InputComponent } from '../../../shared/components/input/input.component';
import { RadioComponent } from '../../../shared/components/radio/radio.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { NgClass } from '@angular/common';
import { ICourseListForClassSubjectInterface } from '../../../models/principal/course-list-for-class-subject';

@Component({
  selector: 'app-add-chapter-to-subject',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormSubmitDirective,
    InputComponent,
    RadioComponent,
    ButtonComponent,
    NgClass,
  ],
  templateUrl: './add-chapter-to-subject.component.html',
  styleUrl: './add-chapter-to-subject.component.scss',
})
export class AddChapterToSubjectComponent {
  addChapterForm = new FormGroup({
    chapterName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(50),
      ])
    ),
    probableWeightageInExam: new FormControl(''),
    probableDurationToTeach: new FormControl(''),
    isOptionalToTeach: new FormControl('false'),
    learningObjectives: new FormControl('', Validators.maxLength(100)),
  });

  selectedValue: string = 'false';
  showError: boolean = false;
  chapterAlreadyExistsError: string =
    ValidationMessageConstant.chapterAlreadyExists;

  @Input() existingChapters: any[] = [];
  @Output() chapterAdded = new EventEmitter<any>();

  constructor(private modalService: NgbModal) {}

  ngOnInit(): void {}

  close() {
    this.modalService.dismissAll();
  }

  onRadioChange(value: string): void {
    this.selectedValue = value;
    console.log('radio: ', value);
  }

  onSubmit(): void {
    if (this.addChapterForm.valid) {
      const newChapter = {
        chapterName: this.addChapterForm.value.chapterName as string,
        probableWeightageInExam: this.addChapterForm.value
          .probableWeightageInExam
          ? this.addChapterForm.value.probableWeightageInExam
          : null,
        probableDurationToTeach: this.addChapterForm.value
          .probableDurationToTeach
          ? (this.addChapterForm.value.probableDurationToTeach as string) +
            ' Weeks'
          : null,
        isOptionalToTeach:
          this.addChapterForm.value.isOptionalToTeach === 'true',
        learningObjectives: this.addChapterForm.value.learningObjectives
          ? (this.addChapterForm.value.learningObjectives as string)
          : null,
      };

      const existingChapterData = this.existingChapters.find(
        (chapter) =>
          chapter.chapterName.toLowerCase().trim() ===
          newChapter.chapterName.toLowerCase().trim()
      );

      if (!existingChapterData) {
        this.showError = false;

        const nextChapterNumber =
          this.existingChapters.length > 0
            ? Math.max(
                ...this.existingChapters.map(
                  (chapter) => chapter.chapterSerialNumber
                )
              ) + 1
            : 1;

        const payload: ICourseListForClassSubjectInterface = {
          courseId: 0,
          chapterSerialNumber: nextChapterNumber,
          chapterName: newChapter.chapterName,
          probableWeightageInExam:
            parseInt(newChapter.probableWeightageInExam ?? '') || 0,
          probableDurationToTeach: newChapter.probableDurationToTeach || '',
          isOptionalToTeach: newChapter.isOptionalToTeach,
          learningObjectives: newChapter.learningObjectives || '',
          classId: this.existingChapters[0]?.classId || 0,
          subjectId: this.existingChapters[0]?.subjectId || 0,
          className: this.existingChapters[0]?.className || '',
          subjectName: this.existingChapters[0]?.subjectName || '',
        };

        this.chapterAdded.emit(payload);
        this.close();
      } else {
        this.showError = true;
      }
    }
  }
}
