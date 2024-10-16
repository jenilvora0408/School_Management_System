import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-principal-dashboard',
  standalone: true,
  imports: [HeaderComponent, RouterModule],
  templateUrl: './principal-dashboard.component.html',
  styleUrl: './principal-dashboard.component.scss',
})
export class PrincipalDashboardComponent {
  constructor(private router: Router, private route: ActivatedRoute) {}

  navigate(routingPath: string) {
    switch (routingPath) {
      case 'edit-class':
        this.router.navigate(['principal/classes-and-subjects']);
        break;
      case 'leave-requests':
        this.router.navigate(['principal/leave-requests']);
        break;
      case 'contact-requests':
        this.router.navigate(['principal/contact-requests']);
        break;
      default:
        console.log('Invalid routing path');
    }
  }
}
