import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from 'src/app-routing.module';
import { LoginComponent } from './components/authentication/login/login.component';
import { AuthenticationComponent } from './components/authentication/authentication.component';
import { AuthenticationModule } from './components/authentication/authentication.module';
import { AuthenticationRoutingModule } from './components/authentication/authentication-routing.module';

const components = [AuthenticationComponent];

@NgModule({
  declarations: [AppComponent, ...components],
  imports: [
    BrowserModule,
    NgbModule,
    SharedModule,
    AppRoutingModule,
    AuthenticationModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
