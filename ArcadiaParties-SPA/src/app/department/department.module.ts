import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';

import { DepartmentSelectorComponent } from './department-selector/department-selector.component';
import { MaterialModule } from '../material/material.module';
import { departmentFeatureStateKey, departmentReducer } from './reducers/reducer';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(departmentFeatureStateKey, departmentReducer)
  ],
  declarations: [DepartmentSelectorComponent],
  exports: [DepartmentSelectorComponent]
})
export class DepartmentModule { }
