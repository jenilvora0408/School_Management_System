import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const maxDateValidator = (maxDate: Date): ValidatorFn => {
  return (control: AbstractControl): ValidationErrors | null => {
    return control.value && new Date(control.value) < maxDate
      ? null
      : { invalidMaxDate: true };
  };
};
