import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { selectUser } from '../selector/selector';
import { User } from '../models/User';
import { changeTitleAction } from 'src/app/actions/actions';
import { UserState } from '../reducers/reducer';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
  user$: Observable<User> = this.store.pipe(select(selectUser));

  constructor(private store: Store<UserState>) {
    store.dispatch(changeTitleAction({ title: 'Arcadia Parties - User Profile' }));
  }
}
