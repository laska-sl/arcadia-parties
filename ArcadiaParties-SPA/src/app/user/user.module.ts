import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { RouterModule } from '@angular/router';

import { UserIdentityComponent } from './user-identity/user-identity.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MaterialModule } from '../material/material.module';
import { userFeatureStateKey, userReducer } from './reducers/reducer';
import { userRoutes } from './routes';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(userFeatureStateKey, userReducer),
    RouterModule.forChild(userRoutes)
  ],
  declarations: [UserIdentityComponent, UserInfoComponent],
  exports: [UserIdentityComponent, UserInfoComponent]
})
export class UserModule {}
