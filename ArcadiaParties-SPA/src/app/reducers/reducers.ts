import { ActionReducerMap, Action } from '@ngrx/store';
import { InjectionToken } from '@angular/core';

import { titleFeatureStateKey, TitleState, titleReducer } from './title-reducers';

export interface State {
  [titleFeatureStateKey]: TitleState;
}

export const ROOT_REDUCERS = new InjectionToken<ActionReducerMap<State, Action>>('Root reducers token', {
  factory: () => ({
    [titleFeatureStateKey]: titleReducer
  })
});
