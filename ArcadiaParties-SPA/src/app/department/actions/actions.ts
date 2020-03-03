import { createAction, props } from '@ngrx/store';

export const loadDepartmentsAction = createAction('[Department] Load Departments');

export const changeDepartmentIdAction = createAction('[Department] Change department id', props<{ departmentId: number }>());
