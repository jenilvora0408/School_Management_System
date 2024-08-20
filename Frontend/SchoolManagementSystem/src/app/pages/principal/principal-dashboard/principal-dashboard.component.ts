import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-principal-dashboard',
  standalone: true,
  imports: [HeaderComponent, RouterModule],
  templateUrl: './principal-dashboard.component.html',
  styleUrl: './principal-dashboard.component.scss',
})
export class PrincipalDashboardComponent {}
