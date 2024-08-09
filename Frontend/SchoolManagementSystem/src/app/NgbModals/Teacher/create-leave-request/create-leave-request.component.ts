import { Component, inject } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { InputComponent } from '../../../shared/components/input/input.component';
import {
  NgbCalendar,
  NgbDate,
  NgbDateParserFormatter,
  NgbDatepickerModule,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { PhoneNumberInputComponent } from '../../../shared/components/phone-number-input/phone-number-input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';

@Component({
  selector: 'app-create-leave-request',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    FormSubmitDirective,
    InputComponent,
    NgbDatepickerModule,
    FormsModule,
    SelectComponent,
    PhoneNumberInputComponent,
    ButtonComponent,
  ],
  templateUrl: './create-leave-request.component.html',
  styleUrl: './create-leave-request.component.scss',
})
export class CreateLeaveRequestComponent {
  calendar = inject(NgbCalendar);
  formatter = inject(NgbDateParserFormatter);

  hoveredDate: NgbDate | null = null;
  fromDate: NgbDate | null = this.calendar.getToday();
  toDate: NgbDate | null = this.calendar.getNext(
    this.calendar.getToday(),
    'd',
    10
  );

  leaveTypeOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Sick Leave' },
    { value: '2', viewValue: 'Casual Leave' },
    { value: '3', viewValue: 'Adhoc Leave' },
  ];

  createLeaveRequestForm = new FormGroup({
    reasonForLeave: new FormControl('', Validators.required),
    // leaveStartDate: new FormControl('', Validators.required),
    // leaveEndDate: new FormControl('', Validators.required),
    leaveType: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
  });

  constructor(private modalService: NgbModal) {}

  ngOnInit(): void {}

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

  onSubmit() {}

  close() {
    this.modalService.dismissAll();
  }

  selectTest(selectedValues: string) {
    console.log(selectedValues);
  }
}
