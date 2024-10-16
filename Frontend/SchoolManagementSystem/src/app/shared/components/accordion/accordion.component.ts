import { Component, Input } from '@angular/core';
import { Panel } from '../../models/panel';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
import { CapitalizePipe } from '../../../pipes/capitalize.pipe';
import { DateFormatPipe } from '../../../pipes/date-format.pipe';
import { NgClass } from '@angular/common';
import { InputComponent } from '../input/input.component';

@Component({
  selector: 'app-accordion',
  standalone: true,
  imports: [
    NgbAccordionModule,
    CapitalizePipe,
    DateFormatPipe,
    NgClass,
    InputComponent,
  ],
  templateUrl: './accordion.component.html',
  styleUrl: './accordion.component.scss',
})
export class AccordionComponent {
  @Input() panels: Panel[] = [];

  ngOnInit(): void {
    console.log(this.panels);
  }
}
