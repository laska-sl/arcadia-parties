import { createAction, props } from '@ngrx/store';
import { User } from 'src/app/models/User';

export const loadUser = createAction('[Main] Change User', props<{ user: User }>());
