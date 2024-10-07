import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { InputComponent } from '../../../shared/components/input/input.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { CommonService } from '../../../shared/services/common.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IContactPrincipalInterface } from '../../../models/common/contact-principal';
import { IResponse } from '../../../shared/models/IResponse';

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
    TextareaComponent,
  ],
  templateUrl: './contact-principal.component.html',
  styleUrl: './contact-principal.component.scss',
})
export class ContactPrincipalComponent {
  uploadEvidence: any;
  contactPrincipalForm = new FormGroup({
    subject: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(120),
      ])
    ),
    typeOfRequest: new FormControl(
      '',
      Validators.compose([Validators.required])
    ),
    description: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(2000),
      ])
    ),
    relatableEvidence: new FormControl(),
  });

  requestRoleOptions: DropdownItem[] = [
    { value: '1', viewValue: 'Harassment' },
    { value: '2', viewValue: 'Awareness' },
    { value: '3', viewValue: 'Notice' },
    { value: '4', viewValue: 'ExternalHelp' },
    { value: '5', viewValue: 'Other' },
  ];

  constructor(
    private commonService: CommonService,
    private notificationService: NotificationService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {}

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
          this.uploadEvidence = reader.result;
        };
      }
    }
  }

  onSubmit() {
    this.contactPrincipalForm.value.relatableEvidence = this.uploadEvidence;
    console.log(this.contactPrincipalForm.value);

    const payload: IContactPrincipalInterface = {
      userId: this.authService.getUserId(),
      subject: this.contactPrincipalForm.value.subject || 'Contact Principal',
      description: this.contactPrincipalForm.value.description || '',
      type:
        this.contactPrincipalForm.value.typeOfRequest != null
          ? parseInt(this.contactPrincipalForm.value.typeOfRequest)
          : 0,
      relatableEvidence: this.uploadEvidence,
    };

    console.log(payload);
    

    this.commonService.contactPrincipal(payload).subscribe({
      next: (response: IResponse<null>) => {
        if (response.success) {
          this.notificationService.success(response.message);
        }
      },
      error: (error) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }

  cancelForm() {}
}
