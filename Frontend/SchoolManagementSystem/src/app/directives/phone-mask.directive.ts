import { Directive, HostListener } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appPhoneMask]',
  standalone: true,
})
export class PhoneMaskDirective {
  constructor(public ngControl: NgControl) {}

  @HostListener('ngModelChange', ['$event'])
  onModelChange(event: any) {
    this.onInputChange(event, false);
  }

  @HostListener('keydown.backspace', ['$event'])
  keydownBackspace(event: any) {
    this.onInputChange(event.target.value, true);
  }

  onInputChange(event: any, backspace: any) {
    let newVal = event.replace(/\D/g, ''); // Remove non-digit characters

    // Apply formatting logic based on the length of newVal
    if (backspace && newVal.length <= 5) {
      newVal = newVal.substring(0, newVal.length - 1);
    }
    if (newVal.length === 0) {
      newVal = '';
    } else if (newVal.length <= 5) {
      newVal = newVal.replace(/^(\d{0,5})/, '$1');
    } else if (newVal.length <= 10) {
      newVal = newVal.replace(/^(\d{0,5})(\d{0,5})/, '$1 $2');
    } else {
      newVal = newVal.substring(0, 10);
      newVal = newVal.replace(/^(\d{0,5})(\d{0,5})/, '$1 $2');
    }

    // Set the formatted value to the input
    this.ngControl?.valueAccessor?.writeValue(newVal);
  }
}
