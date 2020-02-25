import { ActionReducerMap, Action } from '@ngrx/store';
import { InjectionToken } from '@angular/core';

import { headerFeatureStateKey, HeaderState, headerReducer } from './header-reducers';
import { identityFeatureStateKey, IdentityState, identityReducer } from '../user/reducers/identity-reducer';

export interface State {
  [headerFeatureStateKey]: HeaderState;
  [identityFeatureStateKey]: IdentityState;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<State, Action>>('Root reducers token', {
  factory: () => ({
    [headerFeatureStateKey]: headerReducer,
    [identityFeatureStateKey]: identityReducer
  })
});
