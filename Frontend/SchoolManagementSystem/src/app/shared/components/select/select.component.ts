import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { ControlErrorsDirective } from '../../../directives/control-errors.directive';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-select',
  standalone: true,
  imports: [
    DropdownModule,
    ReactiveFormsModule,
    ControlErrorsDirective,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './select.component.html',
  styleUrl: './select.component.scss',
})
export class SelectComponent {
  @Input() label!: string;
  @Input() labelClass: string = '';
  @Input() options: any[] = [];
  @Input() placeholder: string = '';
  @Input() className: string = '';
  @Input() errorTitle: string = this.label;
  @Input() value: string = '';
  @Input() parentForm!: FormGroup;
  @Input() controlName!: string;
  @Input({ required: false }) testId = '';
}
