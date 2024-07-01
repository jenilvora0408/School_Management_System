import { Directive, HostListener } from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[appAlphabetOnly]',
  standalone: true,
})
export class AlphabetOnlyDirective {
  constructor(private ngControl: NgControl) {}

  @HostListener('input', ['$event']) onInputChange(event: any) {
    const initalValue = this.ngControl.value;
    this.ngControl.control?.setValue(initalValue.replace(/[^a-zA-Z]/g, ''), {
      emitEvent: false,
    });
  }
}
