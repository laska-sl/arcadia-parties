import { createAction, props } from '@ngrx/store';

export const changeTitleAction = createAction('[Main] Change Title', props<{ title: string }>());
