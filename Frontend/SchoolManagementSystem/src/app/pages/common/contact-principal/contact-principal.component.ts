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
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { SelectComponent } from '../../../shared/components/select/select.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { CommonService } from '../../../shared/services/common.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IContactPrincipalInterface } from '../../../models/common/contact-principal';
import { IResponse } from '../../../shared/models/IResponse';
import { LoaderService } from '../../../shared/services/loader.service';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { Router } from '@angular/router';

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
  uploadedImages: { url: string; file: File }[] = [];
  isDragging: boolean = false;
  showDocumentErrors: boolean = false;
  documentError: string = '';
  maxImages: number = 7;
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
    private authService: AuthenticationService,
    private loaderService: LoaderService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  onSubmit() {
    if (!this.showDocumentErrors) {
      this.contactPrincipalForm.value.relatableEvidence = this.uploadEvidence;
      const documents = this.uploadedImages.map((image) => image.url);

      const payload: IContactPrincipalInterface = {
        userId: this.authService.getUserId(),
        subject: this.contactPrincipalForm.value.subject || 'Contact Principal',
        description: this.contactPrincipalForm.value.description || '',
        type:
          this.contactPrincipalForm.value.typeOfRequest != null
            ? parseInt(this.contactPrincipalForm.value.typeOfRequest)
            : 0,
        relatableEvidence: this.uploadEvidence,
        documentContent: documents,
      };

      this.commonService.contactPrincipal(payload).subscribe({
        next: (response: IResponse<null>) => {
          if (response.success) {
            this.router.navigate(['/contact-request-options'])
            this.notificationService.success(response.message);
          }
        },
        error: (error) => {
          this.loaderService.hide();
          this.notificationService.error(error.error.errors);
        },
      });
    }
  }

  cancelForm() {}

  handlePictureFileChange(event: any) {
    const files = event.target.files;

    if (files && files.length > 0) {
      Array.from(files).forEach((file: any) => {
        this.validateAndUpload(file);
      });
    }
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
    this.isDragging = true;
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    this.isDragging = false;

    const files = event.dataTransfer?.files;

    if (files && files.length > 0) {
      Array.from(files).forEach((file: File) => {
        this.validateAndUpload(file);
      });
    }
  }

  onDragLeave(event: DragEvent) {
    this.isDragging = false;
  }

  validateAndUpload(file: File) {
    const validExtensions = ['image/jpeg', 'image/jpg', 'image/png'];
    const maxSizeInMB = 1;
    const maxSizeInBytes = maxSizeInMB * 1024 * 1024;
    const isDuplicate = this.uploadedImages.some(
      (img) => img.file.name === file.name
    );

    if (this.uploadedImages.length >= this.maxImages) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.canUploadMax7Images;
    } else if (isDuplicate) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.imageAlreadyUploaded;
    } else if (!validExtensions.includes(file.type)) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.avatarExtensionError;
    } else if (file.size > maxSizeInBytes) {
      this.showDocumentErrors = true;
      this.documentError = ValidationMessageConstant.avatarImageSizeError;
    } else {
      this.showDocumentErrors = false;
      this.documentError = '';
      const reader = new FileReader();
      reader.onload = () => {
        this.uploadedImages.push({ url: reader.result as string, file });
      };
      reader.readAsDataURL(file);
    }
  }

  removeImage(index: number) {
    this.uploadedImages.splice(index, 1);
    if (
      this.documentError == ValidationMessageConstant.canUploadMax7Images &&
      this.uploadedImages.length <= this.maxImages
    ) {
      this.showDocumentErrors = false;
      this.documentError = '';
    }
  }

  navigateBack(): void {
    this.router.navigate(['/contact-request-options']);
}
}
