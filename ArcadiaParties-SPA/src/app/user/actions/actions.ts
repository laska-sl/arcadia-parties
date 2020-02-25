import { createAction, props } from '@ngrx/store';

export const changeIdentityAction = createAction('[Main] Change Identity', props<{ identity: string }>());
