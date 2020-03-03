import { createReducer, on } from '@ngrx/store';

import { changeDepartmentIdAction, loadDepartmentsSuccessAction } from '../actions/actions';
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

export const departmentReducer = createReducer(
    initialState,
    on(changeDepartmentIdAction, (state, props) => ({ ...state, departmentId: props.departmentId })),
    on(loadDepartmentsSuccessAction, (state, props) => ({ ...state, departments: props.departments }))
);
