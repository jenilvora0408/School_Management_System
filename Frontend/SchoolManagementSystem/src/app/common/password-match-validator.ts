import {
  AbstractControl,
  AsyncValidatorFn,
  ValidationErrors,
} from '@angular/forms';
import { Observable, of } from 'rxjs';

export function passwordMatchValidator(): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    const password = control.parent?.get('password')?.value;
    const confirmPassword = control.value;
    if (password === confirmPassword) {
      return of(null); // Passwords match
    } else {
      return of({ passwordMismatch: true }); // Passwords do not match
    }
  };
}
