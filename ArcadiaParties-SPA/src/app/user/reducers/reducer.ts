import { createReducer, on } from '@ngrx/store';

import { loadUserAction, loadUserSuccessAction } from '../actions/actions';
import { User } from '../models/User';

export const userFeatureStateKey = 'user';

export interface UserState {
  user: User;
}

const initialState: UserState = {
  user: null
};

export const userReducer = createReducer(
  initialState,
  on(loadUserSuccessAction, (state, props) => ({ ...state, user: props.user }))
);
