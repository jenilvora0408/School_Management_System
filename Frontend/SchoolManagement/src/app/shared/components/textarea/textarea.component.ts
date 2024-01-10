import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-textarea',
  templateUrl: './textarea.component.html',
  styleUrls: ['./textarea.component.scss'],
})
export class TextareaComponent implements OnInit {
  @Input() label: string = '';
  @Input() labelClass: string = '';
  @Input() type: string = '';
  @Input() placeholder: string = '';
  @Input() value: string = '';
  @Input() required: boolean = true;
  @Input() pattern!: string;
  @Input() readonly: boolean = false;
  @Input() class!: string;
  @Input() ngClass!: any;
  @Input() maxlength!: number;
  @Input() minlength!: number;
  @Input() name!: string;
  @Input() styles: any = '';
  @Input() controlName!: string;
  @Input() parentForm!: FormGroup;
  @Input() rows: number = 3;
  @Input() cols!: number;
  @Input() showValidationMessage: boolean = true;
  @Input() title!: string;
  @Input() validateInput: boolean = true;


  formControl: FormControl = new FormControl('');

  ngOnInit(): void {
    const control = this.parentForm.get(this.controlName);
    if (control instanceof FormControl) {
      this.formControl = control;
    }
  }
}
