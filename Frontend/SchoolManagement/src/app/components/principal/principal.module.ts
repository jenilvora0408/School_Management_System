import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrincipalRoutingModule } from './principal-routing.module';
import { PrincipalDashboardComponent } from './principal-dashboard/principal-dashboard.component';

const components = [PrincipalDashboardComponent];

@NgModule({
  declarations: [...components],
  imports: [CommonModule, PrincipalRoutingModule],
})
export class PrincipalModule {}
