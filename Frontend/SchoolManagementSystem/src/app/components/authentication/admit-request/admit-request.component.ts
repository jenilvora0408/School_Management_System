import { Component } from '@angular/core';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import {
  NgbDateStruct,
  NgbDatepicker,
  NgbDatepickerModule,
} from '@ng-bootstrap/ng-bootstrap';
import {
  FormGroup,
  FormControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { InputComponent } from '../../../shared/components/input/input.component';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { CommonModule } from '@angular/common';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { PhoneNumberInputComponent } from '../../../shared/components/phone-number-input/phone-number-input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';

@Component({
  selector: 'app-admit-request',
  standalone: true,
  imports: [
    InputComponent,
    SelectComponent,
    ReactiveFormsModule,
    CommonModule,
    FormSubmitDirective,
    TextareaComponent,
    NgbDatepickerModule,
    PhoneNumberInputComponent,
    ButtonComponent,
  ],
  templateUrl: './admit-request.component.html',
  styleUrl: './admit-request.component.scss',
})
export class AdmitRequestComponent {
  genderOptions: DropdownItem[] = [];
  bloodGroupOptions: DropdownItem[] = [];
  requestRoleOptions: DropdownItem[] = [
    { value: '2', viewValue: 'Teacher' },
    { value: '3', viewValue: 'Student' },
  ];
  classOptions: DropdownItem[] = [];
  mediumOptions: DropdownItem[] = [];
  combinedAddressValue: string = '';
  model!: NgbDateStruct;

  admitRequestForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
      ])
    ),
    phoneNumber: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.phoneNumber),
      ])
    ),
    address: new FormControl('', Validators.required),
    birthDate: new FormControl('', Validators.required),
    gender: new FormControl('', Validators.required),
    bloodGroup: new FormControl('', Validators.required),
    admitRequestRole: new FormControl('', Validators.required),
    class: new FormControl('', Validators.required),
    medium: new FormControl('', Validators.required),
    avatar: new FormControl(),
  });

  emailValidationMsg: string = ValidationMessageConstant.email;

  constructor() {}

  ngOnInit(): void {}

  onSubmit() {}

  openAddressModal() {}

  handlePictureFileChange(event: any) {
    const file = event.target.files?.[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      console.log(reader.result);
      this.admitRequestForm.value.avatar = reader.result;
      console.log(this.admitRequestForm.value);
    };
  }
}
