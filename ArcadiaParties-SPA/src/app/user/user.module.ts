import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';

import { UserIdentityComponent } from './user-identity/user-identity.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MaterialModule } from '../material/material.module';
import { userFeatureStateKey, userReducer } from './reducers/reducer';
import { userRoutes } from './routes';
import { UserEffect } from './effects/effect';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(userFeatureStateKey, userReducer),
    RouterModule.forChild(userRoutes),
    EffectsModule.forFeature([UserEffect])
  ],
  declarations: [UserIdentityComponent, UserInfoComponent],
  exports: [UserIdentityComponent, UserInfoComponent]
})
export class UserModule {}
