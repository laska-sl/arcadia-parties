import { createReducer, on } from '@ngrx/store';

import { loadUser } from '../actions/actions';
import { User } from '../models/User';

export const userFeatureStateKey = 'user';

export interface UserState {
  user: User;
}

const initialState: UserState = {
  user: null
};

const mockUser = {
  identity: 'ekaterina.kuznetsova',
  firstName: 'ekaterina',
  lastName: 'kuznetsova',
  department: 'horoshiy',
  dates: [
    { name: 'BirthDay', date: new Date('11.02.1944') },
    { name: 'HireDay', date: new Date('03.12.1955') }
  ],
  roles: ['User', 'Admin']
} as User;

export const userReducer = createReducer(
  initialState,
  on(loadUser, state => ({ ...state, user: mockUser }))
);
