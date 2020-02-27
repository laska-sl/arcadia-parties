import { createFeatureSelector, createSelector } from '@ngrx/store';

import { UserState, userFeatureStateKey } from '../reducers/reducer';

export const userFeatureSelector = createFeatureSelector<UserState>(userFeatureStateKey);

export const selectUser = createSelector(userFeatureSelector, state => state.user);

export const selectUserIdentity = createSelector(selectUser, user => user && user.identity);
