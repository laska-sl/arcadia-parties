import { createReducer, on } from '@ngrx/store';

import { loadDepartmentAction } from '../actions/actions';

export const departmentFeatureStateKey = 'department';

export interface DepartmentState {
  department: string;
}

const initialState: DepartmentState = {
  department: ''
};

const mockDepartment = 'Temp department';

export const departmentReducer = createReducer(
  initialState,
  on(loadDepartmentAction, (state) => ({ ...state, department: mockDepartment }))
);
