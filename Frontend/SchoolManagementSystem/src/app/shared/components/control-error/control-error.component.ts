import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  Input,
} from '@angular/core';

@Component({
  selector: 'app-control-error',
  standalone: true,
  imports: [],
  templateUrl: './control-error.component.html',
  styleUrl: './control-error.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ControlErrorComponent {
  _text: string = '';
  _hide = true;
  _class = '';

  @Input() set text(value: string) {
    if (value !== this._text) {
      this._text = value;
      this._hide = !value;
      this.cdr.detectChanges();
    }
  }

  @Input() set class(value: string) {
    if (value) {
      this._class = value;
      this.cdr.markForCheck();
    }
  }
  constructor(private cdr: ChangeDetectorRef) {}
}
