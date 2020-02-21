import { headerFeatureStateKey, HeaderState, reducers } from './header-reducers';
import { ActionReducerMap, Action } from '@ngrx/store';
import { InjectionToken } from '@angular/core';

export interface State {
  [headerFeatureStateKey]: HeaderState
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<State, Action>>('Root reducers token', {
  factory: () => ({
    [headerFeatureStateKey]: reducers,
  })
});