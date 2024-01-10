import { Component, Injectable, Input } from '@angular/core';

@Component({
  selector: 'app-linkbox',
  templateUrl: './linkbox.component.html',
  styleUrls: ['./linkbox.component.scss'],
})
@Injectable()
export class LinkboxComponent {
  @Input() type!: number;
  @Input() links!: { text: string; route: string }[];

  constructor() {}
}
