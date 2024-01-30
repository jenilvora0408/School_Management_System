import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from './app/components/authentication/authentication.module';
import { AuthGuard } from './app/guards/auth.guard';
import { PrincipalModule } from './app/components/principal/principal.module';
import { UserRole } from './app/constants/shared/system-constant';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => AuthenticationModule,
  },
  {
    path: UserRole.principal,
    loadChildren: () => PrincipalModule,
    canActivate: [AuthGuard()],
    data: { expectedRole: UserRole.principal },
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
