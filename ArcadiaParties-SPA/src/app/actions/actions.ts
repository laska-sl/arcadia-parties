import { createAction, props } from '@ngrx/store';

export const changeTitleAction = createAction('[Main] Change Title', props<{ title: string }>());

export const changeTitleSuccessAction = createAction('[Main] Title Loaded Success', props<{ title: string }>());
