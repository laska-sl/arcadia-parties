import { createAction, props } from '@ngrx/store';

import { Department } from '../models/department';

export const loadDepartmentsAction = createAction('[Department] Load Departments');

export const loadDepartmentsSuccessAction = createAction('[Department] Load Departments Success', props<{ departments: Department[] }>());

export const changeDepartmentIdAction = createAction('[Department] Change department id', props<{ departmentId: number }>());
