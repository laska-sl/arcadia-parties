import { createFeatureSelector, createSelector } from '@ngrx/store';

import { UserState, userFeatureStateKey } from '../reducers/user-reducer';

export const userFeatureSelector = createFeatureSelector<UserState>(userFeatureStateKey);

export const selectUserIdentity = createSelector(
    userFeatureSelector,
    state => state.user.identity
);

export const selectUser = createSelector(
    userFeatureSelector,
    state => state.user
);
