import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';

@Component({
  selector: 'app-contact-request-options',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent],
  templateUrl: './contact-request-options.component.html',
  styleUrl: './contact-request-options.component.scss'
})
export class ContactRequestOptionsComponent {
  constructor(private router: Router) {}

  navigateToCreateRequest() {
    this.router.navigate(['/contact-principal']);
  }

  navigateToViewRequests() {
    this.router.navigate(['/contact-request-history']);
  }
}
