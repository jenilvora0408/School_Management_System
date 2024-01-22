import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const minDateValidator = (minDate: Date): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    return control.value && new Date(control.value) > minDate
      ? null
      : { invalidMinDate: true };
  };
};
