import { Component, ElementRef, ViewChild } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { Router, RouterLink } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { InputComponent } from '../../../shared/components/input/input.component';
import { TextareaComponent } from '../../../shared/components/textarea/textarea.component';
import { AlphabetOnlyInputComponent } from '../../../shared/components/alphabet-only-input/alphabet-only-input.component';
import { PhoneNumberInputComponent } from '../../../shared/components/phone-number-input/phone-number-input.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { ValidationMessageConstant } from '../../../constants/validation/validation-message';
import { ValidationPattern } from '../../../constants/validation/validation-pattern';
import { IResponse } from '../../../shared/models/IResponse';
import { CommonService } from '../../../shared/services/common.service';
import { NotificationService } from '../../../shared/services/notification.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { IMyProfileInterface } from '../../../models/common/my-profile';
import { PhoneMaskDirective } from '../../../directives/phone-mask.directive';
import { FormSubmitDirective } from '../../../directives/form-submit.directive';

@Component({
  selector: 'app-my-profile',
  standalone: true,
  imports: [
    HeaderComponent,
    ButtonComponent,
    InputComponent,
    FormSubmitDirective,
    TextareaComponent,
    AlphabetOnlyInputComponent,
    PhoneNumberInputComponent,
    ReactiveFormsModule,
    RouterLink,
    PhoneMaskDirective,
  ],
  templateUrl: './my-profile.component.html',
  styleUrl: './my-profile.component.scss',
})
export class MyProfileComponent {
  userId: number = this.authService.getUserId();
  userName: string = this.authService.getUserName();
  profilePicture: string | ArrayBuffer | null = '';
  userRole: string = '';
  @ViewChild('profileInput') profileInput!: ElementRef;
  phoneNumberCustomErrors = {
    pattern: ValidationMessageConstant.phoneNumber,
  };
  profileForm = new FormGroup({
    firstName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(2),
      ])
    ),
    lastName: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(2),
      ])
    ),
    email: new FormControl(
      '',
      Validators.compose([
        Validators.required,
        Validators.minLength(2),
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
    city: new FormControl(''),
    headline: new FormControl(''),
    address: new FormControl('', Validators.required),
    avatar: new FormControl(),
  });

  initialFirstName: string = '';
  initialLastName: string = '';

  constructor(
    private commonService: CommonService,
    private notificationService: NotificationService,
    private authService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
    this.getProfileDetails();
    this.userRole = this.authService.getUserType();
  }

  openPictureFileDialog() {
    this.profileInput.nativeElement.click();
  }

  handlePictureFileChange(event: any) {
    const file = event.target.files?.[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.profilePicture = reader.result;
      this.profileForm.value.avatar = reader.result;
    };
  }

  getProfileDetails() {
    this.commonService.getMyProfile(this.userId).subscribe({
      next: (response: IResponse<IMyProfileInterface>) => {
        if (response.success) {
          this.populateForm(response.data);
        }
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }

  populateForm(data: any) {
    this.profilePicture =
      data.avatar == '' ? SystemConstants.DefaultAvatar: data.avatar;
    this.profileForm.patchValue({
      firstName: data.firstName,
      lastName: data.lastName,
      email: data.email,
      phoneNumber: data.phoneNumber,
      city: data.city,
      headline: data.headline,
      address: data.address,
    });
    this.userName = data.firstName + ' ' + data.lastName;
    this.initialFirstName = data.firstName;
    this.initialLastName = data.lastName;
  }

  onSubmit() {
    if (this.profileForm.valid) {
      this.profileForm.value.avatar = this.profilePicture;

      const payload : IMyProfileInterface = {
        userId: this.authService.getUserId(),
        firstName : this.profileForm.value.firstName ?? '',
        lastName: this.profileForm.value.lastName ?? '',
        email: this.profileForm.value.email?? '',
        phoneNumber: this.profileForm.value.phoneNumber?? '',
        city: this.profileForm.value.city?? '',
        headline: this.profileForm.value.headline?? '',
        address: this.profileForm.value.address?? '',
        avatar : this.profileForm.value.avatar ?? '',
      }
      
      this.commonService
        .updateUserProfile(payload)
        .subscribe({
          next: (response: IResponse<string>) => {
            if (response.success) {
              this.getProfileDetails();
              this.checkAndUpdateUserName();
              this.notificationService.success(response.message);
            }
          },
          error: (error) => {
            this.notificationService.error(error.error.errors);
          },
        });
    }
  }

  checkAndUpdateUserName() {
    const currentFirstName = this.profileForm.get('firstName')?.value;
    const currentLastName = this.profileForm.get('lastName')?.value;
    if (
      currentFirstName !== this.initialFirstName ||
      currentLastName !== this.initialLastName
    ) {
      this.authService.updateUserName(`${currentFirstName} ${currentLastName}`);
    }
  }

  cancelForm(){
    this.getProfileDetails();
  }

  navigateBack(): void {
    if(this.userRole == '1')
      this.router.navigate(['/principal']);
    else if(this.userRole == '2')
      this.router.navigate(['/teacher']);
    else
      this.router.navigate(['/student']);
  }
}
