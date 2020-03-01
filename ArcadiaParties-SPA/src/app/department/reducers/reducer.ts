import { createReducer, on } from '@ngrx/store';

import { loadDepartmentsAction } from '../actions/actions';
import { Department } from '../models/Department';

export const departmentsFeatureStateKey = 'departments';

export interface DepartmentsState {
  departments: Department[];
}

const initialState: DepartmentsState = {
  departments: []
};

const mockDepartments: Department[] = [
  { id: 1, name: 'Department1' },
  { id: 2, name: 'Department2' },
  { id: 3, name: 'Department3' },
  { id: 4, name: 'horoshiy' }
];

export const departmentReducer = createReducer(
  initialState,
  on(loadDepartmentsAction, (state) => ({ ...state, departments: mockDepartments }))
);
