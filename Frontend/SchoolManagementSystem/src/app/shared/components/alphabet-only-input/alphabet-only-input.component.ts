import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ControlErrorsDirective } from '../../../directives/control-errors.directive';
import { AlphabetOnlyDirective } from '../../../directives/alphabet-only.directive';

@Component({
  selector: 'app-alphabet-only-input',
  standalone: true,
  imports: [
    ControlErrorsDirective,
    ReactiveFormsModule,
    CommonModule,
    AlphabetOnlyDirective,
  ],
  templateUrl: './alphabet-only-input.component.html',
  styleUrl: './alphabet-only-input.component.scss',
})
export class AlphabetOnlyInputComponent {
  @Input() label!: string;
  @Input() labelClass: string = '';
  @Input() title!: string;
  @Input({ required: false }) customErrors: Record<string, string> = {};
  @Input() type: string = 'text';
  @Input() placeholder!: string;
  @Input() value: string = '';
  @Input() required: boolean = false;
  @Input() pattern!: string;
  @Input() readonly: boolean = false;
  @Input() class!: string;
  @Input() ngClass!: any;
  @Input() maxlength!: number;
  @Input() minlength!: number;
  @Input() name!: string;
  @Input() styles: any = '';
  @Input() className!: string;
  @Input() parentForm!: FormGroup;
  @Input() controlName!: string;
  @Input() errorTitle: string = this.label;
  @Input({ required: false }) testId = '';
  @Output() onKeyup: EventEmitter<string> = new EventEmitter<string>();

  onKeyUp(inputValue: string) {
    this.onKeyup.emit(inputValue);
  }
}
