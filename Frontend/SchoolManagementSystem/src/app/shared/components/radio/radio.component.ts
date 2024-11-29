import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ControlErrorsDirective } from '../../../directives/control-errors.directive';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-radio',
  standalone: true,
  imports: [ControlErrorsDirective, ReactiveFormsModule, CommonModule],
  templateUrl: './radio.component.html',
  styleUrl: './radio.component.scss'
})
export class RadioComponent {
  @Input() name!: string;
  @Input() id!: string;
  @Input() label!: string;
  @Input() value!: any;
  @Input() checked: boolean = false;
  @Input() disabled: boolean = false;
  @Input() errorTitle: string = this.label;
  @Input() controlName!: string;
  @Output() selected = new EventEmitter<any>();
  @Input() parentForm!: FormGroup;

  onSelectionChange(): void {
    this.selected.emit(this.value);
  }
}
