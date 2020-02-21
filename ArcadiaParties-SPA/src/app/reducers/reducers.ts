import { ActionReducerMap, Action } from '@ngrx/store';
import { InjectionToken } from '@angular/core';

import { headerFeatureStateKey, HeaderState, reducers } from './header-reducers';

export interface State {
  [headerFeatureStateKey]: HeaderState;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<State, Action>>('Root reducers token', {
  factory: () => ({
    [headerFeatureStateKey]: reducers,
  })
});
