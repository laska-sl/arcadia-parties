import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, tap } from 'rxjs/operators';

import { UserService } from '../services/user.service';
import { loadUserAction, loadUserSuccessAction } from '../actions/actions';
import { UserState } from '../reducers/reducer';
import { Store } from '@ngrx/store';

@Injectable()
export class UserEffect {
  loadUser = createEffect(() =>
    this.actions.pipe(
      ofType(loadUserAction),
      map(() => loadUserSuccessAction(this.userService.getUser()))
    )
  );

  constructor(private actions: Actions, private userService: UserService) {}
}
