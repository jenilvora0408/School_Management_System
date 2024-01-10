import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-info-group',
  templateUrl: './info-group.component.html',
  styleUrls: ['./info-group.component.scss']
})
export class InfoGroupComponent {
	@Input()
	public label!: string;

	@Input() 
	public value: string | null = null;

	@Input() 
	public icon?: string;

	@Input() 
	public labelClass: string = 'label--style';

	@Input() 
	public valueClass: string = 'text-gray';
}
