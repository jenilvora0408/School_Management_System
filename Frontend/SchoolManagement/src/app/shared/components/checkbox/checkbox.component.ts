import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Checkbox } from '../../models/checkbox';
import { DropdownItem } from '../../models/drop-down-item';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
})
export class CheckboxComponent {
  @Output() selectionChange = new EventEmitter<string>();
  @Input() options: DropdownItem[] = [];
  @Input() answers: string = '';
  @Input() name: string = '';
  @Input() parentForm!: FormGroup;
  @Input() controlName!: string;
  @Input() required: boolean = false;
  selectedCheckboxArray: string[] = [];
  checkboxes: Checkbox[] = [];
  formControl!: FormControl;
  @Input()
  index?: number;

  ngOnInit() {
    const selectedAnswers: string[] = this.answers.split(',');
    if (Array.isArray(this.options)) {
      for (let item of this.options) {
        const checkbox: Checkbox = {
          value: item.value,
          viewValue: item.viewValue,
          checked: false,
        };
        if (selectedAnswers.includes(item.value)) {
          checkbox.checked = true;
        }
        this.checkboxes.push(checkbox);
      }
    }
    this.selectedCheckboxArray = selectedAnswers;
    if (this.selectedCheckboxArray[0] === '') {
      this.selectedCheckboxArray = [];
    }
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }
  }

  onCheckboxChange(checboxesValue: string) {
    let checkboxExist = false;
    if (this.formControl.errors !== null) {
      this.formControl.markAllAsTouched();
    }

    for (let item of this.selectedCheckboxArray) {
      if (item === checboxesValue) {
        checkboxExist = true;
        let index = this.selectedCheckboxArray.indexOf(checboxesValue);
        this.selectedCheckboxArray.splice(index, 1);
        break;
      }
    }
    if (checkboxExist === false) {
      this.selectedCheckboxArray.push(checboxesValue);
    }
    const answer = this.selectedCheckboxArray.join(',');
    this.selectionChange.emit(answer);
  }
}
