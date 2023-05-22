import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { environment } from '../environments/environment';
import { ApiModule, BASE_PATH, Configuration } from './shared/sdkcore';
import { canActivate, canActivateChild } from './services/auth-guard.service';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    ApiModule,
    BrowserModule,//.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule), canActivate: [canActivate], canActivateChild: [canActivateChild] },
      { path: 'cliente', loadChildren: () => import('./cliente/cliente.module').then(m => m.ClienteModule), canActivate: [canActivate], canActivateChild: [canActivateChild] },
    ])
  ],
  providers: [
    { provide: BASE_PATH, useValue: environment.apiUrl },
    {
      provide: Configuration,
      useFactory: (authService: AuthService) => new Configuration(
        {
          basePath: environment.apiUrl,
          accessToken: authService.getAccessToken.bind(authService)
        }
      ),
      deps: [AuthService],
      multi: false
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
