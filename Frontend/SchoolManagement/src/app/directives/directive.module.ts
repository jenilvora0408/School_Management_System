import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ValidateDirective } from './validate.directive';

const directives = [ValidateDirective];

@NgModule({
  declarations: [...directives],
  imports: [CommonModule],
  exports: [...directives],
})
export class DirectiveModule {}
