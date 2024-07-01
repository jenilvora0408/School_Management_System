import { Routes } from '@angular/router';
import { AuthenticationComponent } from './components/authentication/authentication.component';
import { AdmitRequestComponent } from './components/authentication/admit-request/admit-request.component';

export const routes: Routes = [{ path: '', component: AdmitRequestComponent }];
