import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewEncapsulation,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownItem } from '../../models/drop-down-item';

@Component({
  selector: 'app-radio-button',
  templateUrl: './radio-button.component.html',
  styleUrls: ['./radio-button.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class RadioButtonComponent {
  @Output() selectionChange = new EventEmitter<any>();
  @Input() options: DropdownItem[] = [];
  @Input() selectedValue: any = null;
  formControl: FormControl = new FormControl();
  @Input() controlName: string = '';
  @Input() parentForm: FormGroup = new FormGroup({});
  @Input() name!: string;

  radios: { value: any; viewValue: string; checked: boolean }[] = [];

  ngOnInit() {
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }

    if (Array.isArray(this.options)) {
      this.radios = this.options.map((option, index) => ({
        ...option,
        checked: option.viewValue === this.selectedValue,
        value: option.value,
      }));
    }
  }

  onRadioChange(selectedValue: any) {
    this.radios.forEach((radio) => {
      radio.checked = radio.value === selectedValue;
    });

    const selectedRadio = this.radios.find((radio) => radio.checked);

    if (selectedRadio) {
      this.selectionChange.emit(selectedValue);
    }
  }
}
