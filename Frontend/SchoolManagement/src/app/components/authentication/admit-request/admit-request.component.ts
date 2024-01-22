import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { maxDateValidator } from 'src/app/common/max-date-validator';
import { minDateValidator } from 'src/app/common/min-date-validator';
import { DATE_CONST } from 'src/app/constants/shared/date-constants';
import { MessageConstant } from 'src/app/constants/validation/message-constants';
import { ValidationMessageConstant } from 'src/app/constants/validation/validation-message';
import { ValidationPattern } from 'src/app/constants/validation/validation-pattern';
import { InputComponent } from 'src/app/shared/components/input/input.component';
import { DropdownItem } from 'src/app/shared/models/drop-down-item';

@Component({
  selector: 'app-admit-request',
  templateUrl: './admit-request.component.html',
  styleUrls: ['./admit-request.component.scss'],
})
export class AdmitRequestComponent {
  genderOptions: DropdownItem[] = [];
  bloodGroupOptions: DropdownItem[] = [];
  requestRoleOptions: DropdownItem[] = [];
  newFileUploaded: boolean = false;
  @ViewChild('fileInput') fileInput!: InputComponent;
  selectedFile: any;
  emailValidationMsg: string = ValidationMessageConstant.email;

  admitRequestForm = new FormGroup({
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
      ])
    ),
    firstName: new FormControl(
      '',
      Validators.compose([Validators.required, Validators.minLength(16)])
    ),
    lastName: new FormControl(
      '',
      Validators.compose([Validators.required, Validators.minLength(16)])
    ),
    phoneNumber: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.phoneNumber),
      ])
    ),
    dateOfBirth: new FormControl('', [
      Validators.required,
      minDateValidator(DATE_CONST.minDate),
      maxDateValidator(DATE_CONST.maxDate),
    ]),
    genderDropdown: new FormControl('', [Validators.required]),
    bloodGroupDropdown: new FormControl('', [Validators.required]),
    requestRoleDropdown: new FormControl('', [Validators.required]),
    address: new FormControl('', [
      Validators.required,
      Validators.maxLength(512),
    ]),
    fileName: new FormControl('', [Validators.required]),
    upload: new FormControl('', [Validators.required]),
  });

  // onFileInputChange(event: any): void {
  //   this.newFileUploaded = true;
  //   const files = event.target.files;
  //   if (files && files.length > 0 && files[0].type === 'application/jpg') {
  //     this.selectedFile = files[0];
  //     this.admitRequestForm.get('fileName')?.setValue(this.selectedFile.name);
  //   } else {
  //     event.target.value = null;
  //     this.selectedFile = null;
  //     // this.admitRequestForm.error(MessageConstant.pdfOnly);
  //   }
  // }

  onFileInputChange(event: any): void {
    this.newFileUploaded = true;
    const files = event.target.files;

    if (files && files.length > 0) {
      const allowedExtensions = ['jpg', 'jpeg', 'png', 'jfif'];
      const fileExtension = files[0].name.split('.').pop()?.toLowerCase();

      if (fileExtension && allowedExtensions.includes(fileExtension)) {
        this.selectedFile = files[0];
        this.admitRequestForm.get('fileName')?.setValue(this.selectedFile.name);
      } else {
        event.target.value = null;
        this.selectedFile = null;
        // this.admitRequestForm.error(MessageConstant.invalidFileType);
      }
    }
  }

  onSubmit() {
    console.log('Admit Request form submitted');
  }
}
