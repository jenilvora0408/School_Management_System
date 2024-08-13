import { Component, EventEmitter, inject, Output } from '@angular/core';
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
import { ICreateLeaveRequestInterface } from '../../../models/teacher/create-leave-request';
import { AuthenticationService } from '../../../services/authentication.service';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';
import { LeaveTypePipe } from '../../../pipes/leave-type.pipe';

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
  providers: [LeaveTypePipe],
})
export class CreateLeaveRequestComponent {
  calendar = inject(NgbCalendar);
  formatter = inject(NgbDateParserFormatter);

  hoveredDate: NgbDate | null = null;
  fromDate: NgbDate | null = this.calendar.getToday();
  toDate: NgbDate | null = this.calendar.getNext(
    this.calendar.getToday(),
    'd',
    2
  );

  @Output() leaveRequestCreated = new EventEmitter<void>();

  leaveTypeOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Sick Leave' },
    { value: '2', viewValue: 'Casual Leave' },
    { value: '3', viewValue: 'Adhoc Leave' },
  ];

  createLeaveRequestForm = new FormGroup({
    reasonForLeave: new FormControl('', Validators.required),
    leaveType: new FormControl('', Validators.required),
    alternatePhoneNumber: new FormControl('', Validators.required),
  });

  constructor(
    private modalService: NgbModal,
    private authService: AuthenticationService,
    private teacherService: TeacherService,
    private notificationService: NotificationService,
    private leaveTypePipe: LeaveTypePipe
  ) {}

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

  onSubmit() {
    console.log(this.createLeaveRequestForm.value);

    const startDate = new Date(
      this.fromDate!.year,
      this.fromDate!.month - 1,
      this.fromDate!.day
    );

    const endDate = new Date(
      this.toDate!.year,
      this.toDate!.month - 1,
      this.toDate!.day
    );

    const timeDifference = endDate.getTime() - startDate.getTime();
    const leaveDuration = Math.ceil(timeDifference / (1000 * 3600 * 24));

    const payload: ICreateLeaveRequestInterface = {
      leaveType:
        this.leaveTypePipe.transform(
          this.createLeaveRequestForm.value.leaveType
        ) ?? '',
      reasonForLeave: this.createLeaveRequestForm.value.reasonForLeave ?? '',
      alternatePhoneNumber:
        this.createLeaveRequestForm.value.alternatePhoneNumber ?? '',
      startDate: startDate,
      endDate: endDate,
      leaveDuration: leaveDuration.toString() + ' days',
      leaveRequestorId: this.authService.getUserId(),
    };

    console.log(payload);

    this.teacherService
      .createLeaveRequest(payload as ICreateLeaveRequestInterface)
      .subscribe({
        next: (response: IResponse<null>) => {
          console.log('request list: ', response);
          this.modalService.dismissAll();
          this.leaveRequestCreated.emit();
          if (response.success)
            this.notificationService.success(response.message);
        },
        error: (error: HttpErrorResponse) => {
          console.log(error);
        },
      });
  }

  close() {
    this.modalService.dismissAll();
  }
}
