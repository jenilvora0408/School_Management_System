import { Component, EventEmitter, Injectable, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import {
  NgbDateParserFormatter,
  NgbDateStruct,
} from '@ng-bootstrap/ng-bootstrap';

@Injectable()
// Convert the date format from yyyy-MM-dd to dd-MM-yyyy
export class CustomNgbDateParserFormatter extends NgbDateParserFormatter {
  parse(value: string): NgbDateStruct | null {
    if (value) {
      const parts = value.trim().split('-');
      if (parts.length === 3) {
        return { year: +parts[2], month: +parts[1], day: +parts[0] };
      }
    }
    return null;
  }
  format(date: NgbDateStruct | null): string {
    return date
      ? `${this.pad(date.day)}-${this.pad(date.month)}-${date.year}`
      : '';
  }

  private pad(n: number): string {
    return n < 10 ? `0${n}` : `${n}`;
  }
}
@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    { provide: NgbDateParserFormatter, useClass: CustomNgbDateParserFormatter },
  ],
})
export class DatepickerComponent {
  @Input() label!: string;
  @Input() title!: string;
  @Input() parentForm!: FormGroup;
  @Input() controlName!: string;
  @Input() defaultDate: NgbDateStruct | null = null;
  @Output() dateSelected = new EventEmitter<NgbDateStruct>();
  formControl: FormControl = new FormControl('');
  selectedDate: NgbDateStruct | null = null;

  onDateSelect(date: NgbDateStruct): void {
    this.selectedDate = date;
    this.dateSelected.emit(date); 
  }
  ngOnInit(): void {
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }
    if (this.defaultDate) {
      this.selectedDate = this.defaultDate;
    }
  }
}
