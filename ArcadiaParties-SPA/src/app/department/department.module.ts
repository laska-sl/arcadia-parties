import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';

import { DepartmentIdentityComponent } from './department-identity/department-identity.component';
import { MaterialModule } from '../material/material.module';
import { departmentFeatureStateKey, departmentReducer } from './reducers/reducer';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(departmentFeatureStateKey, departmentReducer)
  ],
  declarations: [DepartmentIdentityComponent],
  exports: [DepartmentIdentityComponent]
})
export class DepartmentModule { }
