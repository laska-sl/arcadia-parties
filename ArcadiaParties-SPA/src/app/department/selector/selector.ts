import { createFeatureSelector, createSelector } from '@ngrx/store';

import { DepartmentsState, departmentsFeatureStateKey } from '../reducers/reducer';
import { SelectedDepartmentIdState, selectedDepartmentFeatureStateKey } from '../reducers/selected-department-reducer';

export const departmentsFeatureSelector = createFeatureSelector<DepartmentsState>(departmentsFeatureStateKey);
export const selectDepartments = createSelector(departmentsFeatureSelector, state => state.departments);

export const currentDepartmentFeatureSelector = createFeatureSelector<SelectedDepartmentIdState>(selectedDepartmentFeatureStateKey);
export const selectCurrentDepartment = createSelector(currentDepartmentFeatureSelector, state => state.departmentId);
