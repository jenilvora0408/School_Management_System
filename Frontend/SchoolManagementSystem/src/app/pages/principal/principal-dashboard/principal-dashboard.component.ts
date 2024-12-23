import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';

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
        this.router.navigate([RoutingPathConstant.classesAndSubjectsUrl]);
        break;
      case 'leave-requests':
        this.router.navigate([
          RoutingPathConstant.leaveRequestsForPrincipalUrl,
        ]);
        break;
      case 'contact-requests':
        this.router.navigate([
          RoutingPathConstant.contactRequestsForPrincipalUrl,
        ]);
        break;
      case 'manage-subjects':
        this.router.navigate([
          RoutingPathConstant.manageSubjectsByPrincipalUrl,
        ]);
        break;
      default:
        console.log('Invalid routing path');
    }
  }
}
