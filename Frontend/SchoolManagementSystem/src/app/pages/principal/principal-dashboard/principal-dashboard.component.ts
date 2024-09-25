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
    if (routingPath == 'edit-class')
      this.router.navigate(['principal/classes-and-subjects']);
    else if(routingPath == 'leave-requests')
      this.router.navigate(['principal/leave-requests'])
  }
}
