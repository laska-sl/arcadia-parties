import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { loadUser } from '../actions/actions';
import { State } from '../../reducers/reducers';
import { selectUserIdentity } from '../selector/selector';

@Component({
  selector: 'app-user-identity',
  templateUrl: './user-identity.component.html',
  styleUrls: ['./user-identity.component.scss']
})
export class UserIdentityComponent {
  useridentity$: Observable<string> = this.store.pipe(select(selectUserIdentity));

  constructor(private store: Store<State>) {
    store.dispatch(loadUser());
  }
}
