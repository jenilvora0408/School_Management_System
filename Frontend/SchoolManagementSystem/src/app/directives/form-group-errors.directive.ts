// From https://netbasal.com/make-your-angular-forms-error-messages-magically-appear-1e32350b7fa5
import {
  Directive,
  Input,
  ComponentRef,
  ViewContainerRef,
  OnInit,
  DestroyRef,
  inject,
} from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { UntypedFormGroup } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { ControlErrorComponent } from '../shared/components/control-error/control-error.component';

@Directive({
  selector: '[appFormGroupErrors]',
  standalone: true,
})
export class FormGroupErrorsDirective implements OnInit {
  @Input('appFormGroupErrors') control!: UntypedFormGroup; // eslint-disable-line @angular-eslint/no-input-rename
  ref!: ComponentRef<ControlErrorComponent>;
  private destroyRef = inject(DestroyRef);

  constructor(private viewContainerRef: ViewContainerRef) {}

  ngOnInit(): void {
    this.control.statusChanges
      .pipe(debounceTime(200), takeUntilDestroyed(this.destroyRef))
      .subscribe((status) => this.addRemoveError());
  }

  addRemoveError(): void {
    const controlErrors = this.control.errors;

    if (controlErrors && Object.keys(controlErrors).length) {
      const firstKey = Object.keys(controlErrors)[0];
      this.setError(controlErrors[firstKey]);
    } else if (this.ref) {
      this.setError('');
    }
  }

  setError(text: string): void {
    if (!this.ref) {
      this.ref = this.viewContainerRef.createComponent(ControlErrorComponent);
    }
    this.ref.instance.text = text;
    this.ref.instance.class = 'r1';
  }
}
