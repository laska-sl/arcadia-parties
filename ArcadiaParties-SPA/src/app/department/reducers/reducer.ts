import { createReducer, on } from '@ngrx/store';

import { loadDepartmentsAction } from '../actions/actions';

export const departmentFeatureStateKey = 'departments';

export interface DepartmentsState {
  departments: string[];
}

const initialState: DepartmentsState = {
  departments: []
};

const mockDepartment = ['Department1', 'Department2', 'Department3', 'horoshiy'];

export const departmentReducer = createReducer(
  initialState,
  on(loadDepartmentsAction, (state) => ({ ...state, departments: mockDepartment }))
);
