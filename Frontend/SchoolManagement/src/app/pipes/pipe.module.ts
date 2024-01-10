import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ColumnNamePipe } from './column-name.pipe';

const pipes = [ColumnNamePipe];

@NgModule({
  declarations: [...pipes],
  imports: [CommonModule],
  exports: [...pipes],
})
export class PipeModule {}
