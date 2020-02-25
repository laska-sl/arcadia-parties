import { createReducer, on } from '@ngrx/store';

import { loadUser } from '../actions/actions';
import { User } from 'src/app/models/User';

export const userFeatureStateKey = 'user';

export interface UserState {
    user: User;
}

const initialState: UserState = {
    user: {
        identity: '',
        firstName: '',
        lastName: '',
        department: '',
        dates: [],
        roles: []
    }
}

export const userReducer = createReducer(
    initialState,
    on(loadUser, (state, props) => ({ ...state, user: props.user }))
);
