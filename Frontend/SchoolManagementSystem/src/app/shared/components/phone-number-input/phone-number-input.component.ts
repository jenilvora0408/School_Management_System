import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ControlErrorsDirective } from '../../../directives/control-errors.directive';
import { PhoneMaskDirective } from '../../../directives/phone-mask.directive';

@Component({
  selector: 'app-phone-number-input',
  standalone: true,
  imports: [
    ControlErrorsDirective,
    ReactiveFormsModule,
    CommonModule,
    PhoneMaskDirective,
  ],
  templateUrl: './phone-number-input.component.html',
  styleUrl: './phone-number-input.component.scss',
})
export class PhoneNumberInputComponent {
  @Input() label!: string;
  @Input() labelClass: string = '';
  @Input() title!: string;
  @Input({ required: false }) customErrors: Record<string, string> = {};
  @Input() placeholder!: string;
  @Input() value: string = '';
  @Input() required: boolean = false;
  @Input() pattern!: string;
  @Input() readonly: boolean = false;
  @Input() class!: string;
  @Input() ngClass!: any;
  @Input() name!: string;
  @Input() styles: any = '';
  @Input() className!: string;
  @Input() errorTitle: string = this.label;
  @Input() parentForm!: FormGroup;
  @Input() controlName!: string;
  @Input() maxLength!: Number;
}
