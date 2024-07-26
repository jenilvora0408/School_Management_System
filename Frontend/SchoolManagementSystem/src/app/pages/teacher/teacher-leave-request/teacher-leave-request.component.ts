import { Component, inject } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { InputComponent } from '../../../shared/components/input/input.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import {
  NgbCalendar,
  NgbDate,
  NgbDateParserFormatter,
  NgbDatepickerModule,
} from '@ng-bootstrap/ng-bootstrap';
import { JsonPipe } from '@angular/common';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { DropdownItem } from '../../../shared/models/drop-down-item';

@Component({
  selector: 'app-teacher-leave-request',
  standalone: true,
  imports: [
    HeaderComponent,
    FormSubmitDirective,
    ReactiveFormsModule,
    InputComponent,
    TextareaComponent,
    SelectComponent,
    NgbDatepickerModule,
    FormsModule,
    JsonPipe,
  ],
  templateUrl: './teacher-leave-request.component.html',
  styleUrl: './teacher-leave-request.component.scss',
})
export class TeacherLeaveRequestComponent {
  leaveRequestForm = new FormGroup({
    name: new FormControl(''),
    approvalFromUser: new FormControl(''),
    reasonForLeave: new FormControl('', Validators.required),
    leaveStartDate: new FormControl('', Validators.required),
    leaveEndDate: new FormControl('', Validators.required),
    leaveStartType: new FormControl('', Validators.required),
    leaveEndType: new FormControl('', Validators.required),
    leaveDuration: new FormControl('', Validators.required),
    leaveType: new FormControl('', Validators.required),
    contactNumber: new FormControl('', Validators.required),
    availabilityOnPhone: new FormControl('', Validators.required),
    alternateContactNumber: new FormControl('', Validators.required),
  });

  leaveTypeOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Sick Leave' },
    { value: '2', viewValue: 'Casual Leave' },
    { value: '3', viewValue: 'Adhoc Leave' },
  ];

  availabiilityOnPhoneOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Yes' },
    { value: '2', viewValue: 'No' },
  ];

  calendar = inject(NgbCalendar);
  formatter = inject(NgbDateParserFormatter);

  hoveredDate: NgbDate | null = null;
  fromDate: NgbDate | null = this.calendar.getToday();
  toDate: NgbDate | null = this.calendar.getNext(
    this.calendar.getToday(),
    'd',
    10
  );

  constructor() {}

  ngOnInit(): void {}

  onSubmit(): void {}

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (
      this.fromDate &&
      !this.toDate &&
      date &&
      date.after(this.fromDate)
    ) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
    console.log(this.fromDate, this.toDate);
  }

  isHovered(date: NgbDate) {
    return (
      this.fromDate &&
      !this.toDate &&
      this.hoveredDate &&
      date.after(this.fromDate) &&
      date.before(this.hoveredDate)
    );
  }

  isInside(date: NgbDate) {
    return this.toDate && date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return (
      date.equals(this.fromDate) ||
      (this.toDate && date.equals(this.toDate)) ||
      this.isInside(date) ||
      this.isHovered(date)
    );
  }

  validateInput(currentValue: NgbDate | null, input: string): NgbDate | null {
    const parsed = this.formatter.parse(input);
    return parsed && this.calendar.isValid(NgbDate.from(parsed))
      ? NgbDate.from(parsed)
      : currentValue;
  }
}
