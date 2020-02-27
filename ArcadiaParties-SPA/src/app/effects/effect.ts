import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, tap } from 'rxjs/operators';

import { changeTitleAction, changeTitleSuccessAction } from '../actions/actions';
import { TitleService } from '../services/title.service';

@Injectable()
export class TitleEffect {
  loadTitle$ = createEffect(() =>
    this.actions$.pipe(
      ofType(changeTitleAction),
      tap(payload => this.titleService.setTitle(payload.title)),
      map(payload => changeTitleSuccessAction(payload))
    )
  );

  constructor(private actions$: Actions, private titleService: TitleService) {}
}
