import { createFeatureSelector, createSelector } from '@ngrx/store';

import { DepartmentState, departmentFeatureStateKey } from '../reducers/reducer';

export const departmentFeatureSelector = createFeatureSelector<DepartmentState>(departmentFeatureStateKey);

export const selectDepartment = createSelector(departmentFeatureSelector, state => state.department);
