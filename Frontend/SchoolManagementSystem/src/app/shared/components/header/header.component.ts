import { Component, inject } from '@angular/core';
import { NgbDropdownModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { AuthenticationService } from '../../../services/authentication.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgbDropdownModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  private offCanvasService = inject(NgbOffcanvas);

  constructor(private authService: AuthenticationService) {}

  open() {
    const offcanvasRef = this.offCanvasService.open(SidebarComponent);
    offcanvasRef.componentInstance.name = 'Sidenav';
  }

  onLogout() {
    this.authService.logOut();
  }
}
