import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
})
export class InputComponent implements OnInit {
  @Input() label!: string;
  @Input() labelClass: string = '';
  @Input() title!: string;
  @Input() type!: string;
  @Input() placeholder!: string;
  @Input() value: string = '';
  @Input() required: boolean = true;
  @Input() pattern!: string;
  @Input() readonly: boolean = false;
  @Input() size!: number;
  @Input() class!: string;
  @Input() ngClass!: any;
  @Input() maxlength!: number;
  @Input() minlength!: number;
  @Input() name!: string;
  @Input() parentForm!: FormGroup;
  @Input() errorString!: string;
  @Input() styles: any = '';
  @Input() onlyNumbers = false;
  @Input() controlName!: string;
  @Input() className!: string;
  @Input() validationMsg!: string;
  @Input() showValidationMessage: boolean = true;
  @Input() validateInput = true;
  @Output() onKeyup: EventEmitter<string> = new EventEmitter<string>();
  @Output() valueChange = new EventEmitter<string>();
  @Input() icon!: string;
  @Output() iconClick: EventEmitter<void> = new EventEmitter<void>();

  @ViewChild('input') input!: ElementRef;
  formControl: FormControl = new FormControl('');

  ngOnInit(): void {
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }
  }

  onIconClick() {
    this.iconClick.emit();
  }

  onValueChange(input: HTMLInputElement) {
    if (input.validity.valid && input.value.trim() !== '') {
      this.valueChange.emit(input.value.trim() as string);
      if (input.validity.valid) {
        this.valueChange.emit(this.value as string);
      } else {
        this.errorString = '';
        this.valueChange.emit('');
      }
    }
  }

  onKeyUp(inputValue: string) {
    this.onKeyup.emit(inputValue);
  }

  public onInput(input: string): void {
    if (this.onlyNumbers) {
      const numericValue = input.replace(/[^0-9]/g, '');
      this.formControl.setValue(numericValue);
    }
  }

  public fileInput() {
    this.input.nativeElement.click();
  }
}
