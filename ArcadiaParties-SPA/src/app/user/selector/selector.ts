import { createFeatureSelector, createSelector } from '@ngrx/store';

import { identityFeatureStateKey, IdentityState } from '../reducers/identity-reducer';
import { State } from 'src/app/reducers/reducers';


export const identityFeatureSelector = createFeatureSelector<State, IdentityState>(identityFeatureStateKey);

export const selectIdentity = createSelector(
    identityFeatureSelector,
    state => state.identity
);
