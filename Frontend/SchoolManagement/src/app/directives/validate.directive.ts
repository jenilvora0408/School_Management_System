import {
  Directive,
  DoCheck,
  ElementRef,
  Input,
  Renderer2,
} from '@angular/core';
import { NgControl } from '@angular/forms';

@Directive({
  selector: '[validate]',
})
export class ValidateDirective implements DoCheck {
  @Input() errorTitle: string = '';
  @Input() validateInput: boolean = true;
  private validationMessage: HTMLElement;

  constructor(
    private el: ElementRef,
    private renderer: Renderer2,
    private ngControl: NgControl
  ) {
    const parent = this.renderer.parentNode(this.el.nativeElement);
    this.validationMessage = this.renderer.createElement('span');
    if (this.validateInput) {
      this.renderer.addClass(this.validationMessage, 'text-danger');
      this.renderer.setStyle(this.validationMessage, 'display', 'none');
      this.renderer.appendChild(parent, this.validationMessage);
    }
  }

  ngDoCheck(): void {
    if (this.validateInput) {
      const control = this.ngControl.control;

      if (!control) return;

      if (control.invalid && control.touched) {
        if (control.hasError('required')) {
          this.displayErrorMessage(`${this.errorTitle} is required.`);
        } else if (control.hasError('pattern')) {
          this.displayErrorMessage(
            `${this.errorTitle} must follow a valid pattern.`
          );
        } else if (control.hasError('minlength')) {
          const minLength = control.errors?.['minlength']?.requiredLength;
          if (minLength !== undefined) {
            this.displayErrorMessage(
              `${this.errorTitle} must be at least ${minLength} characters.`
            );
          }
        } else if (control.hasError('maxlength')) {
          const maxLength = control.errors?.['maxlength']?.requiredLength;
          if (maxLength !== undefined) {
            this.displayErrorMessage(
              `${this.errorTitle} must be less than ${maxLength} characters.`
            );
          }
        } else if (control.hasError('min')) {
          const minValue = control.errors?.['min']?.min;
          if (minValue !== undefined) {
            this.displayErrorMessage(
              `${this.errorTitle} must be at least ${minValue}.`
            );
          }
        } else if (control.hasError('max')) {
          const maxValue = control.errors?.['max']?.max;
          if (maxValue !== undefined) {
            this.displayErrorMessage(
              `${this.errorTitle} must be less than ${maxValue}.`
            );
          }
        } else if (control.hasError('passwordMismatch') && control.dirty) {
          this.displayErrorMessage('Confirm Password does not match.');
        } else if (
          control.hasError('invalidEmail') &&
          !control.hasError('required') &&
          !control.hasError('pattern')
        ) {
          this.displayErrorMessage('Invalid email address.');
        }

        if (
          control.hasError('invalidName') &&
          !control.hasError('required') &&
          !control.hasError('pattern')
        ) {
          this.displayErrorMessage(
            `${this.errorTitle} should only contain alphabets, no space allowed.`
          );
        }

        if (
          control.hasError('invalidMinDate') &&
          !control.hasError('required')
        ) {
          this.displayErrorMessage(`Invalid ${this.errorTitle}.`);
        }

        if (
          control.hasError('invalidMaxDate') &&
          !control.hasError('required')
        ) {
          this.displayErrorMessage(
            `${this.errorTitle} should be less than today's date.`
          );
        }
      } else {
        this.hideErrorMessage();
      }
    }
  }

  private displayErrorMessage(message: string): void {
    this.validationMessage.innerText = message;
    this.renderer.setStyle(this.validationMessage, 'display', 'block');
    this.renderer.setStyle(this.el.nativeElement, 'border', '1px solid red');
  }

  private hideErrorMessage(): void {
    this.renderer.setStyle(this.validationMessage, 'display', 'none');
    this.renderer.setStyle(
      this.el.nativeElement,
      'border',
      '1px solid #dee2e6'
    );
  }
}
