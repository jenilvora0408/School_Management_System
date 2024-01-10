import { Component, Input, OnInit, forwardRef } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormGroup,
  NG_VALUE_ACCESSOR,
} from '@angular/forms';

@Component({
  selector: 'app-form-input-wrapper',
  templateUrl: './form-input-wrapper.component.html',
  styleUrls: ['./form-input-wrapper.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => FormInputWrapperComponent),
      multi: true,
    },
  ],
})
export class FormInputWrapperComponent implements ControlValueAccessor, OnInit {
  @Input() label: string = '';
  @Input() type: string = '';
  @Input() controlName: string = '';
  @Input() className: string = '';
  @Input() placeholder: string = '';
  // @Input() parentForm!: FormGroup;
  @Input() inputId!: string;
  formControl: FormControl = new FormControl('');

  onChange = (value: number) => {};

  onTouched = () => {};

  ngOnInit(): void {
    this.formControl.valueChanges.subscribe({
      next: (res: any) => {
        this.onChange(res);
      },
    });
    // const control = this.parentForm.get(this.controlName);
    // if (control instanceof FormControl) {
    //   this.formControl = control;
    // }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  writeValue(obj: any): void {
    this.formControl.setValue(obj);
    this.onChange = obj;
  }
}
