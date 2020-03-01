import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';

import { DepartmentIdentityComponent } from './department-identity/department-identity.component';
import { MaterialModule } from '../material/material.module';
import { departmentsFeatureStateKey, departmentReducer } from './reducers/reducer';
import { selectedDepartmentFeatureStateKey, selectedDepartmentReducer } from './reducers/selected-department-reducer';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(departmentsFeatureStateKey, departmentReducer),
    StoreModule.forFeature(selectedDepartmentFeatureStateKey, selectedDepartmentReducer)
  ],
  declarations: [DepartmentIdentityComponent],
  exports: [DepartmentIdentityComponent]
})
export class DepartmentModule { }
