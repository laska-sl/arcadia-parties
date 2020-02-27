import { createFeatureSelector, createSelector } from '@ngrx/store';

import { titleFeatureStateKey, TitleState } from '../reducers/title-reducers';

export const titleFeatureSelector = createFeatureSelector<TitleState>(titleFeatureStateKey);

export const selectTitle = createSelector(
    titleFeatureSelector,
    state => state.title
);
