import { createReducer, on } from '@ngrx/store';

import { changeTitleSuccessAction } from '../actions/actions';

export const titleFeatureStateKey = 'title';

export interface TitleState {
  title: string;
}

const initialState: TitleState = {
  title: ''
};

export const titleReducer = createReducer(
  initialState,
  on(changeTitleSuccessAction, (state, props) => ({ ...state, title: props.title }))
);
