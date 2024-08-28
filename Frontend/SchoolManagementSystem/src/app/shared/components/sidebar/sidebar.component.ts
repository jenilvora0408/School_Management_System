import { Component, inject, Input, ViewChild } from '@angular/core';
import { Sidebar, SidebarModule } from 'primeng/sidebar';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { AvatarModule } from 'primeng/avatar';
import { StyleClassModule } from 'primeng/styleclass';
import { NgbActiveOffcanvas, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from '../../../services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    SidebarModule,
    ButtonModule,
    RippleModule,
    AvatarModule,
    StyleClassModule,
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent {
  activeOffcanvas = inject(NgbActiveOffcanvas);
  @Input() name: string = '';
  private offCanvasService = inject(NgbOffcanvas);

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  close() {
    this.offCanvasService.dismiss(SidebarComponent);
  }

  openLeaveDashboard() {
    this.close();
    const userRole = this.authService.getUserType();
    if (userRole == 2) {
      console.log('user 2');

      this.router.navigateByUrl('/teacher/leave-dashboard');
    }
  }
}
