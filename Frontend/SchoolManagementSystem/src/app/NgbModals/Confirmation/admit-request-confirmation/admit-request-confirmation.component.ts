import { Component } from '@angular/core';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admit-request-confirmation',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './admit-request-confirmation.component.html',
  styleUrl: './admit-request-confirmation.component.scss',
})
export class AdmitRequestConfirmationComponent {
  constructor(private modalService: NgbModal, private router: Router) {}
  close() {
    this.modalService.dismissAll();
    this.router.navigate([''])
  }
}
