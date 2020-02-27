import { Component, OnInit } from '@angular/core';
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
export class UserIdentityComponent implements OnInit {
  useridentity$: Observable<string> = this.store.pipe(select(selectUserIdentity));

  constructor(private store: Store<State>) {
    store.dispatch(
      loadUser({
        user: {
          identity: 'ekaterina.kuznetsova',
          firstName: 'ekaterina',
          lastName: 'kuznetsova',
          department: 'horoshiy',
          dates: [
            { name: 'BirthDay', date: new Date('11.02.1944') },
            { name: 'HireDay', date: new Date('03.12.1955') }
          ],
          roles: ['User', 'Admin']
        }
      })
    );
  }

  ngOnInit() {}
}
