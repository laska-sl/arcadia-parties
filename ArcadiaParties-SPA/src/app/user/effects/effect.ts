import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, mergeMap } from 'rxjs/operators';

import { UserService } from '../services/user.service';
import { loadUserAction, loadUserSuccessAction } from '../actions/actions';


@Injectable()
export class UserEffect {
  loadUser = createEffect(() =>
    this.actions.pipe(
      ofType(loadUserAction),
      mergeMap(() => this.userService.getUser()
      .pipe(
        map(userFromService => loadUserSuccessAction({user : userFromService}))
      ))
    )
  );

  constructor(private actions: Actions, private userService: UserService) {}
}
