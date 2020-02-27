import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {StoreModule} from '@ngrx/store';

import { UserIdentityComponent } from './user-identity/user-identity.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MaterialModule } from '../material/material.module';
import { appRoutes } from '../routes';
import { userFeatureStateKey, userReducer } from './reducers/user-reducer';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes),
    MaterialModule,
    StoreModule.forFeature(userFeatureStateKey, userReducer)
  ],
  declarations: [
    UserIdentityComponent,
    UserInfoComponent
  ],
  exports: [
    UserIdentityComponent,
    UserInfoComponent
  ]
})
export class UserModule { }
