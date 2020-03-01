import { createReducer, on } from '@ngrx/store';

import { changeDepartmentIdAction } from '../actions/actions';

export const selectedDepartmentFeatureStateKey = 'selectedDepartment';

export interface SelectedDepartmentIdState {
    departmentId: number;
}

const initialState: SelectedDepartmentIdState = {
    departmentId: 0
};

export const selectedDepartmentReducer = createReducer(
    initialState,
    on(changeDepartmentIdAction, (state, props) => ({ ...state, departmentId: props.departmentId }))
);
