import { createFeatureSelector, createSelector } from '@ngrx/store';

import { DepartmentsState, departmentFeatureStateKey } from '../reducers/reducer';

export const departmentFeatureSelector = createFeatureSelector<DepartmentsState>(departmentFeatureStateKey);

export const selectDepartments = createSelector(departmentFeatureSelector, state => state.departments);
