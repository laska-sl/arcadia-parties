import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { loadUserAction } from '../actions/actions';
import { selectUserName } from '../selector/selector';
import { UserState } from '../reducers/reducer';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-identity',
  templateUrl: './user-identity.component.html',
  styleUrls: ['./user-identity.component.scss']
})
export class UserIdentityComponent {
  userName$: Observable<string> = this.store.pipe(select(selectUserName));

  constructor(private store: Store<UserState>, private authService: AuthService) {
    store.dispatch(loadUserAction());
  }

  logout() {
    this.authService.logout();
  }
}
