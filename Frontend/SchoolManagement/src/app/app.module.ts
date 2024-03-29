import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from 'src/app-routing.module';
import { LoginComponent } from './components/authentication/login/login.component';
import { AuthenticationComponent } from './components/authentication/authentication.component';
import { AuthenticationModule } from './components/authentication/authentication.module';
import { AuthenticationRoutingModule } from './components/authentication/authentication-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { ApiCallConstant } from './constants/api-call/apis';
import { StorageHelperConstant } from './constants/storage-helper/storage-helper';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { AuthService } from './services/auth.service';
import { ToastrModule } from 'ngx-toastr';
import { PrincipalDashboardComponent } from './components/principal/principal-dashboard/principal-dashboard.component';
import { PrincipalComponent } from './components/principal/principal.component';
import { PrincipalModule } from './components/principal/principal.module';

const components = [AuthenticationComponent, PrincipalComponent];

@NgModule({
  declarations: [AppComponent, ...components],
  imports: [
    BrowserModule,
    NgbModule,
    SharedModule,
    AppRoutingModule,
    AuthenticationModule,
    PrincipalModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem(StorageHelperConstant.authToken);
        },
        allowedDomains: [ApiCallConstant.BASE_URL],
        disallowedRoutes: [ApiCallConstant.LOGIN_URL],
      },
    }),
  ],
  providers: [
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
