import {
  AfterViewChecked,
  ChangeDetectorRef,
  Component,
  EventEmitter,
  Injectable,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DropdownItem } from '../../models/drop-down-item';

@Component({
  selector: 'app-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.scss'],
})
@Injectable()
export class DropDownComponent implements OnInit, AfterViewChecked {
  @Input() label: string = 'Option';
  @Input() labelClass: string = '';
  @Input() controlName: string = '';
  @Input() parentForm!: FormGroup;
  @Input() control: FormControl = new FormControl();
  @Input('options') options!: DropdownItem[];
  @Input('isInvalid') isInvalid: boolean = false;
  @Input() errorString!: string;
  @Input() selectValue: string = '';
  @Input() className: string = '';
  @Input() showLabel: boolean = true;
  @Input() title!: string;
  @Input() validateInput: boolean = true;
  @Input() showValidationMessage: boolean = true;
  @Output() selectionChange = new EventEmitter<string | number>();
  formControl: FormControl = new FormControl('');

  constructor(private readonly changeDetectorRef: ChangeDetectorRef) {}

  ngOnInit(): void {
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }
  }
  ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
  }

  onOptionSelected(option: any) {
    this.selectValue = option.target.value;
    this.selectionChange.emit(this.selectValue);
  }
}
