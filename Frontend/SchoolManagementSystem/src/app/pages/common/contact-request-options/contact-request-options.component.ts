import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { AuthenticationService } from '../../../services/authentication.service';

@Component({
  selector: 'app-contact-request-options',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent],
  templateUrl: './contact-request-options.component.html',
  styleUrl: './contact-request-options.component.scss',
})
export class ContactRequestOptionsComponent {
  userRole: string = '';
  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit():void{
    this.userRole = this.authService.getUserType();
    console.log(this.userRole);
    
  }

  navigateToCreateRequest() {
    this.router.navigate(['/contact-principal']);
  }

  navigateToViewRequests() {
    this.router.navigate(['/contact-request-history']);
  }

  navigateBack(): void {
    if(this.userRole == '2')
      this.router.navigate(['/teacher']);
    else
      this.router.navigate(['/student']);
  }
}
