import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule } from '@angular/common/http';

import { MaterialModule } from './material/material.module';
import { AppComponent } from './app.component';
import { ROOT_REDUCERS } from './reducers/reducers';
import { environment } from '../environments/environment';
import { HeaderComponent } from './header/header.component';
import { ContentComponent } from './content/content.component';
import { appRoutes } from './routes';
import { UserModule } from './user/user.module';
import { TitleEffect } from './effects/effect';
import { DepartmentModule } from './department/department.module';
import { TokenInterceptorProvider } from './services/token-interceptor';
import { AppSettingsService } from './app-settings/app-settings.service';

function initializeAppSettings(appSettingsService: AppSettingsService) {
  return () => appSettingsService.init();
}

@NgModule({
  declarations: [AppComponent, HeaderComponent, ContentComponent],
  imports: [
    StoreModule.forRoot(ROOT_REDUCERS, {
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true
      }
    }),
    BrowserModule,
    UserModule,
    DepartmentModule,
    BrowserAnimationsModule,
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production
    }),
    MaterialModule,
    RouterModule.forRoot(appRoutes),
    EffectsModule.forRoot([TitleEffect]),
    HttpClientModule
  ],
  providers: [
    TokenInterceptorProvider,
    AppSettingsService,
    {
      provide: APP_INITIALIZER,
      useFactory: (appSettingsService: AppSettingsService) => () => appSettingsService.init(),
      deps: [AppSettingsService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
