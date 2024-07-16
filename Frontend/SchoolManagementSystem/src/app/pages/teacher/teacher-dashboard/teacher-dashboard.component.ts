import { Component, inject, Input } from '@angular/core';
import { SidebarComponent } from '../../../shared/components/sidebar/sidebar.component';
import {
  NgbActiveOffcanvas,
  NgbDropdownModule,
  NgbOffcanvas,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
@Component({
  selector: 'app-teacher-dashboard',
  standalone: true,
  imports: [NgbDropdownModule, HeaderComponent],
  templateUrl: './teacher-dashboard.component.html',
  styleUrl: './teacher-dashboard.component.scss',
})
export class TeacherDashboardComponent {
  private offCanvasService = inject(NgbOffcanvas);

  constructor() {}

  open() {
    const offcanvasRef = this.offCanvasService.open(SidebarComponent);
    offcanvasRef.componentInstance.name = 'Sidenav';
  }
}
