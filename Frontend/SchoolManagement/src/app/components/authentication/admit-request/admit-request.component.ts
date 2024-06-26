import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  Renderer2,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import {
  CountryISO,
  PhoneNumberFormat,
  SearchCountryField,
} from 'ngx-intl-tel-input';
import { maxDateValidator } from 'src/app/common/max-date-validator';
import { minDateValidator } from 'src/app/common/min-date-validator';
import { DATE_CONST } from 'src/app/constants/shared/date-constants';
import { ValidationMessageConstant } from 'src/app/constants/validation/validation-message';
import { ValidationPattern } from 'src/app/constants/validation/validation-pattern';
import { AdmitRequest } from 'src/app/models/auth/admit-request';
import { AdmitRequestService } from 'src/app/services/admit-request.service';
import { InputComponent } from 'src/app/shared/components/input/input.component';
import { DropdownItem } from 'src/app/shared/models/drop-down-item';
import { IResponse } from 'src/app/shared/models/iresponse';
import { CommonService } from 'src/app/shared/services/common.service';

@Component({
  selector: 'app-admit-request',
  templateUrl: './admit-request.component.html',
  styleUrls: ['./admit-request.component.scss'],
})
export class AdmitRequestComponent {
  preferredCountries: CountryISO[] = [
    CountryISO.UnitedStates,
    CountryISO.UnitedKingdom,
  ];
  CountryISO = CountryISO;
  SearchCountryField = SearchCountryField;
  separateDialCode = false;
  PhoneNumberFormat = PhoneNumberFormat;
  genderOptions: DropdownItem[] = [];
  bloodGroupOptions: DropdownItem[] = [];
  requestRoleOptions: DropdownItem[] = [];
  combinedAddressValue: string = '';
  model!: NgbDateStruct;
  admitRequestModel: AdmitRequest = {
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    address: '',
    dateOfBirth: '',
    gender: 0,
    avatar: '',
    bloodgroup: 0,
    admitRequestRole: 0,
  };

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
    gender: new FormControl(0, Validators.required),
    bloodGroup: new FormControl(0, Validators.required),
    admitRequestRole: new FormControl(0, Validators.required),
  });

  emailValidationMsg: string = ValidationMessageConstant.email;

  constructor(
    private admitRequestService: AdmitRequestService,
    private commonService: CommonService,
    private renderer: Renderer2,
    private el: ElementRef
  ) {}

  ngOnInit(): void {
    const telInputs = this.el.nativeElement.querySelectorAll('.iti');
    telInputs.forEach((element: any) => {
      this.renderer.setStyle(element, 'display', 'block');
    });

    this.commonService.getCommonEntityList().subscribe(
      (response: any) => {
        console.log(response);

        this.genderOptions = response.data.listOfGenders.map((item: any) => ({
          value: item.id,
          viewValue: item.title,
        }));

        this.bloodGroupOptions = response.data.listOfBloodGroups.map(
          (item: any) => ({
            value: item.id,
            viewValue: item.title,
          })
        );

        this.requestRoleOptions = response.data.listOfUserRoles.map(
          (item: any) => ({
            value: item.id,
            viewValue: item.title,
          })
        );
      },
      (error) => {
        console.error('Error occurred list of genders', error);
      }
    );
  }

  onSubmit() {}

  openAddressModal() {}
}
