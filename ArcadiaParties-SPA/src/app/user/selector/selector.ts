import { createFeatureSelector, createSelector } from '@ngrx/store';

import { userFeatureStateKey, UserState } from '../reducers/identity-reducer';
import { State } from 'src/app/reducers/reducers';


export const userFeatureSelector = createFeatureSelector<State, UserState>(userFeatureStateKey);

export const selectUser = createSelector(
    userFeatureSelector,
    state => state.user
);
