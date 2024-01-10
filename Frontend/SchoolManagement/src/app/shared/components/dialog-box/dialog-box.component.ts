import {
  Component,
  EventEmitter,
  Input,
  Output,
  TemplateRef,
} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog-box',
  templateUrl: './dialog-box.component.html',
  styleUrls: ['./dialog-box.component.scss'],
})
export class DialogBoxComponent {
  @Input() modalTitle: string = '';
  @Input() modalContent!: TemplateRef<any>;
  @Input() modalBtnLabel1: string = '';
  @Input() modalBtnLabel2: string = '';
  @Input() modalBtnLabel3: string = '';
  @Output() closeBtn = new EventEmitter<string>();
  @Output() clickBtn1 = new EventEmitter<string>();
  @Output() clickBtn2 = new EventEmitter<string>();
  @Output() clickBtn3 = new EventEmitter<string>();
  constructor(public activeModal: NgbActiveModal) {}
  close() {
    this.closeBtn.emit();
    this.activeModal.dismiss('Close click');
  }
  onClickBtn1() {
    this.clickBtn1.emit();
  }

  onClickBtn2() {
    this.clickBtn2.emit();
  }

  onClickBtn3() {
    this.clickBtn3.emit();
  }
}
