import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { loadUserAction } from '../actions/actions';
import { selectUserIdentity } from '../selector/selector';
import { UserState } from '../reducers/reducer';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-identity',
  templateUrl: './user-identity.component.html',
  styleUrls: ['./user-identity.component.scss']
})
export class UserIdentityComponent {
  userIdentity$: Observable<string> = this.store.pipe(select(selectUserIdentity));

  constructor(private store: Store<UserState>, private authService: AuthService) {
    store.dispatch(loadUserAction());
  }

  logout() {
    this.authService.logout();
  }
}
