import { createReducer, on } from '@ngrx/store';

import { changeDepartmentIdAction, loadDepartmentsAction } from '../actions/actions';
import { Department } from '../models/department';

export const departmentFeatureStateKey = 'department';

export interface DepartmentState {
    departmentId: number;
    departments: Department[];
}

const initialState: DepartmentState = {
    departmentId: 0,
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
    on(changeDepartmentIdAction, (state, props) => ({ ...state, departmentId: props.departmentId })),
    on(loadDepartmentsAction, (state) => ({ ...state, departments: mockDepartments }))
);
