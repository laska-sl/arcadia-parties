import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';

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
    EffectsModule.forRoot([TitleEffect])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
