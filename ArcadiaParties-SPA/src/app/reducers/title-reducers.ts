import { createReducer, on } from '@ngrx/store';

import { changeTitleAction } from '../actions/actions';

export const titleFeatureStateKey = 'title';

export interface TitleState {
  title: string;
}

const initialState: TitleState = {
  title: ''
};

export const titleReducer = createReducer(
  initialState,
  on(changeTitleAction, (state, props) => ({ ...state, title: props.title }))
);
