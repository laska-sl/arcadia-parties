import { createFeatureSelector, createSelector } from '@ngrx/store';


import { State } from 'src/app/reducers/reducers';
import { UserState, userFeatureStateKey } from '../reducers/user-reducer';

export const userFeatureSelector = createFeatureSelector<State, UserState>(userFeatureStateKey);

export const selectUserIdentity = createSelector(
    userFeatureSelector,
    state => state.user.identity
);

export const selectUser = createSelector(
    userFeatureSelector,
    state => state.user
);
