import { createAction, props } from '@ngrx/store';

import { User } from '../models/User';

export const loadUserAction = createAction('[User] Load User');

export const loadUserSuccessAction = createAction('[User] User Loaded Success', props<{ user: User }>());
