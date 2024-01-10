import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccordionComponent } from './components/accordion/accordion.component';
import { ButtonComponent } from './components/button/button.component';
import { CheckboxComponent } from './components/checkbox/checkbox.component';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';
import { DatepickerComponent } from './components/datepicker/datepicker.component';
import { DialogBoxComponent } from './components/dialog-box/dialog-box.component';
import { DropDownComponent } from './components/drop-down/drop-down.component';
import { FormInputWrapperComponent } from './components/form-input-wrapper/form-input-wrapper.component';
import { InfoGroupComponent } from './components/info-group/info-group.component';
import { InputComponent } from './components/input/input.component';
import { LinkboxComponent } from './components/linkbox/linkbox.component';
import { LoaderComponent } from './components/loader/loader.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { RadioButtonComponent } from './components/radio-button/radio-button.component';
import { TableComponent } from './components/table/table.component';
import { TextareaComponent } from './components/textarea/textarea.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DirectiveModule } from '../directives/directive.module';
import { PipeModule } from '../pipes/pipe.module';
import { RouterModule } from '@angular/router';

const components = [
  AccordionComponent,
  ButtonComponent,
  InputComponent,
  TextareaComponent,
  DropDownComponent,
  DialogBoxComponent,
  TableComponent,
  PaginationComponent,
  DatepickerComponent,
  LinkboxComponent,
  ConfirmationDialogComponent,
  LoaderComponent,
  FormInputWrapperComponent,
  InfoGroupComponent,
  CheckboxComponent,
  RadioButtonComponent,
];

@NgModule({
  declarations: [...components],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    DirectiveModule,
    PipeModule,
    RouterModule,
  ],
  exports: [...components, FormsModule, ReactiveFormsModule],
})
export class SharedModule {}
