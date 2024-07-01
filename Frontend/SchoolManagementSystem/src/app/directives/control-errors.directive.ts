// From https://netbasal.com/make-your-angular-forms-error-messages-magically-appear-1e32350b7fa5
import {
  Directive,
  Input,
  Inject,
  Optional,
  ElementRef,
  ComponentRef,
  ViewContainerRef,
  OnInit,
  DestroyRef,
  inject,
} from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { NgControl, AbstractControl } from '@angular/forms';
import { merge, Observable, EMPTY, fromEvent } from 'rxjs';
import { debounceTime, startWith } from 'rxjs/operators';
import { FormSubmitDirective } from './form-submit.directive';
import { ControlErrorContainerDirective } from './control-error-container.directive';
import { ControlErrorComponent } from '../shared/components/control-error/control-error.component';
import { FORM_ERRORS } from '../constants/error/form-errors.provider';

@Directive({
  selector: '[appControlErrors]',
  standalone: true,
})
export class ControlErrorsDirective implements OnInit {
  @Input('appControlErrors') mode = 'default'; // eslint-disable-line @angular-eslint/no-input-rename
  @Input() customErrors: Record<string, string> = {};
  @Input() errorTitle!: string;
  private destroyRef = inject(DestroyRef);
  container: ViewContainerRef;
  ref!: ComponentRef<ControlErrorComponent>;
  submit$: Observable<Event>;
  touched$: Observable<Event>;
  nullFn = () => null;

  constructor(
    private controlDir: NgControl,
    @Optional() controlErrorContainer: ControlErrorContainerDirective,
    private el: ElementRef,
    @Inject(FORM_ERRORS) private errors: any,

    @Optional() private form: FormSubmitDirective, // need investigation
    private vcr: ViewContainerRef
  ) {
    this.container = controlErrorContainer
      ? controlErrorContainer.vcr
      : this.vcr;
    this.submit$ = this.form ? this.form.submit$ : EMPTY; // temp mod
    this.touched$ = fromEvent(this.el.nativeElement, 'blur');
  }

  ngOnInit(): void {
    const dirStatusChange: Observable<any> =
      this.controlDir.statusChanges || new Observable().pipe(startWith({}));

    const debounced = merge(
      this.submit$,
      this.touched$,
      dirStatusChange // added to detect async Validators
    ).pipe(debounceTime(200));

    debounced
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((v) => this.addRemoveError());
  }

  get control(): AbstractControl | null {
    return this.controlDir.control;
  }

  addRemoveError(): void {
    const controlErrors = this.control?.errors;
    const elementClassList = this.el.nativeElement.classList;
    if (
      this.control?.touched &&
      controlErrors &&
      Object.keys(controlErrors).length
    ) {
      const firstKey: string = Object.keys(controlErrors)[0];
      const getError = this.errors[firstKey] || this.nullFn;
      const text =
        this.customErrors[firstKey] || getError(controlErrors[firstKey]);
      elementClassList.add('is-invalid');
      this.setError(text);
    } else if (this.ref) {
      if (elementClassList.contains('is-invalid')) {
        elementClassList.remove('is-invalid');
      }
      this.setError('');
    }
  }

  setError(text: string): void {
    if (!this.ref) {
      this.ref = this.container.createComponent(ControlErrorComponent);
    }
    if (this.errorTitle && text) {
      this.ref.instance.text = text.replace('This field', this.errorTitle);
    } else {
      this.ref.instance.text = text;
    }
  }
}
