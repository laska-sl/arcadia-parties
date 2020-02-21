import { createReducer, on } from '@ngrx/store';
import { changeTitleAction } from '../actions/actions';

export const headerFeatureStateKey = 'header';

export interface HeaderState {
    title: string;
}

const initialState: HeaderState = {
    title: ''
}

export const reducers = createReducer(
    initialState,
    on(changeTitleAction, (state, props) => ({ ...state, title: props.title }))
);