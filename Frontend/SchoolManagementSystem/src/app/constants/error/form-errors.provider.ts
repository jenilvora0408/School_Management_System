import { InjectionToken } from '@angular/core';

interface ErrorOptions {
  requiredLength: number;
  actualLength: number;
}

export const defaultErrors = {
  required: (error: any) => `This field is required.`,
  minlength: ({ requiredLength, actualLength }: ErrorOptions) =>
    `This field must be at least ${requiredLength} characters long.`,
  maxlength: ({ requiredLength, actualLength }: ErrorOptions) =>
    `This field should not be greater than ${requiredLength} characters.`,
  pattern: () => 'This field is not valid.',
  passwordMismatch: () => 'This field does not match.',
  email: () => `This field is not valid.`,
};

export const FORM_ERRORS = new InjectionToken('FORM_ERRORS', {
  providedIn: 'root',
  factory: () => defaultErrors,
});
