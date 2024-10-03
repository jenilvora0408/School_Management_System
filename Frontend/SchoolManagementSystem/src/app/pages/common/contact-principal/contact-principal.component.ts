import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';

@Component({
  selector: 'app-contact-principal',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    InputComponent,
    ButtonComponent,
    FormSubmitDirective,
    HeaderComponent,
    SelectComponent,
    TextareaComponent
  ],
  templateUrl: './contact-principal.component.html',
  styleUrl: './contact-principal.component.scss',
})
export class ContactPrincipalComponent {
  contactPrincipalForm = new FormGroup({
    subject: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(120)
      ])
    ),
    typeOfRequest: new FormControl(
      '',
      Validators.compose([
        Validators.required,
      ])
    ),
    desciption: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(2000)
      ])
    ),
    relatableEvidence: new FormControl(),
  });

  requestRoleOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Harassment' },
    { value: '2', viewValue: 'Awareness' },
    { value: '3', viewValue: 'Notice'},
    { value: '4', viewValue: 'ExternalHelp'},
    { value: '5', viewValue: 'Other'}
  ];

  constructor(){}

  ngOnInit():void{}

  handlePictureFileChange(event: any) {
    const file = event.target.files?.[0];

    if (file) {
      const validExtensions = ['image/jpeg', 'image/jpg', 'image/png'];
      const maxSizeInMB = 1;
      const maxSizeInBytes = maxSizeInMB * 1024 * 1024;

      if (!validExtensions.includes(file.type)) {
      } else if (file.size > maxSizeInBytes) {
      } else {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {
          this.contactPrincipalForm.value.relatableEvidence = reader.result;
        };
      }
    }
  }

  onSubmit(){}

  cancelForm(){}
}
