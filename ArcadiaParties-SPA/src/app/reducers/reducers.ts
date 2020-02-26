import { ActionReducerMap, Action } from '@ngrx/store';
import { InjectionToken } from '@angular/core';

import { headerFeatureStateKey, HeaderState, headerReducer } from './header-reducers';
import { userFeatureStateKey, UserState, userReducer } from '../user/reducers/user-reducer';

export interface State {
  [headerFeatureStateKey]: HeaderState;
  [userFeatureStateKey]: UserState;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<State, Action>>('Root reducers token', {
  factory: () => ({
    [headerFeatureStateKey]: headerReducer,
    [userFeatureStateKey]: userReducer
  })
});
