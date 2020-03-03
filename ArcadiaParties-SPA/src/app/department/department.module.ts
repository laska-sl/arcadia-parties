import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { DepartmentSelectorComponent } from './department-selector/department-selector.component';
import { MaterialModule } from '../material/material.module';
import { departmentFeatureStateKey, departmentReducer } from './reducers/reducer';
import { DepartmentEffect } from './effects/effect';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    StoreModule.forFeature(departmentFeatureStateKey, departmentReducer),
    EffectsModule.forFeature([DepartmentEffect])
  ],
  declarations: [DepartmentSelectorComponent],
  exports: [DepartmentSelectorComponent]
})
export class DepartmentModule { }
