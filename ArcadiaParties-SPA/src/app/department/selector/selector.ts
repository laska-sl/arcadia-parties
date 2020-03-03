import { createFeatureSelector, createSelector } from '@ngrx/store';
import { DepartmentState, departmentFeatureStateKey } from '../reducers/reducer';


export const departmentFeatureSelector = createFeatureSelector<DepartmentState>(departmentFeatureStateKey);

export const selectDepartments = createSelector(departmentFeatureSelector, state => state.departments);

export const selectCurrentDepartment = createSelector(departmentFeatureSelector, state => state.departmentId);
