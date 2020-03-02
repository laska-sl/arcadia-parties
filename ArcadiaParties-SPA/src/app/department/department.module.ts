import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';

import { DepartmentSelectorComponent } from './department-selector/department-selector.component';
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
  declarations: [DepartmentSelectorComponent],
  exports: [DepartmentSelectorComponent]
})
export class DepartmentModule { }
