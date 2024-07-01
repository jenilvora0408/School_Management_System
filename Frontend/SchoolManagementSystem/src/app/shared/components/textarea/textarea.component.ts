import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ControlErrorContainerDirective } from '../../../directives/control-error-container.directive';
import { ControlErrorsDirective } from '../../../directives/control-errors.directive';

@Component({
  selector: 'app-textarea',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    ControlErrorContainerDirective,
    ControlErrorsDirective,
  ],
  templateUrl: './textarea.component.html',
  styleUrl: './textarea.component.scss',
})
export class TextareaComponent {
  @Input() label!: string;
  @Input() labelClass: string = '';
  @Input() controlName: string = '';
  @Input() row: number = 3;
  @Input() column: number = 15;
  @Input() name: string = '';
  @Input() parentForm!: FormGroup;
  @Input() errorTitle!: string;
  @Input() className!: string;
  @Input() placeholder!: string;
  formControl!: FormControl;
  @Input() value: string = '';
  @Input({ required: false }) testId = '';

  // ngOnInit(): void {
  //   const control = this.parentForm.get(this.controlName);
  //   if (control instanceof FormControl) {
  //     this.formControl = control;
  //   }
  // }
}
