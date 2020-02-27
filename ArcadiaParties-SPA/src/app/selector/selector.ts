import { createFeatureSelector, createSelector } from '@ngrx/store';
import { headerFeatureStateKey, HeaderState } from '../reducers/header-reducers';
import { State } from '../reducers/reducers';

export const headerFeatureSelector = createFeatureSelector<State, HeaderState>(headerFeatureStateKey);

export const selectTitle = createSelector(
    headerFeatureSelector,
    state => state.title
);
