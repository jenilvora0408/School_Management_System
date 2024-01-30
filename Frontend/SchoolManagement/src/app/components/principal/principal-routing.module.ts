import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrincipalComponent } from './principal.component';
import { PrincipalDashboardComponent } from './principal-dashboard/principal-dashboard.component';
import { AuthGuard } from 'src/app/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: PrincipalComponent,

    children: [
      {
        path: '',
        component: PrincipalDashboardComponent,
      },
      {
        path: 'dashboard',
        component: PrincipalDashboardComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PrincipalRoutingModule {}
