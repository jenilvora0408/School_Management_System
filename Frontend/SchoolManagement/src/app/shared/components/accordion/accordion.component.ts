import { Component, Input, TemplateRef } from '@angular/core';
import { Panel } from '../../models/panel';
@Component({
  selector: 'app-accordion',
  templateUrl: './accordion.component.html',
  styleUrls: ['./accordion.component.scss'],
})
export class AccordionComponent {
  @Input() panels: Panel[] = [];
}
