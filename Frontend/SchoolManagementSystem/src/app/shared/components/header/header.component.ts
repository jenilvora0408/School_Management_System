import { Component, inject } from '@angular/core';
import { NgbDropdownModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { AuthenticationService } from '../../../services/authentication.service';
import { Router } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgbDropdownModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  username: string = '';
  userRole: number = 0;
  private offCanvasService = inject(NgbOffcanvas);

  constructor(private authService: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.username = this.authService.getUserName();
    this.userRole = parseInt(this.authService.getUserType());
  }

  open() {
    const offcanvasRef = this.offCanvasService.open(SidebarComponent);
    offcanvasRef.componentInstance.name = 'Sidenav';
  }

  onLogout() {
    this.authService.logOut();
  }

  navigateProfile(){
      this.router.navigate(['principal/my-profile']);
  }
}
