import { Component, SimpleChanges } from '@angular/core';
import { DropdownItem } from '../../../shared/models/drop-down-item';
import { NgbDateStruct, NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
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
import { CommonService } from '../../../shared/services/common.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IResponse } from '../../../shared/models/IResponse';
import { IAdmitRequestInterface } from '../../../models/auth/admit-request.interface';
import {
  CommonItemResponse,
  CommonListResponse,
} from '../../../shared/models/common-item-response';
import { Router } from '@angular/router';
import { AlphabetOnlyInputComponent } from '../../../shared/components/alphabet-only-input/alphabet-only-input.component';
import { AdmitRequestConfirmationComponent } from '../../../NgbModals/Confirmation/admit-request-confirmation/admit-request-confirmation.component';

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
    AlphabetOnlyInputComponent,
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
  showStudentInfo: boolean = false;
  avatarError: string = '';
  canUserSubmitAdmitRequest: boolean = true;

  admitRequestForm = new FormGroup({
    firstName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(18),
      ])
    ),
    lastName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(18),
      ])
    ),
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.email),
        Validators.maxLength(32),
        Validators.minLength(8),
      ])
    ),
    phoneNumber: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.pattern(ValidationPattern.phoneNumber),
        Validators.maxLength(15),
        Validators.minLength(10),
      ])
    ),
    address: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.maxLength(1000),
        Validators.minLength(5),
      ])
    ),
    dateOfBirth: new FormControl(),
    genderId: new FormControl('', Validators.required),
    bloodGroupId: new FormControl('', Validators.required),
    admitRequestRoleId: new FormControl('', Validators.required),
    classId: new FormControl(''),
    mediumId: new FormControl(''),
    avatar: new FormControl(),
  });

  emailValidationMsg: string = ValidationMessageConstant.email;
  currentDay: number = new Date().getDay();
  currentMonth: number = new Date().getMonth();
  currentYear: number = new Date().getFullYear();

  constructor(
    private commonService: CommonService,
    private authService: AuthenticationService,
    private notificationsService: NotificationService,
    private router: Router,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.commonService.getCommonEntityList().subscribe(
      (response: CommonListResponse) => {
        this.genderOptions = response.data.listOfGenders.map(
          (item: CommonItemResponse) => ({
            value: item.id,
            viewValue: item.title,
          })
        );

        this.bloodGroupOptions = response.data.listOfBloodGroups.map(
          (item: CommonItemResponse) => ({
            value: item.id,
            viewValue: item.title,
          })
        );

        this.classOptions = response.data.listOfClasses.map(
          (item: CommonItemResponse) => ({
            value: item.id,
            viewValue: item.title,
          })
        );

        this.mediumOptions = response.data.listOfMediums.map(
          (item: CommonItemResponse) => ({
            value: item.id,
            viewValue: item.title,
          })
        );
      },
      (error) => {
        console.error('Error occurred', error);
      }
    );
  }

  onSubmit() {
    this.admitRequestForm.markAllAsTouched();
    if (this.avatarError || !this.admitRequestForm.valid) return;
    if (
      this.admitRequestForm.value.classId == '' ||
      this.admitRequestForm.value.mediumId == '' ||
      this.admitRequestForm.value.admitRequestRoleId == '2'
    ) {
      this.admitRequestForm.value.classId = null;
      this.admitRequestForm.value.mediumId = null;
    }
    if (!this.admitRequestForm.valid && !this.canUserSubmitAdmitRequest) return;
    this.authService
      .createAdmitRequest(this.admitRequestForm.value as IAdmitRequestInterface)
      .subscribe({
        next: (res: IResponse<null>) => {
          if (res.success) {
            this.modalService.open(AdmitRequestConfirmationComponent, {
              centered: true,
              size: 'md',
              backdrop: 'static',
            });
          }
        },
        error: (error: HttpErrorResponse) => {
          this.notificationsService.error(error.error.errors);
          console.log(error);
        },
      });
  }

  handlePictureFileChange(event: any) {
    const file = event.target.files?.[0];
    this.avatarError = '';

    if (file) {
      const validExtensions = ['image/jpeg', 'image/jpg', 'image/png'];
      const maxSizeInMB = 1;
      const maxSizeInBytes = maxSizeInMB * 1024 * 1024;

      if (!validExtensions.includes(file.type)) {
        this.avatarError = ValidationMessageConstant.avatarExtensionError;
      } else if (file.size > maxSizeInBytes) {
        this.avatarError = ValidationMessageConstant.avatarImageSizeError;
      } else {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {
          this.admitRequestForm.value.avatar = reader.result;
        };
      }
    }
  }

  onDateSelect(date: any) {
    const jsDate = this.convertNgbDateToDate(date);
    this.admitRequestForm.patchValue({ dateOfBirth: jsDate });
  }

  convertNgbDateToDate(ngbDate: NgbDateStruct): Date {
    return new Date(ngbDate.year, ngbDate.month - 1, ngbDate.day);
  }

  toggleStudentInfo(roleId: any) {
    if (roleId.target.value === '3') {
      this.showStudentInfo = true;
    } else {
      this.showStudentInfo = false;
    }
  }
}
