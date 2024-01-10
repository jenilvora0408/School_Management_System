import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule } from './app/components/authentication/authentication.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => AuthenticationModule,
    // canActivate: [SiginGuard()],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
