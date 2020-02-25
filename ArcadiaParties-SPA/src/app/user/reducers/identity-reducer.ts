import { createReducer, on } from '@ngrx/store';

import { changeIdentityAction } from '../actions/actions';

export const identityFeatureStateKey = 'identity';

export interface IdentityState {
    identity: string;
}

const initialState: IdentityState = {
    identity: ''
};

export const identityReducer = createReducer(
    initialState,
    on(changeIdentityAction, (state, props) => ({ ...state, identity: props.identity }))
);
