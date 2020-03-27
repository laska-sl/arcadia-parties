import { createFeatureSelector, createSelector } from '@ngrx/store';

import { UserState, userFeatureStateKey } from '../reducers/reducer';

export const userFeatureSelector = createFeatureSelector<UserState>(userFeatureStateKey);

export const selectUser = createSelector(userFeatureSelector, state => state.user);

export const selectUserName = createSelector(selectUser, user => user && user.name);

export const selectUserDepartmentId = createSelector(selectUser, user => user && user.department.id);
